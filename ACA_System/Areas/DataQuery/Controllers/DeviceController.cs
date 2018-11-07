using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ACA_System.Areas.DataQuery.Models;
using ACA.Code;

namespace ACA_System.Areas.DataQuery.Controllers
{
    public class DeviceController : Controller
    {
        // GET: DataQuery/Device
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 设备信息数据接口
        /// </summary>
        /// <returns></returns>
        public ActionResult GetDevice()
        {
            List<DeviceEntity> list = new List<DeviceEntity>();
            DeviceEntity de = new DeviceEntity()
            {
                ID = 201813,
                Date = DateTime.Now,
                LineNo="1",
                UnitNo=1,
                Type="1",
                TotalTime="1212312",
                StandbyTime="1212121",
                LoadingTime="121212",
                BreakdownTime="123122",
                BreakdownTimes="12121",
                AutoRunningTime="1212121",
                TimeUtilizationRate="12%",
                BreakdownPer="11%",
                MTBF="12121",
                MTTR="12122",
                ShortPauseTime="12312",
                ShortPauseTimes="1211",
                TaktTime_Real="1212",
                TaktTime_Set="12111",
                SpeedDroop="112121",
                NetOperatingTime="121211",
                EfficientPer="100%",
                ProductNumber_Total="1222222",
                ProductNumber_NG="12121111",
                ProductPer_Pass="100%",
                LoseTime="1112121",
                ValueTime="1212121",
                OEE="121%",
                WorkGroupNo=1,
                OperatorNo=1,
            };
            for (int i = 0; i < 20; i++)
            {
                list.Add(de);
            }
            return Content(new LayUIResult() { code = 0, msg = "ok", count = 1000, data = list }.ToJson());
        }
    }
}