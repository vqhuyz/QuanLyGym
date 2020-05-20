using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLG
{
    public partial class fTrangChu : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public fTrangChu()
        {
            InitializeComponent();

            string loaitaikhoan = fDangNhap.LoaiTK;

            if (loaitaikhoan == "user" || loaitaikhoan == "USER")
            {
                btnNhanVien.Visible = false;
                btnTaiKhoan.Visible = false;
                btnGoiTap.Visible = false;
            }

            fInfo f = new fInfo();
            if (ExistForm(f))
                return;
            f.MdiParent = this;
            f.Show();

            SidePanel.Height = btnHome.Height;
            SidePanel.Top = btnHome.Top;

        }

        private bool ExistForm(XtraForm f)
        {
            foreach (var child in MdiChildren)
            {
                if (child.Name == f.Name)
                {
                    child.Activate();
                    return true;
                }
            }
            return false;
        }

        private void btnHoiVien_Click_1(object sender, EventArgs e)
        {
            SidePanel.Height = btnHoiVien.Height;
            SidePanel.Top = btnHoiVien.Top;
            fThanhVien f = new fThanhVien();
            if (ExistForm(f))
                return;
            f.MdiParent = this;
            f.Show();
        }

        private void btnDungCu_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnDungCu.Height;
            SidePanel.Top = btnDungCu.Top;
            fThietBi f = new fThietBi();
            if (ExistForm(f))
                return;
            f.MdiParent = this;
            f.Show();
        }


        private void btnHome_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnHome.Height;
            SidePanel.Top = btnHome.Top;
            fInfo f = new fInfo();
            if (ExistForm(f))
                return;
            f.MdiParent = this;
            f.Show();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnKhachHang.Height;
            SidePanel.Top = btnKhachHang.Top;
            fKhachHang f = new fKhachHang();
            if (ExistForm(f))
                return;
            f.MdiParent = this;
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/vqhuyz");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/HuyN69554097");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnSanPham.Height;
            SidePanel.Top = btnSanPham.Top;
            fSanPham f = new fSanPham();
            if (ExistForm(f))
                return;
            f.MdiParent = this;
            f.Show();
        }


        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnTaiKhoan.Height;
            SidePanel.Top = btnTaiKhoan.Top;
            fDSTaiKhoan f = new fDSTaiKhoan();
            if (ExistForm(f))
                return;
            f.MdiParent = this;
            f.Show();
        }

        private void btnGoiTap_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnGoiTap.Height;
            SidePanel.Top = btnGoiTap.Top;
            fGoiTap f = new fGoiTap();
            if (ExistForm(f))
                return;
            f.MdiParent = this;
            f.Show();
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnNhanVien.Height;
            SidePanel.Top = btnNhanVien.Top;
            fNhanVien f = new fNhanVien();
            if (ExistForm(f))
                return;
            f.MdiParent = this;
            f.Show();
        }
    }
}
