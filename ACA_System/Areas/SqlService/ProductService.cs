using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using ACA_System.Areas.DataQuery.Models;
namespace ACA_Data.SqlService
{
    /// <summary>
    /// 产品信息数据服务类
    /// </summary>
    public class ProductService
    {
        public List<ProductEntity> GetProduct(int start,int limit)
        {
            using (IDbConnection db = new SqlConnection(DbHelper.connectString))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append(" select top @limit * from product");
                strSql.Append(" where");
                strSql.Append(" id not in (select top @start id from product order by id desc)");
                strSql.Append(" order by id desc");
                SqlParameter[] ps =
                {
                    new SqlParameter("@limit",limit),
                    new SqlParameter("@start",start),
                };
                IEnumerable<ProductEntity> list = db.Query<ProductEntity>(strSql.ToString(), ps);
                return list.ToList<ProductEntity>();
            }
        }
        public List<ProductEntity> GetProduct(String barcode)
        {
            using (IDbConnection db = new SqlConnection(DbHelper.connectString))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append(" select * from product");
                strSql.Append(" where");
                strSql.Append(" Barcode=@Barcode");
                SqlParameter ps = new SqlParameter("@Barcode", barcode);
                IEnumerable<ProductEntity> list = db.Query<ProductEntity>(strSql.ToString(), ps);
                return list.ToList<ProductEntity>();
            }
        }
        public List<ProductEntity> GetProduct(int start,int limit,DateTime timeStart,DateTime timeEnd)
        {
            using (IDbConnection db=new SqlConnection(DbHelper.connectString))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append(" select top @limit * from product");
                strSql.Append(" where");
                strSql.Append(" Time between @timeStart and @timeEnd");
                strSql.Append(" and");
                strSql.Append(" id not in (select top @start id from product order by id desc)");
                strSql.Append(" order by desc");
                SqlParameter[] ps =
                {
                    new SqlParameter("@limit",limit),
                    new SqlParameter("@start",start),
                    new SqlParameter("@timeStart",timeStart),
                    new SqlParameter("@timeEnd",timeEnd),
                };
                IEnumerable<ProductEntity> list = db.Query<ProductEntity>(strSql.ToString(), ps);
                return list.ToList<ProductEntity>();
            }

        }
    }
}
