using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.entity.request.bases;

namespace sign_sdk_net.entity.request.auth
{
    /// <summary>
    /// 企业打款
    /// </summary>
    public class EnterprisePayRequest : BaseSignRequest
    {
        /// <summary>
        /// 企业代码类型,1：社会统一代码，3：工商注册号
        /// </summary>
        public string key_type { set; get; }
        /// <summary>
        /// 企业代码
        /// </summary>
        public string key { set; get; }
        /// <summary>
        /// 企业名称
        /// </summary>
        public string name { set; get; }
        /// <summary>
        /// 法人名称
        /// </summary>
        public string usr_name { set; get; }
        /// <summary>
        /// 企业银行账户
        /// </summary>
        public string account_no { set; get; }
        /// <summary>
        /// 企业开户行
        /// </summary>
        public string account_bank { set; get; }
        /// <summary>
        /// 企业开户行所在省份
        /// </summary>
        public string account_province { set; get; }
        /// <summary>
        /// 企业开户行所在城市
        /// </summary>
        public string account_city { set; get; }
    }
}
