using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data;
using System.Windows.Forms;

namespace ConnectOracle
{
    public class DesOracle
    {
        OracleConnection conn;

        public DesOracle(OracleConnection conn)
        {
            this.conn = conn;
        }

        // Mã hóa dữ liệu trong một cột cụ thể của table
        public bool EncryptTableColumn(string tableName, string columnName, string privateKey)
        {
            try
            {
                // Tạo cột mới để lưu dữ liệu mã hóa
                string encryptedColumnName = columnName + "_ENCRYPTED";

                // Kiểm tra xem cột mã hóa đã tồn tại chưa
                string checkColumnSql = @"SELECT COUNT(*) FROM user_tab_columns 
                                         WHERE table_name = UPPER(:tableName) 
                                         AND column_name = UPPER(:columnName)";

                OracleCommand checkCmd = new OracleCommand(checkColumnSql, conn);
                checkCmd.Parameters.Add(":tableName", OracleDbType.Varchar2).Value = tableName;
                checkCmd.Parameters.Add(":columnName", OracleDbType.Varchar2).Value = encryptedColumnName;

                int columnExists = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (columnExists == 0)
                {
                    string alterSql = $"ALTER TABLE {tableName} ADD ({encryptedColumnName} RAW(2000))";
                    OracleCommand alterCmd = new OracleCommand(alterSql, conn);
                    alterCmd.ExecuteNonQuery();
                }

                // Mã hóa dữ liệu và cập nhật vào cột mới
                string updateSql = $@"UPDATE {tableName} 
                                     SET {encryptedColumnName} = DES.ENCRYPT({columnName}, '{privateKey}')
                                     WHERE {columnName} IS NOT NULL";

                OracleCommand cmd = new OracleCommand(updateSql, conn);
                int rowsAffected = cmd.ExecuteNonQuery();

                MessageBox.Show($"Đã mã hóa {rowsAffected} bản ghi trong cột {columnName} của table {tableName}");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mã hóa cột {columnName} trong table {tableName}: " + ex.Message);
                return false;
            }
        }

        // Giải mã dữ liệu trong một cột cụ thể của table
        public bool DecryptTableColumn(string tableName, string columnName, string privateKey)
        {
            try
            {
                string encryptedColumnName = columnName + "_ENCRYPTED";
                string decryptedColumnName = columnName + "_DECRYPTED";

                // Kiểm tra xem cột giải mã đã tồn tại chưa
                string checkColumnSql = @"SELECT COUNT(*) FROM user_tab_columns 
                                         WHERE table_name = UPPER(:tableName) 
                                         AND column_name = UPPER(:columnName)";

                OracleCommand checkCmd = new OracleCommand(checkColumnSql, conn);
                checkCmd.Parameters.Add(":tableName", OracleDbType.Varchar2).Value = tableName;
                checkCmd.Parameters.Add(":columnName", OracleDbType.Varchar2).Value = decryptedColumnName;

                int columnExists = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (columnExists == 0)
                {
                    string alterSql = $"ALTER TABLE {tableName} ADD ({decryptedColumnName} NVARCHAR2(500))";
                    OracleCommand alterCmd = new OracleCommand(alterSql, conn);
                    alterCmd.ExecuteNonQuery();
                }

                // Giải mã dữ liệu và cập nhật vào cột mới
                string updateSql = $@"UPDATE {tableName} 
                                     SET {decryptedColumnName} = DES.DECRYPT({encryptedColumnName}, '{privateKey}')
                                     WHERE {encryptedColumnName} IS NOT NULL";

                OracleCommand cmd = new OracleCommand(updateSql, conn);
                int rowsAffected = cmd.ExecuteNonQuery();

                MessageBox.Show($"Đã giải mã {rowsAffected} bản ghi trong cột {columnName} của table {tableName}");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi giải mã cột {columnName} trong table {tableName}: " + ex.Message);
                return false;
            }
        }

        // Mã hóa toàn bộ table (tất cả các cột VARCHAR2/NVARCHAR2)
        public bool EncryptEntireTable(string tableName, string privateKey)
        {
            try
            {
                // Lấy danh sách các cột có thể mã hóa
                string sql = @"SELECT column_name 
                              FROM user_tab_columns 
                              WHERE table_name = UPPER(:tableName) 
                              AND data_type IN ('VARCHAR2', 'NVARCHAR2', 'CHAR', 'NCHAR')
                              AND column_name NOT LIKE '%_ENCRYPTED'
                              AND column_name NOT LIKE '%_DECRYPTED'
                              ORDER BY column_id";

                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.Parameters.Add(":tableName", OracleDbType.Varchar2).Value = tableName;

                List<string> encryptableColumns = new List<string>();
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    encryptableColumns.Add(reader.GetString(reader.GetOrdinal("column_name")));
                }
                reader.Close();

                if (encryptableColumns.Count == 0)
                {
                    MessageBox.Show($"Không tìm thấy cột nào có thể mã hóa trong table {tableName}");
                    return false;
                }

                int successCount = 0;
                foreach (string columnName in encryptableColumns)
                {
                    // Sửa lại: gọi với 3 tham số thay vì 4
                    if (EncryptTableColumn(tableName, columnName, privateKey))
                    {
                        successCount++;
                    }
                }

                MessageBox.Show($"Đã mã hóa thành công {successCount}/{encryptableColumns.Count} cột trong table {tableName}");
                return successCount > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mã hóa toàn bộ table {tableName}: " + ex.Message);
                return false;
            }
        }
    }
}