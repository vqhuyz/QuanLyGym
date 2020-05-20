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
    public partial class fCapNhatTB : DevExpress.XtraEditors.XtraForm
    {
        ThietBi tb;
        public fCapNhatTB()
        {
            InitializeComponent();
            TruyenGiaTri();
            string loaitaikhoan = fDangNhap.LoaiTK;

            if (loaitaikhoan == "user" || loaitaikhoan == "USER")
            {
                txtTenTB.ReadOnly = true;
                txtLoai.ReadOnly = true;
                txtSoLuong.ReadOnly = true;
            }
            tb = new ThietBi();
        }

        void TruyenGiaTri()
        {
            txtMaTB.Text = fThietBi.matb.ToString();
            txtTenTB.Text = fThietBi.tentb.ToString();
            txtLoai.Text = fThietBi.loai.ToString();
            txtSoLuong.Text = fThietBi.soluong.ToString();
            txtTinhTrang.Text = fThietBi.tinhtrang.ToString();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                    tb.CapNhatThietBi(txtMaTB.Text, txtTenTB.Text, txtLoai.Text, txtSoLuong.Text, txtSoLuongHu.Text ,txtTinhTrang.Text, rtbGhichu.Text);
                    MessageBox.Show("Cập nhật thiết bị thành công!!");
                    this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTinhTrang.Clear();
            txtTenTB.Clear();
            txtSoLuongHu.Clear();
            txtSoLuong.Clear();
            txtMaTB.Clear();
            txtLoai.Clear();
            rtbGhichu.Clear();
        }
    }
}