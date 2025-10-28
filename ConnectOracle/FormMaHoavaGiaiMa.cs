using System;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace ConnectOracle
{
    public partial class FormMaHoavaGiaiMa : Form
    {
        public FormMaHoavaGiaiMa()
        {
            InitializeComponent();
        }
        private string CallOracleFunction(string functionName, string str, int key)
        {
            // Fallback connection string (giữ nguyên)
            string fallbackConnStr = "User Id=MaHoavaGiaiMa;Password=123;Data Source=localhost:1521/orcl;";

            OracleConnection conn = null;
            bool disposeConn = false;

            try
            {
                if (Database.IsConnected())
                {
                    conn = Database.Get_Connect();
                }
                else
                {
                    conn = new OracleConnection(fallbackConnStr);
                    conn.Open();
                    disposeConn = true;
                }

                using (var cmd = conn.CreateCommand())
                {
                    cmd.BindByName = true;
                    cmd.CommandText = $"SELECT {functionName}(:str, :key) FROM dual";
                    cmd.Parameters.Add(":str", OracleDbType.Varchar2).Value = str ?? string.Empty;
                    cmd.Parameters.Add(":key", OracleDbType.Int32).Value = key;

                    object result = cmd.ExecuteScalar();
                    return result?.ToString() ?? string.Empty;
                }
            }
            finally
            {
                if (disposeConn)
                {
                    conn?.Dispose();
                }
            }
        }

        private bool TryGetKey(out int key)
        {
            if (!int.TryParse(txtKey.Text, out key))
            {
                MessageBox.Show("Khóa phải là số nguyên.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKey.Focus();
                return false;
            }
            return true;
        }

        private void btnEncodeAdd_Click(object sender, EventArgs e)
        {
            if (!TryGetKey(out int key)) return;

            try
            {
                string input = txtInput.Text;
                txtEncodedAdd.Text = CallOracleFunction("encode_add", input, key);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mã hóa (cộng): {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDecodeAdd_Click(object sender, EventArgs e)
        {
            if (!TryGetKey(out int key)) return;

            try
            {
                string encoded = txtEncodedAdd.Text;
                txtDecodedAdd.Text = CallOracleFunction("decode_add", encoded, key);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi giải mã (cộng): {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEncodeMul_Click(object sender, EventArgs e)
        {
            if (!TryGetKey(out int key)) return;

            try
            {
                string input = txtInput.Text;
                txtEncodedMul.Text = CallOracleFunction("encode_mul", input, key);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mã hóa (nhân): {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDecodeMul_Click(object sender, EventArgs e)
        {
            if (!TryGetKey(out int key)) return;

            try
            {
                string encoded = txtEncodedMul.Text;
                txtDecodedMul.Text = CallOracleFunction("decode_mul", encoded, key);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi giải mã (nhân): {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}