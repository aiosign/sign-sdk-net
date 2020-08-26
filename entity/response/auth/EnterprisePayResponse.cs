using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.response.auth
{
    /// <summary>
    /// 企业打款 响应值
    /// </summary>
    public class EnterprisePayResponse
    {

        /// <summary>
        /// 打款结果
        /// </summary>
        public string res { set; get; }
        /// <summary>
        /// 打款响应信息
        /// </summary>
        public string message { set; get; }
        /// <summary>
        /// 打款流水Id
        /// </summary>
        public string order_id { set; get; }
        /// <summary>
        /// 打款银行账户
        /// </summary>
        public string account_no { set; get; }
    }
}
