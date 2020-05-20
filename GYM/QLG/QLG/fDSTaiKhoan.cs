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
    public partial class fDSTaiKhoan : DevExpress.XtraEditors.XtraForm
    {
        TaiKhoan tk;
        public fDSTaiKhoan()
        {
            InitializeComponent();
            tk = new TaiKhoan();
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
            SetGridViewStyle(dtgvTaiKhoan);
            DataTable dt = tk.LayDSTaiKhoan();
            dtgvTaiKhoan.DataSource = dt;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMatKhau.Text == "" || txtTaiKhoan.Text == "" || cboLoaiTK.Text == "")
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin");
                }
                else
                {
                    tk.CapNhat(txtTaiKhoan.Text, txtMatKhau.Text, cboLoaiTK.Text);
                    MessageBox.Show("Cập nhật tài khoản thành công");
                    hienthi();
                    txtMatKhau.Clear();
                    txtTaiKhoan.Clear();
                    cboLoaiTK.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dtgvTaiKhoan.SelectedRows)
                {
                    txtTaiKhoan.Text = row.Cells[1].Value.ToString();
                    txtMatKhau.Text = row.Cells[2].Value.ToString();
                    cboLoaiTK.Text = row.Cells[3].Value.ToString();
                }
            }
            catch (Exception ex)
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