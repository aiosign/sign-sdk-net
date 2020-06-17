using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.IO;


namespace sign_sdk_net
{
    /// <summary>
    /// 支持 JSON 字符串和对象之间的转换(支持"集合"、"数组"类型)。
    /// </summary>
    static class JSONUtil
    {
        /// <summary>
        /// 此方法可以将任何类型对象转换成对应的JSON字符串
        /// </summary>
        /// <param name="obj">将要被转换的对象</param>
        /// <returns>转换成功后的JSON字符串，返回为null代表转换失败</returns>
        public static String getJsonStringFromObject(Object obj)
        {
            String jsonString = null;
            try
            {
                jsonString = JsonConvert.SerializeObject(obj);
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }




            return jsonString;
        }


        /// <summary>
        /// 此方法可以将JSON字符串转换成任何指定类型的对象(JSON字符串需要和指定类型匹配)
        /// </summary>
        /// <typeparam name="T">指定的对象类型</typeparam>
        /// <param name="jsonString">将要被转换的JSON字符串</param>
        /// <returns>转换成功得到的对象，返回为null代表转换失败</returns>
        public static T getObjectFromJsonString<T>(String jsonString) where T : class
        {
            try
            {
                JsonSerializer serializer = new JsonSerializer();
                StringReader sr = new StringReader(jsonString);
                object result = serializer.Deserialize(new JsonTextReader(sr), typeof(T));
                T obj = result as T;
                return obj;
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }




            return null;
        }
         
    }


}
