# 大众签章开放平台Api接口.net版SDK 

#### 环境说明：
- 1.您需要去大众签章开放平台注册开发者账号，并且申请应用，当您的应用经过审核之后，您将获得一个appid和appsecret，这两个参数决定了您在开放平台的身份标识，只有获得了这两个参数，您才有资格调用开放平台的api接口。 
- 2.您需要凭借appid和appsecret获取token，某些接口还需要传递签名值(后续会详细介绍),才可调用开放平台的api接口。 
- 3.sdk采用了Newtonsoft.Json依赖项，所以您首先需要在您的VisualStudio中安装Newtonsoft.Json依赖项，详情可以参考[lombok插件安装参考文档][233455667665] 
#### Visual Studio 安装使用 Newtonsoft Json 
[233455667665]: https://www.cnblogs.com/mrraobx/articles/11903807.html "Visual Studio 安装使用 Newtonsoft Json"  
#### 使用说明：
以下这个代码示例向您展示了调用 Sign SDK for .NET 的3个主要步骤：
- 1.实现Token存储池功能（推荐使用redis，demo中为Dictionary实现。）
- 2.创建http客户端实例并初始化。 
- 3.创建API请求对象并设置参数。 
- 4.发起请求并处理应答或异常。 
```C#
		/// <summary>
        /// token 存储池实现类
        /// </summary>
        public class DictionaryTokenDataSource : TokenDataSource
        {
            Dictionary<string, Token> dataSource = new Dictionary<string, Token>();
            Token TokenDataSource.deleteToken(string appId)
            {
                TokenDataSource ds = (TokenDataSource)this;
                Token token = ds.getToken(appId);
                dataSource.Remove(appId);
                return token;
            }
            Token TokenDataSource.getToken(string appId)
            {
                if (dataSource.ContainsKey(appId))
                {
                    return dataSource[appId];
                }
                return null;
            }
            Token TokenDataSource.setToken(string appId, Token token)
            {
                TokenDataSource ds = (TokenDataSource)this;
                ds.deleteToken(appId);
                dataSource.Add(appId, token);
                return token;
            }

        }
        static void Main(string[] args)
        {
            // 大众签章开放平台 API 接口 Bass URL
            const string baseUrl = "http://127.0.0.1:80";
            const string appId = "Your AppId.";
            const string appSecret = "Your AppSecret.";
            // token 存储池需自行实现相关接口
            TokenDataSource tokenDS = new DictionaryTokenDataSource();
            // 初始话 客户端对象 
            SignClient client = null;
            try
            {
                client = new SignClient(baseUrl, tokenDS, appId, appSecret);
            }
            catch (SignClientInitException e)
            {
                // 初始化时将进行数据校验，失败时将抛除 init exception 
                Console.WriteLine(e.Message);
            }

            // 创建个人用户 begin
            PersonalRegisterRequest personalRegisterRequest = new PersonalRegisterRequest();
            // 地区编码
            personalRegisterRequest.area_code = "370000";
            // 描述信息
            personalRegisterRequest.description = "描述信息：该用户位示例用户";
            personalRegisterRequest.id_number = "370000123456712123";
            // 证件类型
            personalRegisterRequest.id_type = IdType.IDCARD;
            // Email
            personalRegisterRequest.mail = "123456@sdgd.com";
            // 手机号码
            personalRegisterRequest.phone = "13711111121";
            // 用户名称
            personalRegisterRequest.user_name = "测试用户1";
            try
            {
                PersonalRegisterResponse response = client.Personal.personalCertRegister(personalRegisterRequest);
                Console.WriteLine("个人用户以及证书注册完成：" + JSONUtil.getJsonStringFromObject(response)); 
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
        } 
```
SDK	中都有相关接口的测试用例，都已经经过相关测试，您可以修改参数执行相关方法。
#### 额外说明 
1.获取token
```C# 
		static void Main(string[] args)
        {
            // 大众签章开放平台 API 接口 Bass URL
            const string baseUrl = "http://127.0.0.1:80";
            const string appId = "Your AppId.";
            const string appSecret = "Your AppSecret.";
            // token 存储池需自行实现相关接口
            TokenDataSource tokenDS = new DictionaryTokenDataSource();
            // 初始话 客户端对象 
            SignClient client = null;
            try
            {
                client = new SignClient(baseUrl, tokenDS, appId, appSecret);
            }
            catch (SignClientInitException e)
            {
                // 初始化时将进行数据校验，失败时将抛除 init exception 
                Console.WriteLine(e.Message);
            }
            string token = client.getToken();
        }
```
SDK中接口获取token的操作都已经封装好了，获取token成功后会缓存起来，token失效后会重新获取，无需手动管理。

2.签名算法  
开放平台api接口的所有的post请求并且请求头为json的接口添加了签名值的校验，签名算法的机制如下：
比如你的请求json为：
```json 
{
"app_id": "71051024588566****",
"app_secret": "UJhgoFkMShBtLX****",
"grant_type": "client_credent****"
}
```
首先对字符串做去空格化处理（包括\r\n），然后对字符串做HmacSHA256算法，秘钥为您的appsecret，编码一定要为UTF-8，否则可能会导致获取的加密值不同，然后转为base64编码的字符串的加密字符串，最后对该字符串做MD5摘要，最后的字符串将作为最终的签名值。
签名的工具类代码如下：
```C#  
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
```
