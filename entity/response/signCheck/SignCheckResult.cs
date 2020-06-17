using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.response.signCheck
{
    /// <summary>
    /// 签章验证结果项
    /// </summary>
    public class SignCheckResult
    {
        /// <summary>
        /// 签署结果
        /// </summary>
        public Boolean result { get; set; }
        /// <summary>
        /// 签署页码
        /// </summary>
        public int? page_number { get; set; }
        /// <summary>
        /// 证书序列号
        /// </summary>
        public string cert_sn { get; set; }
        /// <summary>
        /// 签署日期
        /// </summary>
        public string sign_time { get; set; }
        /// <summary>
        /// 时间戳日期
        /// </summary>
        public string timestamp { get; set; }
        /// <summary>
        /// 签署人
        /// </summary>
        public string signer { get; set; }

    }
}
