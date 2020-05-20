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
    public partial class fSanPham : DevExpress.XtraEditors.XtraForm
    {
        SanPham sp;
        public fSanPham()
        {
            sp = new SanPham();
            InitializeComponent();

            string loaitaikhoan = fDangNhap.LoaiTK;

            if (loaitaikhoan == "user" || loaitaikhoan == "USER")
            {
                groupBox1.Visible = false;
            }
            hienthi();
        }

        public void SetGridViewStyle(DataGridView dgview)
        {
            dgview.BorderStyle = BorderStyle.None;
            dgview.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgview.BackgroundColor = Color.White;
            dgview.EnableHeadersVisualStyles = false;
            dgview.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgview.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 39, 40);
            dgview.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgview.AllowUserToDeleteRows = false;
            dgview.AllowUserToAddRows = false;
            dgview.AllowUserToOrderColumns = true;
            dgview.MultiSelect = false;
            dgview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        void hienthi()
        {
            SetGridViewStyle(dtgvSanPham);
            DataTable dt = sp.LayDSSanPham();
            dtgvSanPham.DataSource = dt;
            
        }
        void clear()
        {
            txtDonGia.Clear();
            txtLoai.Clear();
            txtMaSP.Clear();
            txtSoLuong.Clear();
            txtTenSP.Clear();
            lblTinhTrang.Text = "";
            ptbSanPham.Image = null ;
        }

        public static string masp = "";
        public static string tensp = "";
        public static string loai = "";
        public static string ngaynhap = "";
        public static string soluong = "";
        public static string dongia = "";
        public static string trongluon = "";
        public static string ngay = "";

        private void dtgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dtgvSanPham.SelectedRows)
                {
                    txtTenSP.Text = row.Cells[1].Value.ToString();
                    txtLoai.Text = row.Cells[2].Value.ToString();
                    txtDonGia.Text = row.Cells[5].Value.ToString();
                    txtSoLuong.Text = row.Cells[4].Value.ToString();
                    txtMaSP.Text = row.Cells[0].Value.ToString();
                    trongluon = row.Cells[6].Value.ToString();
                    ngay = row.Cells[3].Value.ToString();
                }

                masp = txtMaSP.Text;
                tensp = txtTenSP.Text;
                loai = txtLoai.Text;
                dongia = txtDonGia.Text;
                soluong = txtSoLuong.Text;

                int sl = Convert.ToInt32(txtSoLuong.Text);

                if (sl > 0)
                {
                    lblTinhTrang.Text = "Còn hàng";
                }
                else
                    lblTinhTrang.Text = "Hết hàng";

                int selected = dtgvSanPham.SelectedCells[0].RowIndex;
                DataGridViewRow selectedrow = dtgvSanPham.Rows[selected];
                string hinhanh = Convert.ToString(selectedrow.Cells["HinhAnh"].Value);
                string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                ptbSanPham.Image = Image.FromFile(path + hinhanh);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = sp.LayDSSanPham();
            DataView dv = new DataView(dt);
            dv.RowFilter = " TenSP like '%" + txtTim.Text + "%' ";
            dtgvSanPham.DataSource = dv;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            fThemSP f = new fThemSP();
            f.ShowDialog();
            hienthi();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            fCapNhatSP f = new fCapNhatSP();
            f.ShowDialog();
            clear();
            hienthi();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialog = MessageBox.Show("Bạn chắc chắn muốn xóa sản phẩm này?", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialog == DialogResult.OK)
                {
                    sp.XoaSanPham(txtMaSP.Text);
                    MessageBox.Show("Xóa sản phẩm thành công !!");
                    clear();
                    hienthi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string duongdan;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    duongdan = saveFileDialog1.FileName;
                    fNhanVien.xuatExcel(dtgvSanPham, duongdan);
                    MessageBox.Show("Đã xuất file!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            fBanSP f = new fBanSP();
            f.ShowDialog();
            clear();
            hienthi();
        }
    }
}