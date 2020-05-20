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
    public partial class fBanSP : DevExpress.XtraEditors.XtraForm
    {
        SanPham sp;
        public fBanSP()
        {
            InitializeComponent();
            sp = new SanPham();
            TruyenGiaTri();
        }

        void TruyenGiaTri()
        {
            txtMaSP.Text = fSanPham.masp.ToString();
            txtTenSP.Text = fSanPham.tensp.ToString();
            txtSoLuong.Text = fSanPham.soluong.ToString();
            txtDonGia.Text = fSanPham.dongia.ToString();
        }

        private void txtKhachMua_TextChanged(object sender, EventArgs e)
        {
            double soluong = double.Parse(txtSoLuong.Text);
            double khachmua = double.Parse(txtKhachMua.Text);
            double dongia = double.Parse(txtDonGia.Text);

            txtThanhTien.Text = (khachmua * dongia).ToString();
            txtSoLuongCon.Text = (soluong - khachmua).ToString();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                    sp.BanHang(txtMaSP.Text, txtSoLuongCon.Text);
                    MessageBox.Show("Thanh toán thành công!!");
                    this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}