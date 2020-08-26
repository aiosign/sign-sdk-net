using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.response.auth
{
    /// <summary>
    /// 支付宝认证-认证查询 响应值
    /// </summary>
    public class AliPayQueryResponse
    {

        /// <summary>
        /// 认证结果 T成功； F失败
        /// </summary>
        public string query_result { set; get; }
    }
}
