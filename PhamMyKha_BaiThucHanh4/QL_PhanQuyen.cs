using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
namespace PhamMyKha_BaiThucHanh4
{
    class QL_PhanQuyen
    {
        public static LoginEnum CheckLogin(string username, string password)
        {
          SqlDataAdapter daUser = new SqlDataAdapter("select * from NguoiDung where TenDangNhap='" + username + "' and MatKhau ='" + password + "'",
Properties.Settings.Default.LTWNCConn);
            DataTable dt = new DataTable(); 
            daUser.Fill(dt);

            if(dt.Rows.Count == 0)
            {
                return LoginEnum.Invalid;
            }
            else if(dt.Rows[0][2] == null || dt.Rows[0][2].ToString() == "False")
            {
                return LoginEnum.Disabled;
            }
            else
            {
                return LoginEnum.Success;
            }
            
        }

    }
}
