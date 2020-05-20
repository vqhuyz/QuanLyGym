using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLG.CLASS;

namespace QLG
{
    public partial class fDangNhap : DevExpress.XtraEditors.XtraForm
    {
        Database db;
        DangNhap dn;

        public fDangNhap()
        {
            InitializeComponent();
            db = new Database();
            dn = new DangNhap();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        string Login(string taikhoan, string matkhau)
        {
            return dn.Login(taikhoan, matkhau);
        }

        public static string LoaiTK = "";

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            LoaiTK = dn.Login(txtTaiKhoan.Text, txtMatKhau.Text);
            try
            {
                if (txtTaiKhoan.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập tài khoản!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTaiKhoan.Focus();
                }
                else if (txtMatKhau.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMatKhau.Focus();
                }
                else if (LoaiTK != "")
                {
                    fTrangChu f = new fTrangChu();
                    this.Hide();
                    f.ShowDialog();
                    this.Show();
                }
                else
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/vqhuyz");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/HuyN69554097");
        }
    }
}