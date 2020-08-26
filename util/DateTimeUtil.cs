using System;
using System.Linq;
using System.Text;

namespace sign_sdk_net.util
{
    /// <summary>
    /// 时间工具类
    /// </summary>
    static class DateTimeUtil
    {
        /// <summary>
        /// Unix时间起始时间
        /// </summary>
        public static readonly DateTime StarTime = new DateTime(1970, 1, 1);

        /// <summary>
        /// 常用日期格式
        /// </summary>
        public static readonly string CommonDateFormat = "yyyy-MM-dd HH:mm:ss";

        /// <summary>
        /// 周未定义
        /// </summary>
        public static readonly DayOfWeek[] Weekend = { DayOfWeek.Saturday, DayOfWeek.Sunday };

        /// <summary>
        /// 获取从Unix起始时间到给定时间的毫秒数
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static long GetMillisecondsSince1970(this DateTime datetime)
        {
            var ts = datetime.Subtract(StarTime);
            return (long)ts.TotalMilliseconds;
        }

        /// <summary>
        /// 获取从Unix起始时间到给定时间的秒数
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static long GetSecondsSince1970(this DateTime datetime)
        {
            var ts = datetime.Subtract(StarTime);
            return (long)ts.TotalSeconds;
        }

        /// <summary>
        /// 明天
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime Tomorrow(this DateTime date)
        {
            return date.AddDays(1);
        }

        /// <summary>
        /// 昨天
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime Yesterday(this DateTime date)
        {
            return date.AddDays(-1);
        }

        /// <summary>
        /// 常用日期格式化字符串
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToStringFormat(this DateTime date)
        {
            return date.ToString(CommonDateFormat);
        }

        /// <summary>
        /// 时间字符串 转时间对象 yyyy-MM-dd HH:mm:ss
        /// </summary>
        /// <param name="dateStr">yyyy-MM-dd HH:mm:ss 格式的时间字符串</param>
        /// <returns></returns>
        public static DateTime ToDateTimeFormat(string dateStr)
        {
            return DateTime.ParseExact(dateStr, CommonDateFormat, System.Globalization.CultureInfo.CurrentCulture);
        }

        public static DateTime AddDateTimeFormat(string dateStr)
        {
           return DateTime.Now.AddMilliseconds(int.Parse(dateStr));
        }

        /// <summary>
        /// 是否是周未
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsWeekend(this DateTime date)
        {
            return Weekend.Any(p => p == date.DayOfWeek);
        }


        /// <summary>
        /// 给定月份的第1天
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime GetFirstDayOfMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }






        /// <summary>
        /// 早于给定日期
        /// </summary>
        /// <param name="date"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static bool IsBefore(this DateTime date, DateTime other)
        {
            return date.CompareTo(other) < 0;
        }

        /// <summary>
        /// 晚于给定日期
        /// </summary>
        /// <param name="date"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static bool IsAfter(this DateTime date, DateTime other)
        {
            return date.CompareTo(other) > 0;
        }

        /// <summary>
        /// 给定日期最后一刻,精确到23:59:59.999
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime EndTimeOfDay(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 999);
        }

        /// <summary>
        ///  给定日期开始一刻,精确到0:0:0.0
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime StartTimeOfDay(this DateTime date)
        {
            return date.Date;
        }

        /// <summary>
        ///  给定日期的中午,精确到12:0:0.0
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime NoonOfDay(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 12, 0, 0);
        }

        /// <summary>
        /// 当前日期与给定日期是否是同一天
        /// </summary>
        /// <param name="date">当前日期</param>
        /// <param name="dateToCompare">给定日期</param>
        /// <returns></returns>
        public static bool IsDateEqual(this DateTime date, DateTime dateToCompare)
        {
            return (date.Date == dateToCompare.Date);
        }

        /// <summary>
        /// 判断是否为今天
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsToday(this DateTime date)
        {
            return (date.Date == DateTime.Now.Date);
        }
        /// <summary>
        /// 判断两个时间的大小 
        /// </summary>
        /// <param name="one">第一个对比时间</param>
        /// <param name="two">第二个对比时间</param>
        /// <returns> 第一个时间大于第二个时间：[1]; 第二个时间大于第一个时间：[-1]; 数字相等：[0] </returns>
        public static int reduced(DateTime one, DateTime two)
        {
            long oneL = DateToTicks(one);
            long twoL = DateToTicks(two);
            if (oneL > twoL)
            {
                return 1;
            }
            else
            if (oneL == twoL)
            {
                return 0;
            }
            else
            {
                return -1;
            }


        }

        /// <summary>
        /// DateTime类型转换为时间戳(毫秒值)
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static long DateToTicks(DateTime? time)
        {
            return ((time.HasValue ? time.Value.Ticks : DateTime.Parse("1990-01-01").Ticks) - 621355968000000000) / 10000;
        }
    }
}
