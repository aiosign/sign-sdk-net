using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.response.sms
{
    /// <summary>
    /// 批量发送短信 响应值
    /// </summary>
    class SmsBatchResponse
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
