using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLG.CLASS
{
    class TaiKhoan
    {
        Database db = new Database();

        public DataTable LayDSTaiKhoan()
        {
            string sql = "select nv.MaNV, TaiKhoan, MatKhau, LoaiTaiKhoan, TenNV, SoDT, DiaChi from tblTaiKhoan tk, tblNhanVien nv where tk.MaNV = nv.MaNV";
            DataTable dt = db.Execute(sql);
            return dt;
        }

        public void DangKi(string manv, string taikhoan, string matkhau, string loaitaikhoan)
        {
            string sql = string.Format("insert into tblTaiKhoan values('{0}','{1}','{2}','{3}')", manv, taikhoan, matkhau, loaitaikhoan);
            db.ExecuteNonQuery(sql);
        }

        public void CapNhat(string taikhoan, string matkhau, string loaitaikhoan)
        {
            string sql = string.Format("update tblTaiKhoan set MatKhau = '{0}', LoaiTaiKhoan = '{1}' where TaiKhoan = '{2}'", matkhau, loaitaikhoan, taikhoan);
            db.ExecuteNonQuery(sql);
        }
    }
}
