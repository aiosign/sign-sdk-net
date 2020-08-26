using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.entity.request.bases;

namespace sign_sdk_net.entity.request.auth
{
    /// <summary>
    /// 企业三要素校验
    /// </summary>
    public class EnterpriseQueryRequest : BaseSignRequest
    {
        /// <summary>
        /// 注册号/统一社会信用代码
        /// </summary>
        public string keyword { set; get; }
        /// <summary>
        /// 公司名称
        /// </summary>
        public string name { set; get; }
        /// <summary>
        /// 企业法人
        /// </summary>
        public string oper_name { set; get; }
    }
}
