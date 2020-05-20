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
    public partial class fThietBi : DevExpress.XtraEditors.XtraForm
    {
        ThietBi tb;
        public fThietBi()
        {
            InitializeComponent();
            tb = new ThietBi();

            string loaitaikhoan = fDangNhap.LoaiTK;

            if (loaitaikhoan == "user" || loaitaikhoan == "USER")
            {
                groupBox1.Visible = false;
            }
            else
                btnNvCapNhat.Visible = false;
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
            SetGridViewStyle(dtgvThietBi);
            DataTable dt = tb.LayDSThietBi();
            dtgvThietBi.DataSource = dt;
        }

        void clear()
        {
            txtHangSX.Clear();
            txtLoai.Clear();
            txtMaTB.Clear();
            txtSoLuong.Clear();
            txtTenTB.Clear();
            lblTinhTrang.Text = "";
            ptbThietBi.Image = null;
        }

        public static string matb = "";
        public static string tentb = "";
        public static string loai = "";
        public static string soluong = "";
        public static string hangsx = "";
        public static string tinhtrang = "";


        private void dtgvThietBi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dtgvThietBi.SelectedRows)
                {
                    txtMaTB.Text = row.Cells[0].Value.ToString();
                    txtTenTB.Text = row.Cells[1].Value.ToString();
                    txtLoai.Text = row.Cells[2].Value.ToString();
                    txtHangSX.Text = row.Cells[4].Value.ToString();
                    txtSoLuong.Text = row.Cells[3].Value.ToString();
                    lblTinhTrang.Text = row.Cells[6].Value.ToString();

                }

                matb = txtMaTB.Text;
                tentb = txtTenTB.Text;
                loai = txtLoai.Text;
                soluong = txtSoLuong.Text;
                hangsx = txtHangSX.Text;
                tinhtrang = lblTinhTrang.Text;

                int selected = dtgvThietBi.SelectedCells[0].RowIndex;
                DataGridViewRow selectedrow = dtgvThietBi.Rows[selected];
                string hinhanh = Convert.ToString(selectedrow.Cells["HinhAnh"].Value);
                string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                ptbThietBi.Image = Image.FromFile(path + hinhanh);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = tb.LayDSThietBi();
            DataView dv = new DataView(dt);
            dv.RowFilter = " TenTB like '%" + txtTim.Text + "%' ";
            dtgvThietBi.DataSource = dv;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialog = MessageBox.Show("Bạn chắc chắn muốn xóa thiết bị này?", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialog == DialogResult.OK)
                {
                    tb.XoaThietBI(txtMaTB.Text);
                    MessageBox.Show("Xóa thiết bị được chọn thành công !!");
                    clear();
                    hienthi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            fThemTB f = new fThemTB();
            f.ShowDialog();
            hienthi();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            fCapNhatTB f = new fCapNhatTB();
            f.ShowDialog();
            clear();
            hienthi();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string duongdan;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    duongdan = saveFileDialog1.FileName;
                    fNhanVien.xuatExcel(dtgvThietBi, duongdan);
                    MessageBox.Show("Đã xuất file!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNvCapNhat_Click(object sender, EventArgs e)
        {
            fCapNhatTB f = new fCapNhatTB();
            f.ShowDialog();
            clear();
            hienthi();
        }
    }
}