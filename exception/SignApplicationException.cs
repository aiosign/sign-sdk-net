using sign_sdk_net.entity.response;
using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.exception
{
    class SignApplicationException : Exception
    {

        /// <summary>
        /// 返回响应值 -- 网关
        /// </summary>
        public string return_code { get; set; }
        /// <summary>
        /// 异常信息 -- 网关
        /// </summary>
        public string return_message { get; set; }
        /// <summary>
        /// 请求数据
        /// </summary>
        public string request_body { get; set; }
        public SignApplicationException(string message, BaseSignResponse response,string requestBody) : base(message)
        {
            this.return_code = response.return_code;
            this.return_message = response.return_message;
            this.request_body = requestBody;
        }
    }
}
