using sign_sdk_net.constant;
using sign_sdk_net.entity;
using sign_sdk_net.entity.request;
using sign_sdk_net.entity.request.bases;
using sign_sdk_net.entity.response;
using sign_sdk_net.enums;
using sign_sdk_net.exception;
using sign_sdk_net.util;
using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.client
{
    /// <summary>
    /// 客户端分块 base
    /// </summary>
    public class BaseClient
    {
        public string baseUrl;
        private TokenDataSource tokenDataSource;
        /// <summary>
        /// token_key
        /// </summary>
        private const string token_key = "Authentication";
        /// <summary>
        /// access_token_key
        /// </summary>
        public const string access_token_key = "access_token";
        /// <summary>
        /// sign_key
        /// </summary>
        private const string sign_key = "sign";
        /// <summary>
        /// 应用id
        /// </summary>
        private string appId { get; set; }
        /// <summary>
        /// 应用秘钥
        /// </summary>
        private string appSecret { get; set; }
        public BaseClient(string baseUrl, TokenDataSource tokenDataSource, string appId, string appSecret)
        {
            this.baseUrl = baseUrl;
            this.tokenDataSource = tokenDataSource;
            this.appId = appId;
            this.appSecret = appSecret;
        }
        /// <summary>
        /// 检测token状态，不存在则获取，存在且过期则重新获取
        /// </summary>
        /// <returns></returns>
        internal Token getToken()
        {

            Token token = tokenDataSource.getToken(appId);

            // token 不存在 || 已过期
            if (token == null || DateTimeUtil.reduced(DateTimeUtil.AddDateTimeFormat(token.expires_in), new DateTime()) < 1)
            {
                return saveToken();
            }
            return token;
        }
        /// <summary>
        /// 保存token
        /// </summary>
        /// <returns></returns>
        private Token saveToken()
        {
            // body 体
            TokenRequest tokenRequest = new TokenRequest();
            tokenRequest.app_id = this.appId;
            tokenRequest.app_secret = this.appSecret;
            // 创建 请求对象
            SignRequest request = new SignRequest(tokenRequest);
            request.apiUrl = ApiUrlConstant.Token.GetToken;
            request.contentType = ContentType.JSON;
            request.needSign = false;
            request.needToken = false;
            request.httpMethod = HttpMethod.POST;
            // 发送请求
            TokenResponse res = Send<TokenResponse>(request);
            // 创建业务对象
            Token token = new Token();
            token.access_token = res.access_token;
            token.expires_in = res.expires_in;
            token.scopy = res.scopy;
            token.token_type = res.token_type;
            // 放入token 存储池
            tokenDataSource.deleteToken(this.appId);
            tokenDataSource.setToken(this.appId, token);
            return token;
        }



        /// <summary>
        /// 发起 http 请求并 
        /// </summary>
        /// <typeparam name="T">响应数据实体对象</typeparam>
        /// <param name="request">请求对象</param>
        /// <returns></returns>
        protected T Send<T>(SignRequest request) where T : class
        {
            // 创建url
            string url = URLUtil.ToPaeameter(baseUrl + request.apiUrl, request.parames);
            // 头部
            Dictionary<string, string> headers = new Dictionary<string, string>();
            string body = JSONUtil.getJsonStringFromObject(request.requestBody);

            if (request.needSign)
            {
                string sign = SignUtil.createSign(body, appSecret);
                headers.Add(sign_key, sign);
                //Console.WriteLine("请求sign:" + sign);
            }
            if (request.needToken)
            {
                headers.Add(token_key, getToken().access_token);
            }

            // 发起http 请求
            string responseStr = HttpSendUtil.SentHttpRequest(url, request.httpMethod, headers, request.contentType, body);
            // 转换为 response 对象
            BaseSignResponse response = JSONUtil.getObjectFromJsonString<BaseSignResponse>(responseStr);
            // 抛出 网关异常
            if (response.return_code != "1000")
            {
                throw new SignApplicationException(response.return_message, response, body);
            }
            // 抛除 服务异常
            if (response.result_code != "0")
            {
                throw new SignServerException(response.result_message, response, body);
            }
            return response.GetData<T>();
        }
        /// <summary>
        /// 文件上传功能
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="fileInfo"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        protected T FileUpload<T>(string apiUrl, FileInfo fileInfo, Dictionary<string, string> parameters) where T : class
        {
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add(token_key, getToken().access_token);
            List<FileInfo> files = new List<FileInfo>();
            files.Add(fileInfo);
            string responseStr = HttpSendUtil.SendHttpForm(baseUrl + apiUrl, headers, files, parameters);
            // 转换为 response 对象
            BaseSignResponse response = JSONUtil.getObjectFromJsonString<BaseSignResponse>(responseStr);
            // 抛出 网关异常
            if (response.return_code != "1000")
            {
                throw new SignApplicationException(response.return_message, response,null);
            }
            // 抛除 服务异常
            if (response.result_code != "0")
            {
                throw new SignServerException(response.result_message, response,null);
            }
            return response.GetData<T>();
        }




    }
}
