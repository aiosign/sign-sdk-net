using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.entity.request.bases;

namespace sign_sdk_net.entity.request.auth
{
    /// <summary>
    /// 加密请求下三网认证 请求参数
    /// </summary>
    public class AuthEncryRequest : BaseSignRequest
    {
        /// <summary>
        /// 名字
        /// </summary>
        public string name { set; get; }
        /// <summary>
        /// 身份证号码
        /// </summary>
        public string id_card { set; get; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string phone { set; get; }
    }
}
