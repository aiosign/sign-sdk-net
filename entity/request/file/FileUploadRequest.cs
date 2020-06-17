using sign_sdk_net.entity.request.bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.request
{
    /// <summary>
    /// 文件上传对象
    /// </summary>
    public class FileUploadRequest : BaseSignRequest
    {
        /// <summary>
        /// 文件名称
        /// </summary>
        public string fileDataName { get; set; }
        /// <summary>
        /// 文件数据
        /// </summary>
        public byte[] fileData { get; set; }
        /// <summary>
        /// 文件类型
        /// </summary>
        public string fileType { get; set; }
        /// <summary>
        /// 文件名称
        /// </summary>
        public string fileName { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public string userId { get; set; }
    }
}
