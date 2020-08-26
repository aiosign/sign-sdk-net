using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.entity.request.bases;

namespace sign_sdk_net.entity.request.auth
{
    /// <summary>
    /// 企业打款验证 请求参数
    /// </summary>
    public class EnterprisePayValidRequest : BaseSignRequest
    {
        /// <summary>
        /// 订单Id
        /// </summary>
        public string order_id { set; get; }
        /// <summary>
        /// 企业银行账户
        /// </summary>
        public string account_no { set; get; }
        /// <summary>
        /// 金额（分）
        /// </summary>
        public int amount { set; get; }
    }
}
