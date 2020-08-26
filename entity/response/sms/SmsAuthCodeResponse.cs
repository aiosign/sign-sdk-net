using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.response.sms
{
    /// <summary>
    /// 短信验证 响应参数
    /// </summary>
    public class SmsAuthCodeResponse
    {
        public List<PhoneInfo> phones { set; get; }
    }

    public class PhoneInfo
    {
        /// <summary>
        /// 自定义id
        /// </summary>
        public string custom_id { set; get; }
        /// <summary>
        /// 验证码id
        /// </summary>
        public string uuid { set; get; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string phone { set; get; }
        /// <summary>
        /// 短信发送结果
        /// </summary>
        public string status { set; get; }
    }
}
