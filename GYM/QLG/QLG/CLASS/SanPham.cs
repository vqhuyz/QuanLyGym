using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLG.CLASS
{
    class SanPham
    {
        Database db = new Database();
        public DataTable LayDSSanPham()
        {
            string sql = "select * from tblSanPham";
            DataTable dt = db.Execute(sql);
            return dt;
        }
        public void XoaSanPham(string MaSP)
        {
            string sql = string.Format("Delete from tblSanPham where MaSP = '{0}'", MaSP);
            db.ExecuteNonQuery(sql);
        }
        public void ThemSanPham(string MaSP, string TenSP, string Loai, string NgayNhap, string SoLuong, string DonGia, string TrongLuong, string HinhAnh)
        {
            string sql = string.Format("insert into tblSanPham values ('{0}',N'{1}',N'{2}','{3}','{4}','{5}',N'{6}','{7}')", MaSP, TenSP, Loai, NgayNhap, SoLuong, DonGia, TrongLuong, HinhAnh);
            db.ExecuteNonQuery(sql);
        }
        public void CapNhatSanPham(string MaSP, string TenSP, string Loai, string SoLuong, string DonGia, string TrongLuong, string NgayNhap)
        {
            string sql = string.Format("Update tblSanPham set TenSP = N'{0}', Loai = N'{1}', SoLuong = '{2}', DonGia = '{3}', TrongLuong = N'{4}', NgayNhap = '{5}' where MaSP = '{6}'", TenSP, Loai, SoLuong,DonGia,TrongLuong,NgayNhap,MaSP);
            db.ExecuteNonQuery(sql);
        }

        public void BanHang(string MaSP, string SoLuong)
        {
            string sql = string.Format("Update tblSanPham set SoLuong = '{0}'  where MaSP = '{1}'", SoLuong, MaSP);
            db.ExecuteNonQuery(sql);
        }

    }
}
