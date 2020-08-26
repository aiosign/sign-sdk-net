using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.response.sms
{
    /// <summary>
    /// 验证-短信验证码 响应值
    /// </summary>
    public class SmsValidAuthCodeResponse
    {
        /// <summary>
        /// 手机号
        /// </summary>
        public string phone { set; get; }
        /// <summary>
        /// 验证结果
        /// </summary>
        public Boolean status { set; get; }
    }
}
