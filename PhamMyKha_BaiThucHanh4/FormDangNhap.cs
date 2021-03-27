using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhamMyKha_BaiThucHanh4
{
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void FormDangNhap_Load(object sender, EventArgs e)
        {
          
            
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenNguoiDung.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống" + lblTenNguoiDung.Text.ToLower());
                this.txtTenNguoiDung.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtMatKhau.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống" + lblMatKhau.Text.ToLower());
                this.txtMatKhau.Focus();
                return;
            }
            //Kiem tra ket noi
            int kq = CauHinh.Check_Config();
            if(kq == 1 || kq == 2)
            {
                this.Hide();
                FormCauHinh cauHinh = new FormCauHinh();
                cauHinh.ShowDialog();
            }
            else
            {
                LoginEnum result = QL_PhanQuyen.CheckLogin(txtTenNguoiDung.Text, txtMatKhau.Text);
                if(result == LoginEnum.Invalid)
                {
                    MessageBox.Show("Tai khoan hoac password khong dung");
                    return;
                }
                else if(result == LoginEnum.Disabled)
                {
                    MessageBox.Show("Tai khoan bi khoa");
                    return;
                }
                else
                {
                    this.Hide();
                    FormMain formMain = new FormMain();
                    formMain.ShowDialog();
                }
            }
        }
    }
}
