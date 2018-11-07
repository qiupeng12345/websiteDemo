using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ACA.Code;

namespace ACA_System.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Default()
        {
            return View();
        }
        /// <summary>
        /// 刷新chart数据
        /// </summary>
        /// <returns></returns>
        public ActionResult RefreshCharts()
        {
            return Content(new AjaxResult() { state = ResultType.success.ToString(), data = new List<object[]>() { new object[] { 10, 20, 30, 40, 50, 60 }, new object[] { 11, 12, 13, 14, 15, 16 } } }.ToJson());
        }
    }
}