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
using Excel = Microsoft.Office.Interop.Excel;
using app = Microsoft.Office.Interop.Excel.Application;

namespace QLG
{
    public partial class fNhanVien : DevExpress.XtraEditors.XtraForm
    {
        NhanVien nv;
        public fNhanVien()
        {
            InitializeComponent();
            nv = new NhanVien();
            string loaitaikhoan = fDangNhap.LoaiTK;

            if (loaitaikhoan == "user" || loaitaikhoan == "USER")
            {
                btnExcel.Visible = false;
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
            SetGridViewStyle(dtgvNhanVien);
            DataTable dt = nv.LayDSNhanVien();
            dtgvNhanVien.DataSource = dt;
        }

        void clear()
        {
            txtChucVu.Clear();
            txtCMND.Clear();
            txtDiaChi.Clear();
            txtLuongCoBan.Clear();
            txtMaNV.Clear();
            txtSDT.Clear();
            txtTenNV.Clear();
            txtTim.Clear();
            cboGioiTinh.Text = "";
            ptbNhanVien.Image = null;
        }


        string img = "";

        private void btnTaiAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png file(*png)|*.png|jpg files(*jpg)|*.jpg|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                img = dialog.FileName.ToString();
                ptbNhanVien.ImageLocation = img;
            }
        }

        public string LuuAnh()
        {
            string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
            File.Copy(img, path + "\\img\\" + txtMaNV.Text);
            string tenanh = "\\img\\" + txtMaNV.Text;
            return tenanh;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialog = MessageBox.Show("Bạn chắc chắn muốn xóa nhân viên này?", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialog == DialogResult.OK)
                {
                    nv.XoaNhanVien(txtMaNV.Text);
                    MessageBox.Show("Xóa nhân viên thành công !!");
                    hienthi();
                    clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialog = MessageBox.Show("Lưu ý: Chỉ có thể cập nhật Số điện thoại, Địa chỉ, Chức vụ, Lương.","Thông báo",MessageBoxButtons.OKCancel);
                if (dialog == DialogResult.OK)
                {
                    if (txtMaNV.Text == "")
                    {
                        MessageBox.Show("Cần nhập mã nhân viên để cập nhật");
                    }
                    else
                    {
                        nv.CapNhatNhanVien(txtMaNV.Text, txtSDT.Text, txtDiaChi.Text, txtChucVu.Text, txtLuongCoBan.Text);
                        MessageBox.Show("Cập nhật thông tin thành công");
                        hienthi();
                        clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static string MaNV = "";

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtSDT.Text == "" || txtTenNV.Text == "" || txtMaNV.Text == "" || ptbNhanVien.Image == null ||
                txtDiaChi.Text == "" || txtChucVu.Text == "" || cboGioiTinh.Text == "" || txtLuongCoBan.Text == "")
            {
                XtraMessageBox.Show("Vui lòng nhập đủ thông tin");
            }
            else
            {
                try
                {
                    nv.ThemNhanVien(txtMaNV.Text, txtTenNV.Text, cboGioiTinh.Text, txtCMND.Text, txtSDT.Text, txtDiaChi.Text, txtChucVu.Text, txtLuongCoBan.Text, LuuAnh());
                    MessageBox.Show("Thêm thông tin thành công! Hãy tạo tài khoản");
                    hienthi();
                    MaNV = txtMaNV.Text;
                    clear();
                    fDKTaiKhoan f = new fDKTaiKhoan();
                    f.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dtgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dtgvNhanVien.SelectedRows)
                {
                    txtMaNV.Text = row.Cells[0].Value.ToString();
                    txtTenNV.Text = row.Cells[1].Value.ToString();
                    cboGioiTinh.Text = row.Cells[2].Value.ToString();
                    txtCMND.Text = row.Cells[3].Value.ToString();
                    txtSDT.Text = row.Cells[4].Value.ToString();
                    txtDiaChi.Text = row.Cells[5].Value.ToString();
                    txtChucVu.Text = row.Cells[6].Value.ToString();
                    txtLuongCoBan.Text = row.Cells[7].Value.ToString();
                }

                int selected = dtgvNhanVien.SelectedCells[0].RowIndex;
                DataGridViewRow selectedrow = dtgvNhanVien.Rows[selected];
                string hinhanh = Convert.ToString(selectedrow.Cells["HinhAnh"].Value);
                string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                ptbNhanVien.Image = Image.FromFile(path + hinhanh);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = nv.LayDSNhanVien();
            DataView dv = new DataView(dt);
            dv.RowFilter = " TenNV like '%" +txtTim.Text+  "%' ";
            dtgvNhanVien.DataSource = dv;
        }

        public static void xuatExcel(DataGridView dtgv, string duongdan)
        {
            app excel = new app();
            excel.Application.Workbooks.Add(Type.Missing);
            excel.Columns.ColumnWidth = 15;
            for(int i = 1; i<dtgv.Columns.Count+1; i++)
            {
                excel.Cells[1, i] = dtgv.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < dtgv.Rows.Count; i++)
            {
                for (int j = 0; j < dtgv.Columns.Count; j++)
                {
                    if (dtgv.Rows[i].Cells[j].Value != null)
                    {
                        excel.Cells[i + 2, j + 1] = dtgv.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }
            excel.ActiveWorkbook.SaveCopyAs(duongdan + ".xlsx");
            excel.ActiveWorkbook.Saved = true;

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string duongdan;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    duongdan = saveFileDialog1.FileName;
                    xuatExcel(dtgvNhanVien, duongdan);
                    MessageBox.Show("Đã xuất file!!");
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
    }
}
