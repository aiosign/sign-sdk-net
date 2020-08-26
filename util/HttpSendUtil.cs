using sign_sdk_net.entity.request.bases;
using sign_sdk_net.enums;
using sign_sdk_net.util;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;

namespace sign_sdk_net
{
    public static class HttpSendUtil
    {
        /// <summary>
        /// 请求过期时间
        /// </summary>
        public static int timeOut { get; set; } = 3000;

        private static WebRequest cerateRequest(string url)
        {
            //定义request并设置request的路径
            WebRequest request = WebRequest.Create(url);
            request.Timeout = timeOut;
            return request;
        }
        /// <summary>
        /// 加载header
        /// </summary>
        /// <param name="headers"></param>
        /// <param name="request"></param>
        private static void loadHeader(Dictionary<string, string> headers, WebRequest request)
        {
            if (headers == null || headers.Count < 1)
            {
                return;
            }
            foreach (var item in headers)
            {
                request.Headers.Add(item.Key, item.Value);
            }
        }
        //注：本次请求为向androidpnserver发送请求实现后台向客户端的消息推送
        // url 请求路径 
        // requestBody 请求body 
        public static string SentHttpRequest(string url, HttpMethod httpMethod, Dictionary<string, string> headers, string contentType, string requestBody)
        {
            WebRequest request = cerateRequest(url);


            //定义请求的方式
            request.Method = httpMethod.ToString();
            // 添加header 数据
            loadHeader(headers, request);
            //初始化request参数
            string postData = requestBody;

            //设置参数的编码格式，解决中文乱码
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            //设置request的MIME类型及内容长度
            request.ContentType = contentType;

            request.ContentLength = byteArray.Length;

            //打开request字符流
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            // 发起http请求
            WebResponse response = null;
            try
            {
                //定义response为前面的request响应
                response = request.GetResponse();
            }
            catch (WebException ex)
            {
                //throw ex;
                response = (HttpWebResponse)ex.Response;
            }


            //获取相应的状态代码
            //Console.WriteLine("响应状态码：" + ((HttpWebResponse)response).StatusDescription);

            //定义response字符流
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();//读取所有
            //Console.WriteLine("响应数据：" + responseFromServer);

            //关闭资源
            reader.Close();
            dataStream.Close();
            response.Close();
            return responseFromServer;
        }


       /// <summary>
       /// 文件上传
       /// </summary>
       /// <param name="url">服务地址</param>
       /// <param name="headers">headers</param>
       /// <param name="files">文件列表</param>
       /// <param name="parameters">form 参数集</param>
        public static string SendHttpForm(string url, Dictionary<string, string> headers, List<FileInfo> files, Dictionary<string, string> parameters)
        {
            // 创建req;
            WebRequest webRequest = cerateRequest(url);

            // 边界符
            var boundary = "---------------" + DateTime.Now.Ticks.ToString("x");
            webRequest.Method = "POST"; 
            // 加载header  
            loadHeader(headers, webRequest);

            webRequest.ContentType = "multipart/form-data; boundary=" + boundary;
            // 开始边界符
            var beginBoundary = Encoding.ASCII.GetBytes("--" + boundary + "\r\n");
            // 结束结束符
            var endBoundary = Encoding.ASCII.GetBytes("--" + boundary + "--\r\n");
            var newLineBytes = Encoding.UTF8.GetBytes("\r\n");
            using (var stream = new MemoryStream())
            {
                // 写入开始边界符
                stream.Write(beginBoundary, 0, beginBoundary.Length);
                // 写入文件信息
                foreach (var item in files) {
                    // 写入文件
                    var fileHeader = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\r\n" +
                                     "Content-Type: application/octet-stream\r\n\r\n";
                    var fileHeaderBytes = Encoding.UTF8.GetBytes(string.Format(fileHeader, item.key, item.fileName));
                    stream.Write(fileHeaderBytes, 0, fileHeaderBytes.Length);
                    stream.Write(item.fileData, 0, item.fileData.Length);
                    stream.Write(newLineBytes, 0, newLineBytes.Length);
                }
               
                // 写入字符串
                var keyValue = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}\r\n";
                foreach (string key in parameters.Keys)
                {
                    var keyValueBytes = Encoding.UTF8.GetBytes(string.Format(keyValue, key, parameters[key]));
                    stream.Write(beginBoundary, 0, beginBoundary.Length);
                    stream.Write(keyValueBytes, 0, keyValueBytes.Length);
                }
                // 写入结束边界符
                stream.Write(endBoundary, 0, endBoundary.Length);
                webRequest.ContentLength = stream.Length;
                stream.Position = 0;
                var tempBuffer = new byte[stream.Length];
                stream.Read(tempBuffer, 0, tempBuffer.Length);
                using (Stream requestStream = webRequest.GetRequestStream())
                {
                    requestStream.Write(tempBuffer, 0, tempBuffer.Length);
                    using (var response = webRequest.GetResponse())
                    using (StreamReader httpStreamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    {
                        string result = httpStreamReader.ReadToEnd();
                        return result;
                    }
                }
            }
        }
    }
    /// <summary>
    /// 文件信息
    /// </summary>
    public class FileInfo {
        /// <summary>
        /// 文件在 request 中的 请求name
        /// </summary>
        public string key { get; set; }
        /// <summary>
        /// 文件名称
        /// </summary>
        public string fileName { get; set; }
        /// <summary>
        /// 文件数据
        /// </summary>
        public byte[] fileData { get; set; }
    }

}
