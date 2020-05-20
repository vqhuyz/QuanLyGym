using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLG.CLASS
{
    class GoiTap
    {
        Database db = new Database();

        public DataTable LayDSGoiTap()
        {
            string sql = "select * from tblGoiTap";
            DataTable dt = db.Execute(sql);
            return dt;
        }

        public void Them(string magt, string tengt, string thoihan, string gia)
        {
            string sql = string.Format("insert into tblGoiTap values('{0}',N'{1}','{2}','{3}')", magt, tengt, thoihan, gia);
            db.ExecuteNonQuery(sql);
        }

        public void CapNhat(string magt, string tengt, string thoihan, string gia)
        {
            string sql = string.Format("update tblGoiTap set TenGT = N'{0}', ThoiHan = '{1}', Gia = '{2}' where MaGT = '{3}'", tengt, thoihan, gia, magt);
            db.ExecuteNonQuery(sql);
        }

    }
}
