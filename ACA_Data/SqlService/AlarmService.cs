using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using ACA_System.Areas.DataQuery.Models;
using System.Data;
using System.Data.SqlClient;
namespace ACA_Data.SqlService
{
    /// <summary>
    /// Alarm的CRUD
    /// </summary>
    public class AlarmService
    {
       public List<AlarmEntity> GetAlarm(string start,string limit )
        {
            using (IDbConnection db = new SqlConnection(DbHelper.connectString))
            {
                string  sql = "select * from alarm ";
                IEnumerable<AlarmEntity> list= db.Query<AlarmEntity>(sql);
                return list.ToList();
            }
        }
        public int AddAlarm(AlarmEntity alarm)
        {
            using (IDbConnection db = new SqlConnection(DbHelper.connectString))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("insert into alarm(LineNo,UnitNo,StartTime,StopTime,Duration,AlarmInfo,AlarmIndex,AlarmType,AlarmState,WorkGroup)");
                sb.Append("values(@LineNo,@UnitNo,@StartTime,@StopTime,@Duration,@AlarmInfo,@AlarmIndex,@AlarmType,@AlarmState,@WorkGroup)");
                SqlParameter[] ps =
                {
                    
                };
                return db.Execute(sb.ToString(),ps);
            }
        }
        public int UpdateAlarm(AlarmEntity alarm)
        {
            using (IDbConnection db = new SqlConnection(DbHelper.connectString))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("update alarm set LineNo=@LineNo,UnitNo=@UnitNo,StartTime=@StartTime,Duration=@Duration");
                sb.Append(",AlarmInfo=@AlarmInfo,AlarmIndex=@AlarmIndex,AlarmType=@AlarmType,AlarmState=@AlarmState");
                sb.Append(",WorkGroup=@WorkGroup where ID=@ID");
                SqlParameter[] ps =
                {
                    new SqlParameter("@ID",alarm.Id),
                    new SqlParameter("@LineNo",alarm.LineNo),
                    new SqlParameter("@UnitNo",alarm.UnitNo),
                    new SqlParameter("@StartTime",alarm.StartTime),
                    new SqlParameter("@StopTime",alarm.StopTime),
                    new SqlParameter("@Duration",alarm.Duration),
                    new SqlParameter("@AlarmInfo",alarm.AlarmInfo),
                    new SqlParameter("@AlarmIndex",alarm.AlarmIndex),
                    new SqlParameter("@AlarmType",alarm.AlarmType),
                    new SqlParameter("@AlarmState",alarm.AlarmState),
                    new SqlParameter("@WorkGroup",alarm.WorkGroup)
                };
                return db.Execute(sb.ToString(), ps);
            }
        }
        public int DeleteAlarm(int id)
        {
            using (IDbConnection db = new SqlConnection(DbHelper.connectString))
            {
                string sql = "delete from alarm where ID=@ID";
                SqlParameter ps = new SqlParameter("@ID", id);
                return db.Execute(sql, ps);
            }
        }
    }
}
