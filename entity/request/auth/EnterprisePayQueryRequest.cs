using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.entity.request.bases;

namespace sign_sdk_net.entity.request.auth
{
    /// <summary>
    /// 企业打款查询
    /// </summary>
    public class EnterprisePayQueryRequest : BaseSignRequest
    {
        /// <summary>
        /// 订单Id
        /// </summary>
        public string order_id { set; get; }
        /// <summary>
        /// 企业银行账户
        /// </summary>
        public string account_no { set; get; }
    }
}
