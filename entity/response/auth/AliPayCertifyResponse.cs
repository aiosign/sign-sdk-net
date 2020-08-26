using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.response.auth
{
    /// <summary>
    /// 支付宝认证-开始认证 响应值
    /// </summary>
    public class AliPayCertifyResponse
    {
        /// <summary>
        /// 认证id
        /// </summary>
        public string certify_id { set; get; }
        /// <summary>
        /// 调起支付宝url
        /// </summary>
        public string url { set; get; }
    }
}
