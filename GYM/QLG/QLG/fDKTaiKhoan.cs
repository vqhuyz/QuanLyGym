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
    public partial class fDKTaiKhoan : DevExpress.XtraEditors.XtraForm
    {
        TaiKhoan tk;
        public fDKTaiKhoan()
        {
            InitializeComponent();
            tk = new TaiKhoan();
            txtMaNV.Text = fNhanVien.MaNV;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMatKhau.Text == "" || txtTaiKhoan.Text == "" || cboLoaiTK.Text == "" || txtMaNV.Text == "")
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin");
                }
                else
                {
                    tk.DangKi(txtMaNV.Text, txtTaiKhoan.Text, txtMatKhau.Text, cboLoaiTK.Text);
                    MessageBox.Show("Hoàn tất thêm nhân viên");
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}