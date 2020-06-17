using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace sign_sdk_net.util
{
    /// <summary>
    /// 请求签名工具类
    /// </summary>
    static class SignUtil
    {
        /// <summary>
        /// 创建签名
        /// </summary>
        /// <param name="json"></param>
        /// <param name="signKey"></param>
        /// <returns></returns>
        public static string createSign(string json, string signKey)
        {
            // 去除空格
            string temp = Regex.Replace(json, @"\s", "");
            // HmacSHA256 加密
            string hmacSHA256Str = HmacSHA256(temp, signKey);
            // MD5 加密
            string md5 = GetMD5(hmacSHA256Str);
            Console.WriteLine("MD5：" + md5);
            return md5.ToUpper();
        }
        private static string HmacSHA256(string message, string secret)
        {
            secret = secret ?? "";
            byte[] keyByte = Encoding.UTF8.GetBytes(secret);
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
                return Convert.ToBase64String(hashmessage);
            }
        }
        public static string GetMD5(string myString)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            //byte[] fromData = System.Text.Encoding.Unicode.GetBytes(myString);
            byte[] fromData = System.Text.Encoding.UTF8.GetBytes(myString);//
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("X2");
            }

            return byte2String;
        }

    }
}