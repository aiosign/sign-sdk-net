using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.response.signCheck
{
    /// <summary>
    /// 文件验证响应对象
    /// </summary>
    class SignCheckCommonResponse
    {
        /// <summary>
        /// 验证信息
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 验证结果
        /// </summary>
        public Boolean result { get; set; }
        /// <summary>
        /// 验证结果
        /// </summary>
        public List<SignCheckResult> sign_check_results { get; set; }
    }
}
