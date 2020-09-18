using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.entity.request.bases;

namespace sign_sdk_net.entity.request.file
{
    /// <summary>
    /// 文件下载 请求参数
    /// </summary>
    public class FileDownloadRequest : BaseSignRequest
    {
        /// <summary>
        /// 文件ID
        /// </summary>
        public string file_id { get; set; }
        /// <summary>
        /// 下载后另存为（全路径）
        /// </summary>
        public string file_name { get; set; }
    }
}
