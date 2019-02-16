using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace ACA_System.Areas.SqlService
{
    public static class SqlHelper
    {
        /// <summary>
        /// 数据库连接地址
        /// </summary>
        private static readonly string connStr = "server=192.168.1.1;database=ACA;User ID=ACA;password=ACAACAACA";
        /// <summary>
        /// 获取dataTable
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="pars">sql参数</param>
        /// <returns></returns>
        public static DataTable GetDataTable(string sql, params SqlParameter[] pars)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                using (SqlDataAdapter apter = new SqlDataAdapter(sql, con))
                {
                    if (pars != null)
                    {
                        apter.SelectCommand.Parameters.AddRange(pars);
                    }
                    DataTable dt = new DataTable();
                    apter.Fill(dt);
                    return dt;
                }
            }
        }
        /// <summary>
        /// 执行sql语句
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        public static int ExecuteNonquery(string sql, params SqlParameter[] pars)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    if (pars != null)
                    {
                        cmd.Parameters.AddRange(pars);
                    }
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// 查询数量
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        public static int ExecuteScalar(string sql, params SqlParameter[] pars)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    if (pars != null)
                    {
                        cmd.Parameters.AddRange(pars);
                    }
                    con.Open();
                    return (int)cmd.ExecuteScalar();
                }
            }
        }
    }
}