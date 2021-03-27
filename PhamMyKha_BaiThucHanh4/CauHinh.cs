using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.IO;


namespace PhamMyKha_BaiThucHanh4
{
    class CauHinh
    {
        public static int Check_Config()
        {
            if (Properties.Settings.Default.LTWNCConn == string.Empty)
                return 1;

            SqlConnection _Sqlconn = new

            SqlConnection(Properties.Settings.Default.LTWNCConn);
            try
            {
                if (_Sqlconn.State == System.Data.ConnectionState.Closed)
                    _Sqlconn.Open();
                return 0;
            }
            catch
            {
                return 2;
            }
        }

        public static DataTable GetDataBaseName(string server, string user, string pass)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select name from sys.Databases",
            "Data Source=" + server + ";Initial Catalog=master;User ID=" + user + ";pwd = " +
            pass + "");
            da.Fill(dt);
            return dt;
        }

        public static void SaveConfig(string server, string user, string pass, string table)
        {
            string str = "Data Source = " + server + "; Initial Catalog = " + table + "; User ID = " + user + "; Password = " + pass;
            Properties.Settings.Default.LTWNCConn = str;
            Properties.Settings.Default.Save();
        }
    }
}
