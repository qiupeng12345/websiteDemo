using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using ACA_System.Areas.DataQuery.Models;
using System.Data;

namespace ACA_Data.SqlService
{
    /// <summary>
    /// 设备信息服务类
    /// </summary>
    public class DeviceService
    {
        /// <summary>
        /// 根据起始和条数获取设备数据
        /// </summary>
        /// <param name="start"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public List<ProductEntity>GetProduct(int start,int limit)
        {
            using (IDbConnection db = new SqlConnection(DbHelper.connectString))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append(" select top @limit * from facility");
                strSql.Append(" where");
                strSql.Append(" id not in (select top @start id from facility order by id desc)");
                strSql.Append(" order by id desc");
                SqlParameter[] ps = new SqlParameter[]
                {
                    new SqlParameter("@limit",limit),
                    new SqlParameter("@start",start)
                };
                IEnumerable<ProductEntity> list = db.Query<ProductEntity>(strSql.ToString(), ps);
                return list.ToList<ProductEntity>();
            }
        }
        /// <summary>
        /// 添加单元选择条件
        /// </summary>
        /// <param name="start"></param>
        /// <param name="limit"></param>
        /// <param name="unitNo"></param>
        /// <returns></returns>
        public List<ProductEntity> GetProduct(int start, int limit,int unitNo)
        {
            using (IDbConnection db = new SqlConnection(DbHelper.connectString))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append(" select top @limit * from facility");
                strSql.Append(" where");
                strSql.Append(" id not in (select top @start id from facility order by id desc)");
                strSql.Append(" and");
                strSql.Append(" UnitNo=@UnitNo");
                strSql.Append(" order by id desc");
                SqlParameter[] ps = new SqlParameter[]
                {
                    new SqlParameter("@limit",limit),
                    new SqlParameter("@start",start),
                    new SqlParameter("@UnitNo",unitNo),
                };
                IEnumerable<ProductEntity> list = db.Query<ProductEntity>(strSql.ToString(), ps);
                return list.ToList<ProductEntity>();
            }
        }
        /// <summary>
        /// 添加时间段选择
        /// </summary>
        /// <param name="start"></param>
        /// <param name="limit"></param>
        /// <param name="timeStart"></param>
        /// <param name="timeEnd"></param>
        /// <returns></returns>
        public List<ProductEntity> GetProduct(int start, int limit, DateTime timeStart,DateTime timeEnd)
        {
            using (IDbConnection db = new SqlConnection(DbHelper.connectString))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append(" select top @limit * from facility");
                strSql.Append(" where");
                strSql.Append(" id not in (select top @start id from facility order by id desc)");
                strSql.Append(" and");
                strSql.Append(" Date between @timeStart and @timeEnd");
                strSql.Append(" order by id desc");
                SqlParameter[] ps = new SqlParameter[]
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
        /// <summary>
        /// 添加单元号和时间段选择
        /// </summary>
        /// <param name="start"></param>
        /// <param name="limit"></param>
        /// <param name="unitNo"></param>
        /// <param name="timeStart"></param>
        /// <param name="timeEnd"></param>
        /// <returns></returns>
        public List<ProductEntity> GetProduct(int start, int limit,int unitNo, DateTime timeStart, DateTime timeEnd)
        {
            using (IDbConnection db = new SqlConnection(DbHelper.connectString))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append(" select top @limit * from facility");
                strSql.Append(" where");
                strSql.Append(" id not in (select top @start id from facility order by id desc)");
                strSql.Append(" and");
                strSql.Append(" UnitNo=@UnitNo");
                strSql.Append(" and");
                strSql.Append(" Date between @timeStart and @timeEnd");
                strSql.Append(" order by id desc");
                SqlParameter[] ps = new SqlParameter[]
                {
                    new SqlParameter("@limit",limit),
                    new SqlParameter("@start",start),
                    new SqlParameter("@UnitNo",unitNo),
                    new SqlParameter("@timeStart",timeStart),
                    new SqlParameter("@timeEnd",timeEnd),
                };
                IEnumerable<ProductEntity> list = db.Query<ProductEntity>(strSql.ToString(), ps);
                return list.ToList<ProductEntity>();
            }
        }
    }
}
