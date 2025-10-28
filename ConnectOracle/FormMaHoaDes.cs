using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace ConnectOracle
{
    public partial class FormMaHoaDES : Form
    {
        private DesOracle desOracle;

        public FormMaHoaDES()
        {
            InitializeComponent();
            CenterToScreen();

            // Khởi tạo DesOracle với connection hiện tại
            if (Database.IsConnected())
            {
                desOracle = new DesOracle(Database.Get_Connect());
            }
        }

        

        private void FormMaHoaDES_Load(object sender, EventArgs e)
        {
            if (!Database.IsConnected())
            {
                MessageBox.Show("Vui lòng kết nối Oracle trước khi sử dụng mã hóa DES.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            txtResult.Text = "Sẵn sàng thực hiện mã hóa/giải mã tables Oracle...";
        }

        private void btnEncryptColumn_Click(object sender, EventArgs e)
        {
            try
            {
                string tableName = txtTableName.Text.Trim().ToUpper();
                string columnName = txtColumnName.Text.Trim().ToUpper();
                string privateKey = txtEncryptKey.Text.Trim();

                if (string.IsNullOrEmpty(tableName))
                {
                    MessageBox.Show("Vui lòng nhập tên table.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTableName.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(columnName))
                {
                    MessageBox.Show("Vui lòng nhập tên cột.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtColumnName.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(privateKey))
                {
                    MessageBox.Show("Vui lòng nhập khóa bí mật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEncryptKey.Focus();
                    return;
                }

                txtResult.Text = $"Đang mã hóa cột {columnName} trong table {tableName}...";
                Application.DoEvents();

                bool success = desOracle.EncryptTableColumn(tableName, columnName, privateKey);

                if (success)
                {
                    txtResult.Text = $"Mã hóa cột {columnName} trong table {tableName} thành công!\r\nCột mã hóa: {columnName}_ENCRYPTED";
                }
                else
                {
                    txtResult.Text = $"Mã hóa cột {columnName} trong table {tableName} thất bại!";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mã hóa cột: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtResult.Text = "Lỗi: " + ex.Message;
            }
        }

        private void btnEncryptTable_Click(object sender, EventArgs e)
        {
            try
            {
                string tableName = txtTableName.Text.Trim().ToUpper();
                string privateKey = txtEncryptKey.Text.Trim();

                if (string.IsNullOrEmpty(tableName))
                {
                    MessageBox.Show("Vui lòng nhập tên table.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTableName.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(privateKey))
                {
                    MessageBox.Show("Vui lòng nhập khóa bí mật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEncryptKey.Focus();
                    return;
                }

                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn mã hóa toàn bộ table {tableName}?\r\nThao tác này sẽ mã hóa tất cả các cột VARCHAR2/NVARCHAR2.",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    txtResult.Text = $"Đang mã hóa toàn bộ table {tableName}...";
                    Application.DoEvents();

                    bool success = desOracle.EncryptEntireTable(tableName, privateKey);

                    if (success)
                    {
                        txtResult.Text = $"Mã hóa toàn bộ table {tableName} thành công!\r\nCác cột đã được mã hóa với suffix '_ENCRYPTED'";
                    }
                    else
                    {
                        txtResult.Text = $"Mã hóa toàn bộ table {tableName} thất bại!";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mã hóa table: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtResult.Text = "Lỗi: " + ex.Message;
            }
        }

        private void btnDecryptColumn_Click(object sender, EventArgs e)
        {
            try
            {
                string tableName = txtDecryptTable.Text.Trim().ToUpper();
                string columnName = txtDecryptColumn.Text.Trim().ToUpper();
                string privateKey = txtDecryptKey.Text.Trim();

                if (string.IsNullOrEmpty(tableName))
                {
                    MessageBox.Show("Vui lòng nhập tên table.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDecryptTable.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(columnName))
                {
                    MessageBox.Show("Vui lòng nhập tên cột gốc (không có _ENCRYPTED).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDecryptColumn.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(privateKey))
                {
                    MessageBox.Show("Vui lòng nhập khóa bí mật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDecryptKey.Focus();
                    return;
                }

                txtResult.Text = $"Đang giải mã cột {columnName} trong table {tableName}...";
                Application.DoEvents();

                bool success = desOracle.DecryptTableColumn(tableName, columnName, privateKey);

                if (success)
                {
                    txtResult.Text = $"Giải mã cột {columnName} trong table {tableName} thành công!\r\nCột giải mã: {columnName}_DECRYPTED";
                }
                else
                {
                    txtResult.Text = $"Giải mã cột {columnName} trong table {tableName} thất bại!";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi giải mã cột: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtResult.Text = "Lỗi: " + ex.Message;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTableName.Text = "SACH";
            txtColumnName.Text = "TENSACH";
            txtEncryptKey.Text = "PRIVATEKEY";
            txtDecryptTable.Text = "SACH";
            txtDecryptColumn.Text = "TENSACH";
            txtDecryptKey.Text = "PRIVATEKEY";
            txtResult.Text = "";
            txtTableName.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}