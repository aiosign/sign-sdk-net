using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.response.sign
{
    /// <summary>
    /// 一步签署 返回参数
    /// </summary>
    public class DirectSignResponse
    {
        /// <summary>
        /// 签章id
        /// </summary>
        public string sign_id { set; get; }
        /// <summary>
        /// 文件id
        /// </summary>
        public string contract_file { set; get; }
        /// <summary>
        /// 签章状态
        /// </summary>
        public string sign_state { set; get; }
        /// <summary>
        /// 签章完成后 hash 值
        /// </summary>
        public string hash { set; get; }
        /// <summary>
        /// 签署时间
        /// </summary>
        public string sign_time { set; get; }
        /// <summary>
        /// 签署人
        /// </summary>
        public string signer { set; get; }
        /// <summary>
        /// 证书序列号
        /// </summary>
        public string cert_sn { set; get; }
        /// <summary>
        /// 证书颁发者
        /// </summary>
        public string cert_issuer { set; get; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string message { set; get; }
    }
}
