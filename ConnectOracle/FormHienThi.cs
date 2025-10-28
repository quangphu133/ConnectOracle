using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace ConnectOracle
{
    public partial class FormHienThi : Form
    {
        private string _currentUser = null;

        public FormHienThi()
        {
            InitializeComponent();
            this.Load += FormHienThi_Load;
            this.cboOwner.SelectedIndexChanged += cboOwner_SelectedIndexChanged;
        }

        private void FormHienThi_Load(object sender, EventArgs e)
        {
            try
            {
                var conn = ConnectOracle.Database.Get_Connect();

                // Get current oracle user (unquoted identifier, usually uppercase)
                using (var cmd = new OracleCommand("SELECT USER FROM DUAL", conn))
                {
                    _currentUser = cmd.ExecuteScalar()?.ToString();
                }

                if (string.IsNullOrWhiteSpace(_currentUser))
                {
                    MessageBox.Show("Không lấy được thông tin user hiện tại.");
                    return;
                }

                // Bind owner combobox to the current user only and disable it
                var owners = new DataTable();
                owners.Columns.Add("OWNER", typeof(string));
                owners.Rows.Add(_currentUser);
                cboOwner.DisplayMember = "OWNER";
                cboOwner.ValueMember = "OWNER";
                cboOwner.DataSource = owners;
                cboOwner.Enabled = false;

                // Load tables for current user
                LoadTablesForOwner();
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Lỗi Oracle: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void cboOwner_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Even though owner is fixed/disabled, keep this for safety
            LoadTablesForOwner();
        }

        private void LoadTablesForOwner()
        {
            try
            {
                var conn = ConnectOracle.Database.Get_Connect();
                if (conn == null || conn.State != System.Data.ConnectionState.Open)
                {
                    MessageBox.Show("Không thể kết nối Oracle. Vui lòng đăng nhập trước khi tải dữ liệu.");
                    return;
                }

                // Restrict to current user’s tables
                using (var da = new OracleDataAdapter(
                    "SELECT TABLE_NAME FROM USER_TABLES ORDER BY TABLE_NAME", conn))
                {
                    var dt = new DataTable();
                    da.Fill(dt);
                    cboTable.DisplayMember = "TABLE_NAME";
                    cboTable.ValueMember = "TABLE_NAME";
                    cboTable.DataSource = dt;
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Lỗi Oracle khi tải danh sách bảng: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách bảng: " + ex.Message);
            }
        }

        private static bool IsValidOracleUnquotedIdentifier(string name)
        {
            // Start with a letter, up to 30 chars, A-Z 0-9 _ $ #
            return Regex.IsMatch(name, "^[A-Za-z][A-Za-z0-9_$#]{0,29}$");
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                OracleConnection conn = ConnectOracle.Database.Get_Connect();
                if (conn == null || conn.State != System.Data.ConnectionState.Open)
                {
                    MessageBox.Show("Không thể kết nối Oracle. Vui lòng đăng nhập trước khi tải dữ liệu.");
                    return;
                }

                string table = cboTable?.SelectedValue?.ToString();

                if (string.IsNullOrWhiteSpace(table))
                {
                    MessageBox.Show("Vui lòng chọn bảng.");
                    return;
                }

                if (!IsValidOracleUnquotedIdentifier(_currentUser) || !IsValidOracleUnquotedIdentifier(table))
                {
                    MessageBox.Show("Tên bảng hoặc user không hợp lệ.");
                    return;
                }

                // Query only from current user’s schema
                string query = $"SELECT * FROM {_currentUser}.{table.ToUpperInvariant()}";

                var dt = new DataTable();
                using (var da = new OracleDataAdapter(query, conn))
                {
                    da.Fill(dt);
                }

                dataGridView1.DataSource = dt;
            }
            catch (OracleException ex)
            {
                string msg = ex.Message;
                if (msg.Contains("ORA-00942"))
                {
                    msg += "\nGợi ý: Kiểm tra quyền truy cập hoặc bảng có tồn tại trong schema hiện tại không.";
                }
                MessageBox.Show("Lỗi Oracle: " + msg);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        // In case Designer accidentally wired this
        private void Form1_Load(object sender, EventArgs e) { }

        private void label1_Click(object sender, EventArgs e) { }
    }
}
