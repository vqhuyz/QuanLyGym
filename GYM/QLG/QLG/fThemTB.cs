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
using System.IO;

namespace QLG
{
    public partial class fThemTB : DevExpress.XtraEditors.XtraForm
    {
        ThietBi tb;
        public fThemTB()
        {
            InitializeComponent();
            tb = new ThietBi();
        }

        string img = "";

        private void ptbThietBi_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png file(*png)|*.png|jpg files(*jpg)|*.jpg|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                img = dialog.FileName.ToString();
                ptbThietBi.ImageLocation = img;
            }
        }

        public string LuuAnh()
        {
            string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
            File.Copy(img, path + "\\img\\" + txtMaTB.Text);
            string tenanh = "\\img\\" + txtMaTB.Text;
            return tenanh;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTenTB.Text == "" || txtTinhTrang.Text == "" || txtSoLuong.Text == "" || txtMaTB.Text == "" ||
                txtLoai.Text == "" || txtSoLuongHu.Text == "" || ptbThietBi.Image == null)
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin");
            }
            else
            {
                try
                {
                    tb.ThemThietBi(txtMaTB.Text, txtTenTB.Text, txtLoai.Text, txtSoLuong.Text, txtHangSX.Text, txtSoLuongHu.Text,txtTinhTrang.Text,rtbGhiChu.Text, LuuAnh());
                    MessageBox.Show("Đã thêm một thiết bị mới!!");
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
            txtMaTB.Clear();
            txtLoai.Clear();
            txtSoLuongHu.Clear();
            txtSoLuong.Clear();
            txtTenTB.Clear();
            txtTinhTrang.Clear();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}