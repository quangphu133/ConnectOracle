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
                int keyMaHoaCong;
                int keyMahoaNhan;
                string encryptedPass = MaHoaCong(pass, out keyMaHoaCong);
                string encryptedPass2 = MaHoaNhan(pass, out keyMahoaNhan);
                Database.Set_Database(host, port, sid, user, pass);
                if (Database.Connect())
                {
                    OracleConnection c = Database.Get_Connect();
                    MessageBox.Show("Dang nhap thanh cong\nServerVersion: " + c.ServerVersion +
                        "\nMat khau ma hoa cong (Key=" + keyMaHoaCong + "): " + encryptedPass +
                        "\nMat khau ma hoa nhan (Key=" + keyMahoaNhan + "): " + encryptedPass2);
                }
                else
                {
                    MessageBox.Show("Dang nhap that bai");
                }
            }
        }

        private int GenerateRandomAdditiveKey()
        {
            Random rand = new Random();
            return rand.Next(1, 26);
        }

        private string MaHoaCong(string password, out int key)
        {
            key = GenerateRandomAdditiveKey();
            StringBuilder encrypted = new StringBuilder();
            int shift = key % 26;

            foreach (char c in password)
            {
                if (char.IsLetter(c))
                {
                    char offset = char.IsUpper(c) ? 'A' : 'a';
                    int p = c - offset;
                    int C = (p + shift) % 26;
                    encrypted.Append((char)(C + offset));
                }
                else
                {
                    encrypted.Append(c);
                }
            }
            return encrypted.ToString();
        }

        private int GenerateRandomMultiplicativeKey()
        {
            int[] validKeys = { 1, 3, 5, 7, 9, 11, 15, 17, 19, 21, 23, 25 };
            Random rand = new Random();
            int index = rand.Next(validKeys.Length);
            return validKeys[index];
        }

        private string MaHoaNhan(string plainText, out int key)
        {
            key = GenerateRandomMultiplicativeKey();
            StringBuilder cipherText = new StringBuilder();
            int actualKey = key % 26;

            foreach (char c in plainText)
            {
                if (char.IsLetter(c))
                {
                    char offset = char.IsUpper(c) ? 'A' : 'a';
                    int p = c - offset;
                    int C = (p * actualKey) % 26;
                    cipherText.Append((char)(C + offset));
                }
                else
                {
                    cipherText.Append(c);
                }
            }
            return cipherText.ToString();
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
    }
}