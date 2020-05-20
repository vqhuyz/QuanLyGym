using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLG.CLASS
{
    class Database
    {
        SqlConnection sqlConn;
        SqlDataAdapter da;
        DataSet ds;

        public Database()
        {
            string sql = @"Data Source=.\SQLEXPRESS;Initial Catalog=GYM;Integrated Security=True";
            sqlConn = new SqlConnection(sql);
        }

        public DataTable Execute(string sql)
        {
            da = new SqlDataAdapter(sql, sqlConn);
            ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }

        public void ExecuteReader(string sql)
        {
            sqlConn.Open();
            SqlCommand sqlcmd = new SqlCommand(sql, sqlConn);
            SqlDataReader docdulieu = sqlcmd.ExecuteReader();
            sqlConn.Close();
        }

        public void ExecuteNonQuery(string sql)
        {
            SqlCommand sqlcmd = new SqlCommand(sql, sqlConn);
            sqlConn.Open();
            sqlcmd.ExecuteNonQuery();
            sqlConn.Close();
        }
    }
}
