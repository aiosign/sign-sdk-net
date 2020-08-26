using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.entity.request.bases;

namespace sign_sdk_net.entity.request.auth
{
    /// <summary>
    /// 获取百度身份验证-语音验证数据 
    /// </summary>
    public class BaiDuAiFaceVideoVerifyRequest : BaseSignRequest
    {
        /// <summary>
        /// session id
        /// </summary>
        public string session_id { set; get; }
        /// <summary>
        /// 需要验证的文件
        /// </summary>
        public byte[] video_file { get; set; }
    }
}
