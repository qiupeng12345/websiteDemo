using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ACA.Code;
using ACA_System;
using ACA_Data.SqlService;
using ACA_System.Areas.UserManage.Models;
namespace ACA_System.Controllers
{
    public class LoginController : Controller
    {
        UserService userService = new UserService();
        // GET: Login
        [HttpGet]
        public virtual ActionResult Index()
        {
            var test = string.Format("{0:E2}", 1);
            return View();
        }
        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <returns></returns>
        [HttpGet] 
        public ActionResult GetAuthCode()
        {
            return File(new VerifyCode().GetVerifyCode(), @"image/Gif");
        }
        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult OutLogin()
        {
            return RedirectToAction("Index", "Login");
        }
        /// <summary>
        /// 登录校验
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpPost]
        [HandlerAjaxOnly]
        public ActionResult CheckLogin(string account, string password, string code)
        {
            
            try
            {
                if (Session["ACA_session_verifycode"].IsEmpty() || Md5.md5(code.ToLower(), 16) != Session["ACA_session_verifycode"].ToString())
                {
                    throw new Exception("验证码错误，请重新输入");
                }
                UserEntity user = userService.GetUser(account);
                if (user!=null)
                {
                    if (user.UserPassword==password)
                    {
                        Session["CurrentUser"] = user;
                        Session.Timeout=5;
                        return Content(new AjaxResult { state = ResultType.success.ToString(), message = "登录成功。" }.ToJson());
                    }
                    else return Content(new AjaxResult { state = ResultType.error.ToString(), message = "密码错误，请重新登录" }.ToJson());
                }
                else return Content(new AjaxResult { state = ResultType.error.ToString(), message = "查无此用户" }.ToJson());
            }
            catch (Exception ex)
            {
                return Content(new AjaxResult { state = ResultType.error.ToString(), message = ex.Message }.ToJson());
            }
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View("Index");
        }
    }
} 