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

        public byte[] EncryptDES(string plaintext, string prikey)
        {
            OracleConnection conn;
            try
            {
                string Function = "DES.ENCRYPT";

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = Function;
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter resultParam = new OracleParameter();
                resultParam.ParameterName = "@Result";
                resultParam.OracleDbType = OracleDbType.Raw;
                resultParam.Size = 500;
                resultParam.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(resultParam);

                OracleParameter str = new OracleParameter();
                str.ParameterName = "@P_PLAINTEXT";
                str.OracleDbType = OracleDbType.Varchar2;
                str.Value = plaintext;
                str.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(str);

                OracleParameter k = new OracleParameter();
                k.ParameterName = "@PRIKEY";
                k.OracleDbType = OracleDbType.Varchar2;
                k.Value = prikey;
                k.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(k);

                cmd.ExecuteNonQuery();

                if (resultParam.Value != DBNull.Value)
                {
                    OracleBinary ret = (OracleBinary)resultParam.Value;
                    return (byte[])ret.Value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetBaseException().ToString());
            }

            return null;
        }

        public byte[] DecryptDES(byte[] Encrypted, string prikey)
        {
            try
            {
                string Function = "DES.DECRYPT";

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = Function;
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter resultParam = new OracleParameter();
                resultParam.ParameterName = "@RESULT";
                resultParam.OracleDbType = OracleDbType.Varchar2;
                resultParam.Size = 100;
                resultParam.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(resultParam);

                OracleParameter str = new OracleParameter();
                str.ParameterName = "@P_ENCRYPTEDTEXT";
                str.OracleDbType = OracleDbType.Raw;
                str.Value = Encrypted;
                str.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(str);

                OracleParameter k = new OracleParameter();
                k.ParameterName = "@PRIKEY";
                k.OracleDbType = OracleDbType.Varchar2;
                k.Value = prikey;
                k.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(k);

                cmd.ExecuteNonQuery();

                if (resultParam.Value != DBNull.Value)
                {
                    OracleBinary ret = (OracleBinary)resultParam.Value;
                    return (byte[])ret.Value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetBaseException().ToString());
            }

            return null;
        }
    }
}
