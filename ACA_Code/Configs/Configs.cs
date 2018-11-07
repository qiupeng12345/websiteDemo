using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ACA.Code
{
    /// <summary>
    /// 配置文件操作类
    /// </summary>
    public class Configs
    {
        private static Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        /// <summary>
        /// 根据key值获取value
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetValue(string key)
        {
            return ConfigurationManager.AppSettings[key].ToString().Trim();
        }
        /// <summary>
        /// 根据key改变value
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SetValue(string key,string value)
        {
            config.AppSettings.Settings[key].Value = value;
        }
    }
}
