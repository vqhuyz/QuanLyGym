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
using System.IO;
using QLG.CLASS;

namespace QLG
{
    public partial class fThemSP : DevExpress.XtraEditors.XtraForm
    {
        SanPham sp;
        public fThemSP()
        {
            InitializeComponent();
            sp = new SanPham();
            DateTime time = DateTime.Now;
            dateNgayNhap.Text = time.ToString(); 
        }

        string img = "";

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png file(*png)|*.png|jpg files(*jpg)|*.jpg|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                img = dialog.FileName.ToString();
                ptbSanPham.ImageLocation = img;
            }
        }

        public string LuuAnh()
        {
            string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
            File.Copy(img, path + "\\img\\" + txtMaSP.Text);
            string tenanh = "\\img\\" + txtMaSP.Text;
            return tenanh;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTenSP.Text == "" || txtTrongLuong.Text == "" || txtSoLuong.Text == "" || txtMaSP.Text == "" ||
                txtLoai.Text == "" || txtDonGia.Text == "" || dateNgayNhap.Text == "" || ptbSanPham.Image == null)
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin");
            }
            else
            {
                try
                {
                    sp.ThemSanPham(txtMaSP.Text, txtTenSP.Text, txtLoai.Text, dateNgayNhap.Text, txtSoLuong.Text, txtDonGia.Text, txtTrongLuong.Text, LuuAnh());
                    MessageBox.Show("Đã thêm một sản phẩm mới");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaSP.Clear();
            txtLoai.Clear();
            txtDonGia.Clear();
            txtSoLuong.Clear();
            txtTenSP.Clear();
            txtTrongLuong.Clear();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}