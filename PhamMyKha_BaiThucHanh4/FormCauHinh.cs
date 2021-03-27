using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.Sql;
namespace PhamMyKha_BaiThucHanh4
{
    public partial class FormCauHinh : Form
    {
        public FormCauHinh()
        {
            InitializeComponent();
        }

        private void FormCauHinh_Load(object sender, EventArgs e)
        {
            cboServerName.DataSource = GetServerName();
            cboServerName.DisplayMember = "ServerName";
        }
        public DataTable GetServerName()
        {
            DataTable dt = new DataTable();
            dt = SqlDataSourceEnumerator.Instance.GetDataSources();
            return dt;
        }

        private void cboDatabase_MouseClick(object sender, MouseEventArgs e)
        {
            DataTable dt = CauHinh.GetDataBaseName(cboServerName.Text, txtUserName.Text, txtPassword.Text);
            cboDatabase.DataSource = dt;
            cboDatabase.DisplayMember = "name";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            CauHinh.SaveConfig(cboServerName.Text, txtUserName.Text, txtPassword.Text, cboDatabase.Text);
            this.Hide();
            FormDangNhap formDangNhap = new FormDangNhap();
            formDangNhap.ShowDialog();
        }
    }
}
