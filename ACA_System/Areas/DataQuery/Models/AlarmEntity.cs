using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACA_System.Areas.DataQuery.Models
{
    /// <summary>
    /// 报警数据模型
    /// </summary>
    public class AlarmEntity
    {
       
        public int Id { get; set; }
        public int LineNo { get; set; }
        public int UnitNo { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime StopTime { get; set; }
        public string Duration { get; set; }
        public string AlarmInfo { get; set; }
        public int AlarmIndex { get; set; }
        public int AlarmType { get; set; }
        public int AlarmState { get; set; }
        public int WorkGroup { get; set; }
    }
}