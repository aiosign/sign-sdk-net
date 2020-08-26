using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.entity.request.bases;

namespace sign_sdk_net.entity.request.auth
{
    /// <summary>
    /// 获取百度身份验证-身份验证
    /// </summary>
    public class BaiDuAiFaceCertifyVerifyRequest : BaseSignRequest
    {
        /// <summary>
        /// 认证图片base64
        /// </summary>
        public string image { set; get; }
        /// <summary>
        /// 认证证件号码
        /// </summary>
        public string id_card_number { set; get; }
        /// <summary>
        /// 认证人员姓名
        /// </summary>
        public string name { set; get; }
    }
}
