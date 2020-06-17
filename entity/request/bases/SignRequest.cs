using sign_sdk_net.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace sign_sdk_net.entity.request.bases
{
    /// <summary>
    /// base 请求实体类
    /// </summary>
    public class SignRequest
    {
        /// <summary>
        /// 是否需要token 默认 true
        /// </summary>
        public Boolean needToken { get; set; } = true;
        /// <summary>
        /// 请求方法 enum HttpMethod 默认 post
        /// </summary>
        public HttpMethod httpMethod { get; set; } = HttpMethod.POST;
        /// <summary>
        /// 请求头类型 默认 ContentType.JSON 
        /// </summary>
        public string contentType { get; set; } = ContentType.JSON;
        /// <summary>
        /// 请求体
        /// </summary>
        public BaseSignRequest requestBody { get; set; }
        /// <summary>
        /// api 请求地址
        /// </summary>
        public string apiUrl { get; set; }
        /// <summary>
        /// 是否需要 sign
        /// </summary>
        public Boolean needSign { get; set; } = true;

        /// <summary>
        /// url 参数信息 
        /// </summary>
        public Dictionary<string, object> parames { get; set; }
        /// <summary>
        /// form 参数
        /// </summary>
        public Dictionary<string, object> forms { get; set; }

        /// <summary>
        /// 初始化request 对象
        /// </summary>
        /// <param name="body"></param>
        public SignRequest(BaseSignRequest body)
        {
            this.requestBody = body;
        }
    }
}
