using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACA_System.Areas.DataQuery.Models
{
    /// <summary>
    /// 设备性能数据模型
    /// </summary>
    ///
    public class DeviceEntity
    {
        #region 
        public int ID { get; set; }
        /// <summary>
        /// 信息日期
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// 线编号
        /// </summary>
        public string LineNo { get; set; }
        /// <summary>
        /// 站编号
        /// </summary>
        public int UnitNo { get; set; }
        /// <summary>
        /// 产品型号
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 总投入时间
        /// </summary>
        public string TotalTime { get; set; }
        /// <summary>
        /// 待机时间
        /// </summary>
        public string StandbyTime { get; set; }
        /// <summary>
        /// 负荷时间
        /// </summary>
        public string LoadingTime { get; set; }
        /// <summary>
        /// 报警次数
        /// </summary>
        public string BreakdownTimes { get; set; }
        /// <summary>
        /// 故障时间
        /// </summary>
        public string BreakdownTime { get; set; }
        /// <summary>
        /// 自动运行时间
        /// </summary>
        public string AutoRunningTime { get; set; }
        /// <summary>
        /// 时间稼动率=稼动时间/负荷时间
        /// </summary>
        public string TimeUtilizationRate { get; set; }
        /// <summary>
        /// 故障率
        /// </summary>
        public string BreakdownPer { get; set; }
        /// <summary>
        /// MTBF(平均故障发生间隔时间)=稼动时间/故障次数
        /// </summary>
        public string MTBF { get; set; }
        /// <summary>
        /// MTTR（平均故障维护时间）=故障时间/故障次数
        /// </summary>
        public string MTTR { get; set; }
        /// <summary>
        /// 小停顿次数
        /// </summary>
        public string ShortPauseTimes { get; set; }
        /// <summary>
        /// 小停顿时间
        /// </summary>
        public string ShortPauseTime { get; set; }
        /// <summary>
        /// 实际节拍
        /// </summary>
        public string TaktTime_Real { get; set; }
        /// <summary>
        /// 理论节拍
        /// </summary>
        public string TaktTime_Set { get; set; }
        /// <summary>
        /// 速度降低(损失时间)
        /// </summary>
        public string SpeedDroop { get; set; }
        /// <summary>
        /// 净稼动时间
        /// </summary>
        public string NetOperatingTime { get; set; }
        /// <summary>
        /// 性能稼动率=净稼动时间/稼动时间(包含小停顿)
        /// </summary>
        public string EfficientPer { get; set; }
        /// <summary>
        /// 投入总数
        /// </summary>
        public string ProductNumber_Total { get; set; }
        /// <summary>
        /// 不合格数
        /// </summary>
        public string ProductNumber_NG { get; set; }
        /// <summary>
        /// 合格率
        /// </summary>
        public string ProductPer_Pass { get; set; }
        /// <summary>
        /// 不良品损失时间
        /// </summary>
        public string LoseTime { get; set; }
        /// <summary>
        /// 有效时间
        /// </summary>
        public string ValueTime { get; set; }
        /// <summary>
        /// OEE=(理论节拍*合格总数)/负荷时间
        /// </summary>
        public string OEE { get; set; }
        /// <summary>
        /// 班组
        /// </summary>
        public int WorkGroupNo { get; set; }
        /// <summary>
        /// 操作员
        /// </summary>
        public int OperatorNo { get; set; }
        /// <summary>
        /// 稼动率
        /// </summary>
        public int AutoRunningPer { get; set; }
        #endregion
    }
}
