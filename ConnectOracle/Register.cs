using System;
using System.Security.Cryptography;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using System.Data;
using System.Text.RegularExpressions;

namespace ConnectOracle
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            CenterToScreen();
            txtPassword.PasswordChar = '*';
            txtPassword_cf.PasswordChar = '*';
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {
            string usernameInput = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string password_cf = txtPassword_cf.Text.Trim();

            if (string.IsNullOrWhiteSpace(usernameInput))
            {
                MessageBox.Show("Vui lòng nhập Username");
                txtUsername.Focus();
                return;
            }

            if (password != password_cf)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp. Vui lòng nhập lại!");
                txtPassword.Focus();
                return;
            }

            if (!IsValidOracleUnquotedUsername(usernameInput))
            {
                MessageBox.Show("Username không hợp lệ. Bắt đầu bằng chữ cái, tối đa 30 ký tự, chỉ gồm A-Z, 0-9, _, $, #.");
                txtUsername.Focus();
                return;
            }

            string username = usernameInput.ToUpperInvariant();

            OracleConnection c = ConnectOracle.Database.Get_Connect();
            if (c == null || c.State != ConnectionState.Open)
            {
                MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu. Vui lòng đăng nhập lại.");
                return;
            }

            try
            {
                const string checkQuery = "SELECT COUNT(*) FROM ALL_USERS WHERE USERNAME = :p_username";
                using (OracleCommand checkCmd = new OracleCommand(checkQuery, c))
                {
                    checkCmd.BindByName = true;
                    checkCmd.Parameters.Add(new OracleParameter("p_username", username));
                    int userCount = Convert.ToInt32(checkCmd.ExecuteScalar());
                    if (userCount > 0)
                    {
                        MessageBox.Show("User đã tồn tại trong database.");
                        txtUsername.Focus();
                        return;
                    }
                }

                string escapedPassword = password.Replace("\"", "\"\"");
                string createUserSql = $"CREATE USER {username} IDENTIFIED BY \"{escapedPassword}\"";
                using (var createCmd = new OracleCommand(createUserSql, c))
                {
                    createCmd.ExecuteNonQuery();
                }

                string grantSql = $"GRANT CREATE SESSION TO {username}";
                using (var grantCmd = new OracleCommand(grantSql, c))
                {
                    grantCmd.ExecuteNonQuery();
                }

                MessageBox.Show("Tạo user Oracle thành công!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo user: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static bool IsValidOracleUnquotedUsername(string name)
        {
            // Start with a letter, then letters/digits/_/$/#, max 30 chars
            return Regex.IsMatch(name, "^[A-Za-z][A-Za-z0-9_$#]{0,29}$");
        }
    }
}