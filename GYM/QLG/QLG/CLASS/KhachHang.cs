using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLG.CLASS
{
    class KhachHang
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

        public DataTable LayDSKhachHang()
        {
            string sql = "select * from tblKhachHang";
            DataTable dt = db.Execute(sql);
            return dt;
        }


        public void ThemKhachHang(string manv, string tenkh, string sdt, string magt, string thanhtoan, string ngaytap)
        {
            string sql = string.Format("insert into tblKhachHang values ('{0}',N'{1}','{2}','{3}','{4}','{5}')", manv, tenkh, sdt, magt, thanhtoan, ngaytap);
            db.ExecuteNonQuery(sql);
        }
        public void CapNhatKhachHang(string tenkh, string magt, string thanhtoan, string SDT, string id)
        {
            string sql = string.Format("Update tblKhachHang set  MaGT = '{0}', ThanhToan = '{1}', SDT ='{2}', TenKH = N'{3}' where id = {4}", magt, thanhtoan, SDT, tenkh,id);
            db.ExecuteNonQuery(sql);
        }

        public void XoaKhachHang(string id)
        {
            string sql = string.Format("Delete from tblKhachHang where id = '{0}'", id);
            db.ExecuteNonQuery(sql);
        }


    }
}
