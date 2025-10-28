using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace ConnectOracle
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            CenterToScreen();
            textBox5.PasswordChar = '*';
        }
        bool Check_Textbox(string host, string port, string sid, string user, string pass)
        {
            if (host == "")
            {
                MessageBox.Show("Chưa điền thông tin Host");
                txt_host.Focus();
                return false;
            }
            else if (port == "")
            {
                MessageBox.Show("Chưa điền thông tin Port");
                txt_port.Focus();
                return false;
            }
            else if (sid == "")
            {
                MessageBox.Show("Chưa điền thông tin Sid");
                txt_sid.Focus();
                return false;
            }
            else if (user == "")
            {
                MessageBox.Show("Chưa điền thông tin user");
                txt_user.Focus();
                return false;
            }
            else if (pass == "")
            {
                MessageBox.Show("Chưa điền thông tin Pass");
                textBox5.Focus();
                return false;
            }
            return true;
        }

        // Tạo key ngẫu nhiên cho mã hóa cộng (1-95)
        private int GenerateRandomAdditiveKey()
        {
            Random rand = new Random();
            return rand.Next(1, 96); // 1 đến 95
        }

        // Tạo key ngẫu nhiên cho mã hóa nhân (các số nguyên tố cùng nhau với 95)
        private int GenerateRandomMultiplicativeKey()
        {
            // Các key hợp lệ cho multiplicative cipher với modulo 95
            // Phải là các số nguyên tố cùng nhau với 95 (95 = 5 × 19)
            int[] validKeys = { 1, 2, 3, 4, 6, 7, 8, 9, 11, 12, 13, 16, 17, 18, 21, 22, 23, 24, 26, 27, 28, 29, 31, 32, 33, 34, 36, 37, 38, 39, 41, 42, 43, 44, 46, 47, 48, 49, 51, 52, 53, 54, 56, 57, 58, 59, 61, 62, 63, 64, 66, 67, 68, 69, 71, 72, 73, 74, 76, 77, 78, 79, 81, 82, 83, 84, 86, 87, 88, 89, 91, 92, 93, 94 };
            Random rand = new Random();
            int index = rand.Next(validKeys.Length);
            return validKeys[index];
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {
            string host = txt_host.Text;
            string port = txt_port.Text;
            string sid = txt_sid.Text;
            string user = txt_user.Text;
            string pass = textBox5.Text;

            if (Check_Textbox(host, port, sid, user, pass))
            {
                Database.Set_Database(host, port, sid, user, pass);
                if (Database.Connect())
                {
                    try
                    {
                        OracleConnection c = Database.Get_Connect();

                        // Tạo key ngẫu nhiên
                        int additiveKey = GenerateRandomAdditiveKey();
                        int multiplicativeKey = GenerateRandomMultiplicativeKey();

                        // Sử dụng các hàm mã hóa từ Oracle SQL với key ngẫu nhiên
                        string encryptedAdditive = GetEncryptedPassword(pass, "additive", additiveKey);
                        string encryptedMultiplicative = GetEncryptedPassword(pass, "multiplicative", multiplicativeKey);

                        MessageBox.Show("Đăng nhập thành công\nServerVersion: " + c.ServerVersion +
                            "\nMật khẩu mã hóa cộng (Key=" + additiveKey + "): " + encryptedAdditive +
                            "\nMật khẩu mã hóa nhân (Key=" + multiplicativeKey + "): " + encryptedMultiplicative);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi mã hóa mật khẩu: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại");
                }
            }
        }

        // Hàm gọi các function mã hóa từ Oracle
        private string GetEncryptedPassword(string password, string encryptType, int key)
        {
            string result = "";
            try
            {
                OracleConnection conn = Database.Get_Connect();
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    string sql = "";
                    if (encryptType.ToLower() == "additive")
                    {
                        sql = "SELECT encode_add(:password, :key) FROM DUAL";
                    }
                    else if (encryptType.ToLower() == "multiplicative")
                    {
                        sql = "SELECT encode_mul(:password, :key) FROM DUAL";
                    }

                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        cmd.Parameters.Add(":password", OracleDbType.Varchar2).Value = password;
                        cmd.Parameters.Add(":key", OracleDbType.Int32).Value = key;

                        object objResult = cmd.ExecuteScalar();
                        if (objResult != null)
                        {
                            result = objResult.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi trong quá trình mã hóa: " + ex.Message);
            }
            return result;
        }

        // Hàm giải mã mật khẩu từ Oracle
        private string GetDecryptedPassword(string encryptedPassword, string encryptType, int key)
        {
            string result = "";
            try
            {
                OracleConnection conn = Database.Get_Connect();
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    string sql = "";
                    if (encryptType.ToLower() == "additive")
                    {
                        sql = "SELECT decode_add(:encryptedPassword, :key) FROM DUAL";
                    }
                    else if (encryptType.ToLower() == "multiplicative")
                    {
                        sql = "SELECT decode_mul(:encryptedPassword, :key) FROM DUAL";
                    }

                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        cmd.Parameters.Add(":encryptedPassword", OracleDbType.Varchar2).Value = encryptedPassword;
                        cmd.Parameters.Add(":key", OracleDbType.Int32).Value = key;

                        object objResult = cmd.ExecuteScalar();
                        if (objResult != null)
                        {
                            result = objResult.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi trong quá trình giải mã: " + ex.Message);
            }
            return result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!Database.IsConnected())
            {
                MessageBox.Show("Chưa đăng nhập");
                return;
            }

            Database.Disconnect();

            if (!Database.IsConnected())
            {
                MessageBox.Show("Đăng xuất thành công");
            }
            else
            {
                MessageBox.Show("Đăng xuất thất bại");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }

        private void btnViewData_Click(object sender, EventArgs e)
        {
            if (!Database.IsConnected())
            {
                MessageBox.Show("Vui lòng đăng nhập Oracle trước khi xem dữ liệu.");
                return;
            }

            using (var f = new ConnectOracle.FormHienThi())
            {
                f.StartPosition = FormStartPosition.CenterParent;
                f.ShowDialog(this);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnMaHoaGiaiMa_Click(object sender, EventArgs e)
        {
            if (!Database.IsConnected())
            {
                MessageBox.Show("Vui lòng đăng nhập Oracle trước khi sử dụng Mã hóa/Giải mã.");
                return;
            }

            using (var f = new FormMaHoavaGiaiMa())
            {
                f.StartPosition = FormStartPosition.CenterParent;
                f.ShowDialog(this);
            }
        }

        private void btnMaHoaGiaiMaDES_Click(object sender, EventArgs e)
        {
            if (!Database.IsConnected())
            {
                MessageBox.Show("Vui lòng đăng nhập Oracle trước khi sử dụng Mã hóa/Giải mã.");
                return;
            }

            using (var f = new FormMaHoaDES())
            {
                f.StartPosition = FormStartPosition.CenterParent;
                f.ShowDialog(this);
            }
        }
    }
}