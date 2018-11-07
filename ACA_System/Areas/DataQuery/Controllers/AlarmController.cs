using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ACA_System.Areas.DataQuery.Models;
using ACA.Code;


namespace ACA_System.Areas.DataQuery.Controllers
{
    public class AlarmController : Controller
    {
        // GET: DataQuery/Alarm
        //返回alarm视图
        public ActionResult Index()
        {
            return View();
        }
         /// <summary>
         /// 报警数据表数据接口（根据page 和limit ）
         /// </summary>
         /// <param name="page"></param>
         /// <param name="limit"></param>
         /// <returns></returns>
        public ActionResult GetAlarmDetail(string page,string limit,string id,string station,string date1,string date2)
        {
            List<AlarmEntity> list = new List<AlarmEntity>();
            AlarmEntity ad = new AlarmEntity() { Id = 10000, LineNo = 1, UnitNo = 1, StartTime = DateTime.Now, StopTime = DateTime.Now.AddHours(4), Duration = "4 hour", AlarmInfo = "设备报警", AlarmIndex = 1, AlarmType = 1, AlarmState=1,WorkGroup=1 };
            for (int i = 0; i < Convert.ToInt16(limit); i++)
            {
                list.Add(ad);
            }
            return Content(new LayUIResult { code = 0, msg = "success", count = 100, data = list }.ToJson());
        }
    }
}