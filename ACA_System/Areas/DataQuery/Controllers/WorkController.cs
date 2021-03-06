﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ACA.Code;
using ACA_System.Areas.DataQuery.Models;
using ACA_System.Areas.SqlService;
namespace ACA_System.Areas.DataQuery.Controllers
{
    public class WorkController : Controller
    {
        WorkService work = new WorkService();
        // GET: DataQuery/Work
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetWork(int page, int limit, DateTime timeStart, DateTime timeEnd, string barcode, string recipes, string worker)
        {
            List<WorkEntity> list = work.GetWork(page, limit, timeStart, timeEnd, barcode, recipes, worker);
            object TotalCount = work.GetWorkCount( timeStart, timeEnd, barcode, recipes, worker);
            return Content(new LayUIResult { code = 0, msg = "success", count = TotalCount, data = list }.ToJson());
        }
        public ActionResult GetFilter(int page, int limit, DateTime timeStart, DateTime timeEnd, string barcode, string recipes, string worker)
        {
            List<object> list = new List<object>();
            string[] NameFilter = work.GetFilterName(page, limit, timeStart, timeEnd, barcode, recipes, worker);
            foreach (string item in NameFilter)
            {
                list.Add(new { ProductModel = item, No = work.GetCount(item,timeStart.ToString(), timeEnd.ToString()) });
            }
            return  Content(new LayUIResult { code = 0, msg = "success", data = list }.ToJson());
        }
    }
}