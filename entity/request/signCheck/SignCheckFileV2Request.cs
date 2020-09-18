using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.entity.request.bases;

namespace sign_sdk_net.entity.request.signCheck
{
    public class SignCheckFileV2Request : BaseSignRequest
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
