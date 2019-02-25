using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ACA.Code;
using ACA_System.Areas.UserManage.Models;
using ACA_System.Areas.SqlService;
namespace ACA_System.Controllers
{
    public class HomeController : Controller
    {
        ProductCodeService ProductCodeService = new ProductCodeService();
        // GET: Home
        public ActionResult Index()
        {

            if (Session["CurrentUser"] != null)
            {
                Session.Timeout = 1;
                return View();
            }
            else
            {
                return RedirectToAction("index", "Login");
            }
            //return View();
        }
        public ActionResult Default()
        {
            return View();
        }
        /// <summary>
        /// 刷新整机人工台chart数据
        /// </summary>
        /// <returns></returns>
        public ActionResult RefreshCharts(string time1,string time2)
        {
            int count1 = ProductCodeService.GetCount("整机人工台", time1, time2);
            string[] name = ProductCodeService.GetName("整机人工台", time1, time2);
            List<string> list = new List<string>();
            for (int i = 0; i < name.Length; i++)
            {
                string getname = name[i].Split('整')[0];
                if (!list.Contains(getname))
                {
                    list.Add(getname);
                }
            }
            string[] chartName = new string[list.Count];
            int[] chartData = new int[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                chartName[i] = list[i];
                chartData[i] = ProductCodeService.GetCount(list[i] + "整机人工台", time1, time2);
            }
            List<object> listSend = new List<object>();
            for (int i = 0; i < chartName.Length; i++)
            {
                listSend.Add(new { name = chartName[i], value = chartData[i] });
            }
            ////
            return Content(new AjaxResult() { state = ResultType.success.ToString(), data = listSend,count=count1 } .ToJson());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult RefreshCharts2(string time1,string time2)
        {

            int count1 = ProductCodeService.GetCount("生产包装", time1, time2);
            string[] name = ProductCodeService.GetName("生产包装", time1, time2);
            List<string> list = new List<string>();
            for (int i = 0; i < name.Length; i++)
            {
                string getname = name[i].Split('生')[0];
                if (!list.Contains(getname))
                {
                    list.Add(getname);
                }
            }
            string[] chartName = new string[list.Count];
            int[] chartData = new int[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                chartName[i] = list[i];
                chartData[i] = ProductCodeService.GetCount(list[i] + "生产包装", time1, time2);
            }
            List<object> listSend = new List<object>();
            for (int i = 0; i < chartName.Length; i++)
            {
                listSend.Add(new { name = chartName[i], value = chartData[i] });
            }
            ////
            return Content(new AjaxResult() { state = ResultType.success.ToString(), data = listSend,count=count1 }.ToJson());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult RefreshCharts3(string time1, string time2)
        {
            int count1 = ProductCodeService.GetCount("整机人工台", time1, time2);
            int count2 = ProductCodeService.GetCount("报修", time1, time2);
            var count=((count1 - count2) * 100.00 / count1).ToString("0.00");
            return Content(new AjaxResult() { state = ResultType.success.ToString(), data = new { name="合格率",value=count} ,count=count2}.ToJson());
        }
        public ActionResult RefreshCharts4(string time1, string time2)
        {
            int count= ProductCodeService.GetCount("返工", time1, time2);
            return Content(new AjaxResult() { state = ResultType.success.ToString(), data = count}.ToJson());
        }
        //刷新半成品
        public ActionResult RefreshCharts5(string time1, string time2)
        {
            int count1 = ProductCodeService.GetCount("半成品", time1, time2);
            string[] name = ProductCodeService.GetName("半成品", time1, time2);
            List<string> list = new List<string>();
            for (int i = 0; i < name.Length; i++)
            {
                string getname = name[i].Split('半')[0];
                if (!list.Contains(getname))
                {
                    list.Add(getname);
                }
            }
            string[] chartName = new string[list.Count];
            float[] chartData = new float[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                chartName[i] = list[i];
                chartData[i] = ProductCodeService.GetCount(list[i] + "半成品", time1, time2);
            }
            List<object> listSend = new List<object>();
            for (int i = 0; i < chartName.Length; i++)
            {
                listSend.Add(new { name = chartName[i], value = chartData[i] });
            }
            ////
            return Content(new AjaxResult() { state = ResultType.success.ToString(), data = listSend, count = count1 }.ToJson());
        }
        //刷新 生产维修
        public ActionResult RefreshCharts6(string time1, string time2)
        {
            int count1 = ProductCodeService.GetCount("生产维修", time1, time2);
            string[] name = ProductCodeService.GetName("生产维修", time1, time2);
            List<string> list = new List<string>();
            for (int i = 0; i < name.Length; i++)
            {
                string getname = name[i].Split('修')[1];
                if (!list.Contains(getname))
                {
                    list.Add(getname);
                }
            }
            string[] chartName = new string[list.Count];
            float[] chartData = new float[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                chartName[i] = list[i];
                chartData[i] = ProductCodeService.GetCount("生产维修"+list[i], time1, time2);
            }
            List<object> listSend = new List<object>();
            for (int i = 0; i < chartName.Length; i++)
            {
                listSend.Add(new { name = chartName[i], value = chartData[i] });
            }
            ////
            return Content(new AjaxResult() { state = ResultType.success.ToString(), data = listSend, count = count1 }.ToJson());
        }
        public ActionResult GetCurrentUser()
        {
            UserEntity currentUser = new UserEntity();
            currentUser = (UserEntity) Session["CurrentUser"];
            return Content(new AjaxResult() { state = ResultType.success.ToString(), data = currentUser }.ToJson());
        }
        
    }
}