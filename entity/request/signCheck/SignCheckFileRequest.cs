using sign_sdk_net.entity.request.bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.request.signCheck
{
    /// <summary>
    /// 文件验签请求对象
    /// </summary>
    public class SignCheckFileRequest : BaseSignRequest
    {

        /// <summary>
        /// 文件名称
        /// </summary>
        public string fileDataName { get; set; }
        /// <summary>
        /// 文件数据
        /// </summary>
        public byte[] fileData { get; set; } 
    }
}
