using sign_sdk_net.entity.response;
using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.exception
{
    /// <summary>
    /// 服务层
    /// </summary>
    class SignServerException : Exception
    {
        /// <summary>
        /// 返回响应值 -- 业务层
        /// </summary>
        public string result_code { get; set; }
        /// <summary>
        /// 请求对象
        /// </summary>
        public string request_body { get; set; }
        /// <summary>
        /// 返回
        /// </summary>
        public string result_message { get; set; }
        public SignServerException(string message, BaseSignResponse response, string requestBody) : base(message)
        {
            this.result_code = response.result_code;
            this.result_message = response.result_message;
            this.request_body = requestBody;
        }
    }
}
