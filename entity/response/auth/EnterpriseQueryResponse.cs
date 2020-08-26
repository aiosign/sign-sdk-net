using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.response.auth
{
    /// <summary>
    /// 企业三要素认证
    /// </summary>
    public class EnterpriseQueryResponse
    {
        /// <summary>
        /// 匹配的企业法人
        /// </summary>
        public string oper_name { set; get; }
        /// <summary>
        /// 匹配的公司名称
        /// </summary>
        public string name { set; get; }
        /// <summary>
        ///
        /// </summary>
        public int status { set; get; }
    }
}
