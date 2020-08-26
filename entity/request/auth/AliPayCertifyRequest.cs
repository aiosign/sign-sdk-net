using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.entity.request.bases;

namespace sign_sdk_net.entity.request.auth
{
    /// <summary>
    /// 实人认证 请求参数
    /// </summary>
    public class AliPayCertifyRequest : BaseSignRequest
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string name { set; get; }
        /// <summary>
        /// 身份证号码
        /// </summary>
        public string id_card_num { set; get; }
        /// <summary>
        /// 认证模式
        /// </summary>
        public string certify_type { set; get; }
    }
}
