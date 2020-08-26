using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.entity.request.bases;

namespace sign_sdk_net.entity.request.auth
{
    /// <summary>
    /// 实人认证查询 请求参数
    /// </summary>
    public class AliPayQueryRequest : BaseSignRequest
    {
        /// <summary>
        /// 认证id
        /// </summary>
        public string certifty_id { set; get; }
    }
}
