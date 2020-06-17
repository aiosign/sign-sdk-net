using sign_sdk_net.entity.request.bases;
using sign_sdk_net.entity.response.signCheck;
using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.request.signCheck
{
    /// <summary>
    /// 文件验签请求对象
    /// </summary>
    public class SignCheckFileResponse
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
        /// 签署详情
        /// </summary>
        public List<SignCheckResult> sign_check_results { get; set; }

    }
}
