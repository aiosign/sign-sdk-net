using sign_sdk_net.entity.request.bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.request
{
    /// <summary>
    /// 获取token 请求对象
    /// </summary>
    class TokenRequest : BaseSignRequest
    {
        /// <summary>
        /// 应用id
        /// </summary>
        public string app_id { get; set; }
        /// <summary>
        /// 应用秘钥
        /// </summary>
        public string app_secret { get; set; }
        /// <summary>
        /// 授权类型
        /// </summary>
        public string grant_type { get; set; } = "client_credentials";
    }
}
