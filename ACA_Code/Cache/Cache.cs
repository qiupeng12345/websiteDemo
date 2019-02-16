/*******************************************************************************
 * 处理缓存
 * 
 * author：qp
 * date: 2018/10
*********************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ACA.Code
{
    public class Cache : ICache
    {
        //获取缓存
        private static System.Web.Caching.Cache cache = HttpRuntime.Cache;
        /// <summary>
        /// 根据cacheKey获取缓存数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheKey"></param>
        /// <returns></returns>
        public T GetCache<T>(string cacheKey) where T:class
        {
            if (cache[cacheKey]!=null)
            {
                return (T)cache[cacheKey];
            }
            return default(T);
        }
        /// <summary>
        /// 添加一条新的缓存
        /// </summary>
        /// <typeparam name="T"> 泛型</typeparam>
        /// <param name="value">值</param>
        /// <param name="cacheKey">键</param>
        public void WriteCache<T>(T value,string cacheKey) where T:class
        {
            cache.Insert(cacheKey, value, null, DateTime.Now.AddMinutes(10), System.Web.Caching.Cache.NoSlidingExpiration);
        }
        /// <summary>
        /// 添加一条缓存数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="cacheKey"></param>
        /// <param name="expireTime"> 过期时间</param>
        public void WriteCache<T>(T value,string cacheKey,DateTime expireTime) where T : class
        {
            cache.Insert(cacheKey, value, null, expireTime, System.Web.Caching.Cache.NoSlidingExpiration);
        }
        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <param name="cacheKey"></param>
        public void RemoveCache(string cacheKey)
        {
            cache.Remove(cacheKey);
        }
        /// <summary>
        /// 删除缓存
        /// </summary>
        public void RemoveCache()
        {
            IDictionaryEnumerator CacheEnum = cache.GetEnumerator();
            while (CacheEnum.MoveNext())
            {
                cache.Remove(CacheEnum.Key.ToString());
            }
    }
}

        }