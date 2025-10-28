using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;
namespace ConnectOracle
{
    public class Database
    {
        public static OracleConnection Conn;
        public static string Host;
        public static string Port;
        public static string Sid;
        public static string User;
        public static string PassWord;

        public static void Set_Database(string host,string port,string sid,string user,string pass)
        {
            Database.Host = host;
            Database.Port = port;
            Database.Sid = sid;
            OracleConnectionStringBuilder builder = new OracleConnectionStringBuilder
            {
                UserID = "your_username",
                Password = "your_password",
                DataSource = "your_datasource"
            };
            string connectionString = builder.ConnectionString;
            Database.User = user;
            Database.PassWord = pass;
        }

        public static bool Connect()
        {
            string connsys = "";
            try
            {
                if(User.ToUpper().Equals("SYS"))
                {
                    connsys = ";DBA Privilege=SYSDBA;";
                }
                string connString = "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = " + Host + ")(PORT = " + Port + "))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = " + Sid + ")));User ID=" + User + " ; Password = " + PassWord + connsys;

                Conn = new OracleConnection();
                Conn.ConnectionString = connString;
                Conn.Open();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static OracleConnection Get_Connect()
        {
            return Conn;
        }

        public static bool IsConnected()
        {
            return Conn != null && Conn.State == System.Data.ConnectionState.Open;
        }

        public static void Disconnect()
        {
            if (Conn != null && Conn.State == System.Data.ConnectionState.Open)
            {
                Conn.Close();
                Conn.Dispose();
                Conn = null;
            }
        }
    }
}
