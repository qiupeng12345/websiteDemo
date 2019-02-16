using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACA_System.Areas.UserManage.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace ACA_Data.SqlService
{
    /// <summary>
    /// 用户信息服务类
    /// </summary>
    public class UserService
    {
        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        public List<UserEntity> GetUser()
        {
            using (IDbConnection db = new SqlConnection(DbHelper.connectString))
            {
                string strSql = "select * from Users";
                IEnumerable<UserEntity> list = db.Query<UserEntity>(strSql);
                return list.ToList<UserEntity>();
            }
        }
        public UserEntity GetUser(string account)
        {

            using (IDbConnection db = new SqlConnection(DbHelper.connectString))
            {
                string sql = "select  * from Users where UserAccount= @UserAccount";
                
                List<UserEntity> list = db.Query<UserEntity>(sql,new { UserAccount = account }).ToList<UserEntity>();
                if (list.Count > 0)
                {
                    return list[0];
                }
                else return null;
            }
        }
        /// <summary>
        /// 添加新用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int AddUser(UserEntity user)
        {
            using (IDbConnection db = new SqlConnection(DbHelper.connectString))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append(" insert into Users");
                strSql.Append(" (UserName,UserAccount,UserPassword,UserCompany,UserPart,UserAuthority,UserPhone,UserAddress,UserSex)");
                strSql.Append(" values(@UserName,@UserAccount, @UserPassword, @UserCompany, @UserPart, @UserAuthority, @UserPhone, @UserAddress, UserSex)");
                SqlParameter[] ps =
                {
                    new SqlParameter("@UserName",user.UserName),
                    new SqlParameter("@UserAccount",user.UserAccount),
                    new SqlParameter("@UserPassword",user.UserPassword),
                    new SqlParameter("@UserCompany",user.UserCompany),
                    new SqlParameter("@UserPart",user.UserPart),
                    new SqlParameter("@UserAuthority",user.UserAuthority),
                    new SqlParameter("@UserPhone",user.UserPhone),
                    new SqlParameter("@UserAddress",user.UserAddress),
                    new SqlParameter("@UserSex",user.UserSex),
                };
                return db.Execute(strSql.ToString(), ps);
            }
        }
        /// <summary>
        /// 更新一条用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int UpdateUser(UserEntity user)
        {
            using (IDbConnection db = new SqlConnection(DbHelper.connectString))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append(" update users set");
                strSql.Append(" UserName=@UserName,UserAccount=@UserAccount,UserPassword=@UserPassword,");
                strSql.Append(" UserCompany=@UserCompany,UserPart=@UserPart,UserAuthority=@UserAuthority,");
                strSql.Append(" UserPhone=@UserPhone,UserAddress=@UserAddress,UserSex=@UserSex");
                strSql.Append(" where UserId=@UserId");
                SqlParameter[] ps =
                {
                    new SqlParameter("@UserId",user.UserId),
                    new SqlParameter("@UserName",user.UserName),
                    new SqlParameter("@UserAccount",user.UserAccount),
                    new SqlParameter("@UserPassword",user.UserPassword),
                    new SqlParameter("@UserCompany",user.UserCompany),
                    new SqlParameter("@UserPart",user.UserPart),
                    new SqlParameter("@UserAuthority",user.UserAuthority),
                    new SqlParameter("@UserPhone",user.UserPhone),
                    new SqlParameter("@UserAddress",user.UserAddress),
                    new SqlParameter("@UserSex",user.UserSex),
                };
                return db.Execute(strSql.ToString(), ps);
            }
        }
    }
}
