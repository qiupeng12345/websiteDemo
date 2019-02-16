using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using ACA_System.Areas.DataQuery.Models;
using ACA_Data.SqlService;
using System.Text;

namespace ACA_System.Areas.SqlService
{
    public class WorkService
    {
        public List<WorkEntity> GetWork(int start, int limit, DateTime timeStart, DateTime timeEnd,string barcode,string recipes,string worker)
        {
            using (IDbConnection db = new SqlConnection(DbHelper.connectString))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("select * from ProductCode where Time between '" + timeStart + "' and '" + timeEnd.ToString() + "'");
                if (recipes != "")
                {
                    sb.Append(" and ProductModel Like '%" + recipes + "%'");
                }
                if (barcode != "")
                {
                    sb.Append("and ( Part1Code Like '%" + barcode + "%' or Part2Code Like '%" + barcode + "%' ");
                    sb.Append(" or Part3Code Like '%" + barcode + "%' or Part4Code Like '%" + barcode + "%' or Part5Code Like '%" + barcode + "%'");
                    sb.Append(" or Part6Code Like '%" + barcode + "%' or Part7Code Like '%" + barcode + "%' or Part8Code Like '%" + barcode + "%'");
                    sb.Append(" or Part9Code Like '%" + barcode + "%' or Part10Code Like '%" + barcode + "%' or Part11Code Like '%" + barcode + "%'");
                    sb.Append(" or Part12Code Like '%" + barcode + "%')");
                }
                if (worker != "")
                {
                    sb.Append(" and Enter Like '%" + worker + "%'");
                }
                sb.Append(" order by id desc Offset " + ((start - 1) * limit).ToString() + " Row Fetch Next " + limit.ToString() +" Rows Only");

                IEnumerable<WorkEntity> list = db.Query<WorkEntity>(sb.ToString());
                return list.ToList();
            }
        }
        public object GetWorkCount(int start, int limit, DateTime timeStart, DateTime timeEnd, string barcode, string recipes, string worker)
        {
            using (IDbConnection db = new SqlConnection(DbHelper.connectString))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("select count(*) from ProductCode where Time between '" + timeStart + "' and '" + timeEnd.ToString() + "'");
                if (recipes != "")
                {
                    sb.Append(" and ProductModel Like '%" + recipes + "%'");
                }
                if (barcode != "")
                {
                    sb.Append("and ( Part1Code Like '%" + barcode + "%' or Part2Code Like '%" + barcode + "%' ");
                    sb.Append(" or Part3Code Like '%" + barcode + "%' or Part4Code Like '%" + barcode + "%' or Part5Code Like '%" + barcode + "%'");
                    sb.Append(" or Part6Code Like '%" + barcode + "%' or Part7Code Like '%" + barcode + "%' or Part8Code Like '%" + barcode + "%'");
                    sb.Append(" or Part9Code Like '%" + barcode + "%' or Part10Code Like '%" + barcode + "%' or Part11Code Like '%" + barcode + "%'");
                    sb.Append(" or Part12Code Like '%" + barcode + "%')");
                }
                if (worker != "")
                {
                    sb.Append(" and Enter Like '%" + worker + "%'");
                }


                return db.ExecuteScalar(sb.ToString());
            }
        }
    }
}