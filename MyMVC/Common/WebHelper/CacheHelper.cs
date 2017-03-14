using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;

namespace Common
{
    /// <summary>
    /// 缓存辅助类
    /// </summary>
    public class CacheHelper
    {
        /// <summary>
        /// 获取缓存数据
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <returns></returns>
        public static object GetCache(string cacheKey)
        {
            Cache objCache = HttpRuntime.Cache;
            return objCache[cacheKey];
        }
        /// <summary>
        /// 设置缓存数据
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <param name="objObject"></param>
        public static void SetCache(string cacheKey, object objObject)
        {
            Cache objCache = HttpRuntime.Cache;
            objCache.Insert(cacheKey,objCache);
        }
        public static void SetCache(string cacheKey, object objObject, TimeSpan timeout)
        {
            Cache objCache = HttpRuntime.Cache;
            objCache.Insert(cacheKey, objObject, null, DateTime.MaxValue, timeout, System.Web.Caching.CacheItemPriority.NotRemovable, null);
        }
        public static void SetCache(string cacheKey, object objObject, SqlCacheDependency dep, DateTime absoluteExpiration, TimeSpan slidingExpiration)
        {
            
            Cache objCache = HttpRuntime.Cache;
            objCache.Insert(cacheKey, objObject, dep, absoluteExpiration, slidingExpiration);
        }
        public static void SetCache(string CacheKey, object objObject, DateTime absoluteExpiration, TimeSpan slidingExpiration)
        {
            Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject, null, absoluteExpiration, slidingExpiration);
        }
        /// <summary>
        /// 移除指定的缓存
        /// </summary>
        /// <param name="CacheKey"></param>
        public static void RemoveAllCache(string cacheKey)
        {
            Cache objCache = HttpRuntime.Cache;
            objCache.Remove(cacheKey);
        }
        /// <summary>
        /// 移除全部缓存
        /// </summary>
        public static void RemoveAllCache()
        {
            Cache objCache = HttpRuntime.Cache;
            IDictionaryEnumerator cacheEnum = objCache.GetEnumerator();
            while (cacheEnum.MoveNext())
            {
                objCache.Remove(cacheEnum.Key.ToString());
            }
        }
    }
}
