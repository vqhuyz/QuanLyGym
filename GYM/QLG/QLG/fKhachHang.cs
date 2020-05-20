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
using DevExpress.XtraReports.UI;

namespace QLG
{
    public partial class fKhachHang : DevExpress.XtraEditors.XtraForm
    {
        KhachHang kh;
        public fKhachHang()
        {
            InitializeComponent();
            kh = new KhachHang();
            string loaitaikhoan = fDangNhap.LoaiTK;

            if (loaitaikhoan == "user" || loaitaikhoan == "USER")
            {
                menuStrip1.Visible = false;
            }
            hienthicombo();
            hienthidata();
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

        void clear()
        {
            txtGia.Clear();
            txtMaNV.Clear(); 
            txtSDT.Clear();
            txtTenGT.Clear();
            txtTenKH.Clear();
            cboMaGT.Text = "";
            
        }

        void hienthicombo()
        {
            DataTable dt = kh.LoadComBo();
            cboMaGT.DataSource = dt;
            cboMaGT.DisplayMember = "MaGT";
        }

        void hienthidata()
        {
            SetGridViewStyle(dtgvKH);
            DataTable data = kh.LayDSKhachHang();
            dtgvKH.DataSource = data;
        }

        private void cboMaGT_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = kh.LoadTextBox(cboMaGT.Text);
            foreach (DataRow dr in dt.Rows)
            {
                txtTenGT.Text = dr["TenGT"].ToString();
                txtGia.Text = dr["Gia"].ToString();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialog = MessageBox.Show("Bạn chắc chắn muốn xóa khách hàng này?", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialog == DialogResult.OK)
                {
                    kh.XoaKhachHang(lblID.Text);
                    MessageBox.Show("Đã xóa khách hàng được chọn");
                    hienthidata();
                    clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                    kh.CapNhatKhachHang(txtTenKH.Text,cboMaGT.Text, txtGia.Text, txtSDT.Text,lblID.Text);
                    MessageBox.Show("Cập nhật khách hàng thành công");
                    hienthidata();
                    clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            lblNgayTap.Text = time.ToString();
            if (txtTenKH.Text == "" || cboMaGT.Text == "" || txtSDT.Text == "" || txtMaNV.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin");
            }
            else
            {
                try
                {
                    kh.ThemKhachHang(txtMaNV.Text,txtTenKH.Text,txtSDT.Text,cboMaGT.Text,txtGia.Text,lblNgayTap.Text);
                    MessageBox.Show("Thêm khách hàng mới thành công");
                    hienthidata();
                    clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dtgvKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dtgvKH.SelectedRows)
                {
                    lblID.Text = row.Cells[0].Value.ToString();
                    txtMaNV.Text = row.Cells[1].Value.ToString();
                    txtTenKH.Text = row.Cells[2].Value.ToString();
                    txtSDT.Text = row.Cells[3].Value.ToString();
                    cboMaGT.Text = row.Cells[4].Value.ToString();
                    txtGia.Text = row.Cells[5].Value.ToString();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = kh.LayDSKhachHang();
            DataView dv = new DataView(dt);
            dv.RowFilter = " TenKH like '%" + txtTim.Text + "%' ";
            dtgvKH.DataSource = dv;
        }

        private void báoCáoDoanhSốTheoNgàyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rpKhachHang rp = new rpKhachHang();
            rp.ShowPreviewDialog();
        }
    }
}