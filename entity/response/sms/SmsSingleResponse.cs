using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.response.sms
{
    /// <summary>
    /// 单次短信发送 响应值
    /// </summary>
    public class SmsSingleResponse
    {
        /// <summary>
        /// 手机号
        /// </summary>
        private string phone { set; get; }
        /// <summary>
        /// 发送结果
        /// </summary>
        private Boolean result { set; get; }
    }
}
