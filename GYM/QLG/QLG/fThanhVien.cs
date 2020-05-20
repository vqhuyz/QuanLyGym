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
    public partial class fThanhVien : DevExpress.XtraEditors.XtraForm
    {
        ThanhVien tv;
        public fThanhVien()
        {
            InitializeComponent();
            tv = new ThanhVien();
            string loaitaikhoan = fDangNhap.LoaiTK;

            if (loaitaikhoan == "user" || loaitaikhoan == "USER")
            {
                btnExcel.Visible = false;
            }
            hienthidata();
            hienthicombo();
        }

        void hienthicombo()
        {
            DataTable dt = tv.LoadComBo();
            cboMaGT.DataSource = dt;
            cboMaGT.DisplayMember = "MaGT";
            DateTime time = DateTime.Now;
            dateNgayDK.Text = time.ToString();
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

        void hienthidata()
        {
            SetGridViewStyle(dtgvThanhVien);
            DataTable data = tv.LayDSThanhVien();
            dtgvThanhVien.DataSource = data;

        }

        void clear()
        {
            txtHocPhi.Clear();
            txtMaNV.Clear();
            txtMaTV.Clear();
            txtSoDT.Clear();
            txtTenGT.Clear();
            txtTenTV.Clear();
            cboGioiTinh.Text = "";
            cboMaGT.Text = "";
            txtNgayHH.Text = "";
            txtGhiChu.Clear();
        }

        private void cboMaGT_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            DataTable dt = tv.LoadTextBox(cboMaGT.Text);
            foreach (DataRow dr in dt.Rows)
            {
                txtTenGT.Text = dr["TenGT"].ToString();
                txtHocPhi.Text = dr["Gia"].ToString();
                lblSoBuoi.Text = dr["ThoiHan"].ToString();
            }

        }

        private void txtNgayHH_Click(object sender, EventArgs e)
        {
            double sobuoi = Convert.ToDouble(lblSoBuoi.Text);
            DateTime time = DateTime.Now;
            txtNgayHH.Text = time.AddDays(sobuoi).ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtHocPhi.Text == "" || txtMaNV.Text == "" || txtMaTV.Text == "" || txtSoDT.Text == "" || txtTenGT.Text == "" || txtTenTV.Text == "" || cboGioiTinh.Text == "" || cboMaGT.Text == "" || dateNgayDK.Text == "" || txtNgayHH.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin");
            }
            else
            {
                try
                {
                    tv.ThemThanhVien(txtMaTV.Text, txtTenTV.Text, cboGioiTinh.Text, cboMaGT.Text, txtHocPhi.Text ,txtSoDT.Text, dateNgayDK.Text, txtNgayHH.Text, txtMaNV.Text, txtGhiChu.Text );
                    MessageBox.Show("Thêm thành viên mới thành công");
                    hienthidata();
                    clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialog = MessageBox.Show("Lưu ý: Chỉ có thể cập nhật Tên thành viên, Gói tập mới, Số điện thoại, Ghi chú.", "Thông báo", MessageBoxButtons.OKCancel);
                if (dialog == DialogResult.OK)
                {
                    if (txtMaTV.Text == "")
                    {
                        MessageBox.Show("Vui lòng nhập mã thành viên");
                    }
                    else
                    {
                        tv.CapNhatThanhVien(txtMaTV.Text, cboMaGT.Text, txtHocPhi.Text, txtSoDT.Text, txtNgayHH.Text, txtGhiChu.Text, txtTenTV.Text);
                        MessageBox.Show("Cập nhật thành viên thành công");
                        hienthidata();
                        clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialog = MessageBox.Show("Bạn chắc chắn muốn xóa thành viên này?", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialog == DialogResult.OK)
                {
                    tv.XoaThanhVien(txtMaTV.Text);
                    MessageBox.Show("Xóa thành viên thành công");
                    hienthidata();
                    clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtgvThanhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dtgvThanhVien.SelectedRows)
                {
                    txtMaTV.Text = row.Cells[0].Value.ToString();
                    txtTenTV.Text = row.Cells[1].Value.ToString();
                    cboGioiTinh.Text = row.Cells[2].Value.ToString();
                    cboMaGT.Text = row.Cells[3].Value.ToString();
                    txtHocPhi.Text = row.Cells[4].Value.ToString();
                    txtSoDT.Text = row.Cells[5].Value.ToString();
                    dateNgayDK.Text = row.Cells[6].Value.ToString();
                    txtNgayHH.Text = row.Cells[7].Value.ToString();
                    txtMaNV.Text = row.Cells[8].Value.ToString();
                    txtGhiChu.Text = row.Cells[9].Value.ToString();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = tv.LayDSThanhVien();
            DataView dv = new DataView(dt);
            dv.RowFilter = " TenTV like '%" + txtTim.Text + "%' ";
            dtgvThanhVien.DataSource = dv;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string duongdan;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    duongdan = saveFileDialog1.FileName;
                    fNhanVien.xuatExcel(dtgvThanhVien, duongdan);
                    MessageBox.Show("Đã xuất file!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}