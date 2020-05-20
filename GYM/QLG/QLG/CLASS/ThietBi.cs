using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLG.CLASS
{
    class ThietBi
    {
        Database db = new Database();
        public DataTable LayDSThietBi()
        {
            string sql = "select * from tblThietBi";
            DataTable dt = db.Execute(sql);
            return dt;
        }
        public void XoaThietBI(string MaTB)
        {
            string sql = string.Format("Delete from tblThietBi where MaTB = '{0}'", MaTB);
            db.ExecuteNonQuery(sql);
        }
        public void ThemThietBi(string MaTB, string TenTB, string Loai, string SoLuong ,string HangSX, string SoLuongHu, string TinhTrang, string GhiChu, string HinhAnh)
        {
            string sql = string.Format("insert into tblThietBi values ('{0}',N'{1}',N'{2}','{3}',N'{4}','{5}',N'{6}',N'{7}','{8}')", MaTB, TenTB, Loai, SoLuong, HangSX, SoLuongHu, TinhTrang, GhiChu,HinhAnh);
            db.ExecuteNonQuery(sql);
        }
        public void CapNhatThietBi(string MaTB, string TenTB, string Loai, string SoLuong, string SoLuongHu, string TingTrang, string GhiChu)
        {
            string sql = string.Format("Update tblThietBi set TenTB = N'{0}', Loai = N'{1}', SoLuong = '{2}', SoLuongHu = '{3}', TinhTrang = N'{4}', GhiChu = N'{5}' where MaTB = '{6}'", TenTB, Loai, SoLuong,SoLuongHu, TingTrang,GhiChu, MaTB);
            db.ExecuteNonQuery(sql);
        }
    }
}
