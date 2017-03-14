using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WXPageService.Heplers
{
    public static class ToolsHelper
    {
        private static DateTime BaseTime = new DateTime(1970, 1, 1);//Unix起始时间

        /// <summary>
        /// 转换成微信时间。
        /// </summary>
        /// <param name="dateTime">系统时间。</param>
        /// <returns>微信时间。</returns>
        public static long ToWeixinTime(this DateTime dateTime)
        {
            return (dateTime.Ticks - BaseTime.Ticks) / 10000000 - 8 * 60 * 60;
        }
    }
}
