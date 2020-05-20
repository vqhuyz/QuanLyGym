using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLG.CLASS
{
    class DangNhap
    {
        public string Login(string taikhoan, string matkhau)
        {
            Database db = new Database();
            string loaitk = "";
            string sql = "select * from tblTaiKhoan where TaiKhoan = N'" + taikhoan + "' and MatKhau = N'" + matkhau + "'";
            DataTable dt = db.Execute(sql);
            foreach (DataRow dr in dt.Rows)
            {
                loaitk = dr["LoaiTaiKhoan"].ToString();
            }
            return loaitk;
        }
    }
}
