using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLG.CLASS
{
    class ThanhVien
    {
        Database db = new Database();
        public DataTable LoadComBo()
        {
            string sql = string.Format("select * from tblGoiTap");
            DataTable dt = db.Execute(sql);
            return dt;
        }

        public DataTable LoadTextBox(string magt)
        {
            string sql = string.Format("select * from tblGoiTap where MaGT = '{0}'", magt);
            DataTable dt = db.Execute(sql);
            return dt;
        }

        public DataTable LayDSThanhVien()
        {
            string sql = "select * from tblThanhVien";
            DataTable dt = db.Execute(sql);
            return dt;
        }

        public void ThemThanhVien(string MaTV, string TenTV, string GioiTinh, string MaGT, string HocPhi, string SDT, string NgayDK, string NgayHH, string MaNV, string GhiChu)
        {
            string sql = string.Format("insert into tblThanhVien values ('{0}',N'{1}',N'{2}','{3}','{4}','{5}','{6}','{7}','{8}',N'{9}')", MaTV, TenTV, GioiTinh, MaGT, HocPhi, SDT, NgayDK, NgayHH, MaNV, GhiChu);
            db.ExecuteNonQuery(sql);
        }
        public void CapNhatThanhVien(string MaTV, string MaGT, string HocPhi, string SDT, string ngayhh, string GhiChu, string TenTV)
        {
            string sql = string.Format("Update tblThanhVien set  MaGT = '{0}', HocPhi = '{1}', SDT ='{2}', NgayHetHan = '{3}', GhiChu = N'{4}', TenTV = N'{5}' where MaTV = '{6}'", MaGT, HocPhi, SDT, ngayhh, GhiChu,  TenTV, MaTV);
            db.ExecuteNonQuery(sql);
        }

        public void XoaThanhVien(string MaTV)
        {
            string sql = string.Format("Delete from tblThanhVien where MaTV = '{0}'", MaTV);
            db.ExecuteNonQuery(sql);
        }

    }
}
