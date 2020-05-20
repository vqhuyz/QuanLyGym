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
    public partial class fCapNhatSP : DevExpress.XtraEditors.XtraForm
    {
        SanPham sp;
        public fCapNhatSP()
        {
            InitializeComponent();
            sp = new SanPham();
            TruyenGiaTri();
        }

        void TruyenGiaTri()
        {
            txtMaSP.Text = fSanPham.masp.ToString();
            txtTenSP.Text = fSanPham.tensp.ToString();
            txtLoai.Text = fSanPham.loai.ToString();
            txtSoLuong.Text = fSanPham.soluong.ToString();
            txtDonGia.Text = fSanPham.dongia.ToString();
            txtTrongLuong.Text = fSanPham.trongluon.ToString();
            dateNgayNhap.Text = fSanPham.ngay.ToString();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                    sp.CapNhatSanPham(txtMaSP.Text, txtTenSP.Text, txtLoai.Text, txtSoLuong.Text, txtDonGia.Text,txtTrongLuong.Text, dateNgayNhap.Text);
                    MessageBox.Show("Cập nhật sản phẩm thành công!!");
                    this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtDonGia.Clear();
            txtLoai.Clear();
            txtSoLuong.Clear();
            txtTenSP.Clear();
            txtTrongLuong.Clear();
            dateNgayNhap.Text = "";
        }
    }
}