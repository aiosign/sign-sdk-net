using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.util
{
    class URLUtil
    {
        /// <summary>
        /// 参数拼接Url
        /// </summary>
        /// <param name="source">要拼接的实体</param>
        /// <paramref name="IsStrUpper">是否开启首字母大写,默认小写</paramref>
        /// <returns></returns>
        public static string ToPaeameter(string url, Dictionary<string, object> source)
        {
            if (source == null || source.Count == 0) {
                return url;
            }
            var buff = new StringBuilder(string.Empty);
            foreach (var item in source)
            {
                if (item.Value != null && item.Value.ToString() != string.Empty)
                {
                    buff.Append(item.Key + "=" + item.Value);
                    buff.Append("&");
                }
            }
            string paramStr = buff.ToString().Trim('&');
            return url.IndexOf("?") > 0 ? url + paramStr : url + "?" + paramStr;
        }
    }
}
