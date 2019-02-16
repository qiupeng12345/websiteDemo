using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using ACA_Data.SqlService;
using Dapper;

namespace ACA_System.Areas.SqlService
{
    public class ProductCodeService
    {
        public int GetCount(string name, string time1, string time2)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select count(*) from ProductCode where Time between '" + time1 + "' and '" + time2 + "' and ProductModel Like '%" + name + "%'");
            return SqlHelper.ExecuteScalar(sb.ToString());
        }
        public string[] GetName(string name, string time1, string time2)
        {

            string strSql = "select distinct ProductModel from ProductCode where Time between '" + time1 + "' and '" + time2 + "' and ProductModel Like '%" + name + "%'";
            DataTable dt = SqlHelper.GetDataTable(strSql);
            string[] Name = new string[dt.Rows.Count];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Name[i] = dt.Rows[i][0].ToString();
                }
            }
            return Name;
        }
    }
}