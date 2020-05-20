using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLG.CLASS
{
    class NhanVien
    {
        Database db = new Database();

        public DataTable LayDSNhanVien()
        {
            string sql = "select * from tblNhanVien";
            DataTable dt = db.Execute(sql);
            return dt;
        }
        public void XoaNhanVien(string MaNV)
        {
            string sql = string.Format("Delete from tblNhanVien where MaNV = '{0}'", MaNV);
            db.ExecuteNonQuery(sql);
        }
        public void ThemNhanVien(string MaNV, string TenNV, string GioiTinh, string CMND, string SoDT, string DiaChi, string ChucVu, string TienLuong, string HinhAnh)
        {
            string sql = string.Format("insert into tblNhanVien values ('{0}',N'{1}',N'{2}','{3}','{4}',N'{5}',N'{6}','{7}','{8}')", MaNV, TenNV, GioiTinh, CMND, SoDT, DiaChi, ChucVu, TienLuong, HinhAnh);
            db.ExecuteNonQuery(sql);
        }
        public void CapNhatNhanVien(string MaNV, string SDT, string Diachi, string ChucVu, string TienLuong)
        {
            string sql = string.Format("Update tblNhanVien set SoDT = '{0}', DiaChi = N'{1}', ChucVu = N'{2}', LuongCoBan ='{3}' where MaNV = '{4}'", SDT, Diachi, ChucVu, TienLuong, MaNV);
            db.ExecuteNonQuery(sql);

        }
    }
}
