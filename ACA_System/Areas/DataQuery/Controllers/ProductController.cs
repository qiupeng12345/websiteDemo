using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ACA.Code;
using ACA_System.Areas.DataQuery.Models;

namespace ACA_System.Areas.DataQuery.Controllers
{
    public class ProductController : Controller
    {
        // GET: DataQuery/Product
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 产品信息数据接口
        /// </summary>
        /// <returns></returns>
        public ActionResult GetProduct()
        {
            List<ProductEntity> list = new List<ProductEntity>();
            ProductEntity pe = new ProductEntity()
            {
              ID=2010101,
              Time=DateTime.Now,
              Barcode="12121213341211231111",
              ProductType="12112312121",
              Model="12122312311",
              TestResult="112121",
              TestData_1="11111111111",
              TestData_2="11111111111",
              TestData_3="11111111111",
              TestData_4="11111111111",
              TestData_5="11111111111",
              TestData_6="11111111111",
              TestData_7="11111111111",
              TestData_8="11111111111",
              TestData_9="11111111111",
              TestData_10="11111111111",
            };
            for (int i = 0; i < 30; i++)
            {
                list.Add(pe);
            }
            return Content(new LayUIResult() { code = 0, msg = "", count = 8000, data = list }.ToJson());
        }
    }
}