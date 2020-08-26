using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.entity.request.bases;

namespace sign_sdk_net.entity.request.sms
{
    /// <summary>
    /// 验证短信验证码 请求参数
    /// </summary>
    public class SmsValidAuthCodeRequest:BaseSignRequest
    {
        /// <summary>
        /// 验证码id
        /// </summary>
        public string uuid { set; get; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string phone { set; get; }

        /// <summary>
        /// 验证码
        /// </summary>
        public string auth_code { set; get; }
    }
}
