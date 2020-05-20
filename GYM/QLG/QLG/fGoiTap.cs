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
    public partial class fGoiTap : DevExpress.XtraEditors.XtraForm
    {
        GoiTap gt;
        public fGoiTap()
        {
            InitializeComponent();
            gt = new GoiTap();
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
            SetGridViewStyle(dtgvGoiTap);
            DataTable dt = gt.LayDSGoiTap();
            dtgvGoiTap.DataSource = dt;
        }

        void clear()
        {
            txtMaGT.Clear();
            txtGia.Clear();
            txtTenGT.Clear();
            txtThoiHan.Clear();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtGia.Text == "" || txtMaGT.Text == "" || txtTenGT.Text == "" || txtThoiHan.Text =="")
            { 
                MessageBox.Show("Vui lòng nhập đủ thông tin");
            }
            else
            {
                try
                {
                    gt.Them(txtMaGT.Text, txtTenGT.Text, txtThoiHan.Text, txtGia.Text);
                    MessageBox.Show("Thêm gói tập thành công!!");
                    hienthi();
                    clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaGT.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập mã gói tập cần sửa");
                }
                else
                {
                    gt.CapNhat(txtMaGT.Text, txtTenGT.Text, txtThoiHan.Text, txtGia.Text);
                    MessageBox.Show("Cập nhật gói tập thành công");
                    hienthi();
                    clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtgvGoiTap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dtgvGoiTap.SelectedRows)
                {
                    txtMaGT.Text = row.Cells[0].Value.ToString();
                    txtTenGT.Text = row.Cells[1].Value.ToString();
                    txtThoiHan.Text = row.Cells[2].Value.ToString();
                    txtGia.Text = row.Cells[3].Value.ToString();
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