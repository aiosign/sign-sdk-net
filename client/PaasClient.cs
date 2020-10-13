using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.entity;
using sign_sdk_net.entity.request.bases;
using sign_sdk_net.entity.response;
using sign_sdk_net.exception;
using sign_sdk_net.util;

namespace sign_sdk_net.client
{
    class PaasClient : BaseClient
    {
        public PaasClient(string baseUrl, TokenDataSource tokenDataSource, string appId, string appSecret) : base(baseUrl, tokenDataSource, appId, appSecret)
        {
        }

        public T Send<T>(SignRequest request) where T : class
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
    }
}
