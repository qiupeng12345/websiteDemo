using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ACA_System.Areas.UserManage.Models;
using ACA.Code;

namespace ACA_System.Areas.UserManage.Controllers
{
    public class UserInfoController : Controller
    {
        // GET: UserManage/UserInfo
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 用户信息数据接口
        /// </summary>
        /// <returns></returns>
        public ActionResult GetUserInfo()
        {
            List<UserEntity> list = new List<UserEntity>();
            UserEntity ue = new UserEntity()
            {
                UserName = "仇鹏",
                UserId="001",
                UserCompany="ACA",
                UserAuthority="超级管理员",
                UserPart="软件部",
                UserPhone="88888888888",
                UserAddress="北京市中南海钓鱼台",
                UserSex="男",
                UserAccount="qiupeng",
                UserPassword="qiupeng123"
            };
            for (int i = 0; i < 10; i++)
            {
                list.Add(ue);
            }
            return Content(new LayUIResult() { code = 0, msg = "", count = 10, data = list }.ToJson());
        }
        /// <summary>
        /// 执行删除用户操作
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public ActionResult DeleteUser(string id,string name)
        {
            return Content(new AjaxResult() { state = "sucess", message = "删除成功", data = "" }.ToJson());
        }
        /// <summary>
        /// 执行添加用户操作
        /// </summary>
        /// <param name="name">姓名</param>
        /// <param name="account">账号</param>
        /// <param name="password">密码</param>
        /// <param name="sex">性别</param>
        /// <param name="company">公司</param>
        /// <param name="part">部门</param>
        /// <param name="authority">权限</param>
        /// <param name="phone">联系方式</param>
        /// <param name="address">地址</param>
        /// <returns></returns>
        public ActionResult AddUser(string name,string account,string password,string sex,string company,string part,string authority,string phone,string address)
        {
            UserEntity user = new UserEntity()
            {
                UserName = name,
                UserAccount = account,
                UserPassword = password,
                UserSex=sex,
                UserCompany=company,
                UserPart=part,
                UserAuthority=authority,
                UserPhone=phone,
                UserAddress=address
            };
            return Content(new AjaxResult() { state = "success", message = "", data = new object[]{name, account, password, sex, company, part, authority, phone, address } }.ToJson());
        }
        /// <summary>
        /// 添加用户表单视图
        /// </summary>
        /// <returns></returns>
        public ActionResult AddUserForm()
        {
            return View();
        }
        /// <summary>
        /// 编辑用户表单试图
        /// </summary>
        /// <returns></returns>
        public ActionResult EditUserForm()
        {
            return View();
        }
        /// <summary>
        /// 执行更新用户数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <param name="sex"></param>
        /// <param name="company"></param>
        /// <param name="part"></param>
        /// <param name="authority"></param>
        /// <param name="phone"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public ActionResult UpdateUser(string id,string name, string account, string password, string sex, string company, string part, string authority, string phone, string address)
        {
            return Content(new AjaxResult() { state = "success", message = "", data = new object[] { id,name, account, password, sex, company, part, authority, phone, address } }.ToJson());
        }
    }
}