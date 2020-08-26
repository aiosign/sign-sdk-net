using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.response.auth
{
    /// <summary>
    /// 企业打款验证 响应值
    /// </summary>
    public class EnterprisePayValidResponse
    {
        /// <summary>
        /// 企业打款验证结果
        /// </summary>
        public string res { set; get; }
        /// <summary>
        /// 企业打款验证响应信息
        /// </summary>
        public string message { set; get; }
        /// <summary>
        /// 打款银行账户
        /// </summary>
        public string account_no { set; get; }
    }
}
