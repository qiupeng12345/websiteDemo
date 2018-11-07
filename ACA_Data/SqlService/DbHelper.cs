using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACA_Data.SqlService
{
    /// <summary>
    /// 数据库帮助类
    /// </summary>
    public  class DbHelper
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        public static string connectString
        {
            get { return ConfigurationManager.ConnectionStrings["ACADbContext"].ConnectionString; }
        }
        
    }
}
