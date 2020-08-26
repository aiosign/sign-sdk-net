using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.response.auth
{
    /// <summary>
    /// 获取百度身份验证-语音验证数据 响应值
    /// </summary>
    public class BaiduSessionCodeResponse
    {
        /// <summary>
        /// 本次回话id
        /// </summary>
        public string session_id { set; get; }
        /// <summary>
        /// 验证码
        /// </summary>
        public string code { set; get; }
    }
}
