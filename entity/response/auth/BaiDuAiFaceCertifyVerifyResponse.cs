using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.response.auth
{
    /// <summary>
    /// 获取百度身份验证-身份验证 响应值
    /// </summary>
    public class BaiDuAiFaceCertifyVerifyResponse
    {
        /// <summary>
        /// 结果
        /// </summary>
        public Dictionary<string, string> result { set; get; }
    }
}
