using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.response.sms
{
    /// <summary>
    /// 单次短信发送 响应值
    /// </summary>
    class SmsSingleResponse
    {
        /// <summary>
        /// 手机号
        /// </summary>
        public string phone { set; get; }
        /// <summary>
        /// 发送结果
        /// </summary>
        public Boolean result { set; get; }
    }
}
