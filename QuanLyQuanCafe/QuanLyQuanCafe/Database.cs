using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyQuanCafe
{
    internal class Database
    {
        string connectionString =
    @"Data Source=localhost\Dung28225;Initial Catalog=QuanLyQuanCafe;Integrated Security=True";

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);

                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            return dt;
        }

        public int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            int result = 0;

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);

                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                result = cmd.ExecuteNonQuery();
            }

            return result;
        }

        public object ExecuteScalar(string query, SqlParameter[] parameters = null)
        {
            object result;

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);

                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                result = cmd.ExecuteScalar();
            }

            return result;
        }
    }
}
