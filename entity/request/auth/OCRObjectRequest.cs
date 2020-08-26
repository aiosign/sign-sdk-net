using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.entity.request.bases;

namespace sign_sdk_net.entity.request.auth
{
    /// <summary>
    /// OCRObject 请求参数
    /// </summary>
    public class OCRObjectRequest: BaseSignRequest
    {
        /// <summary>
        /// 文件名称
        /// </summary>
        public string file_name { set; get; }
        /// <summary>
        /// 文件base64
        /// </summary>
        public string file_base64 { set; get; }
        /// <summary>
        /// 识别文件类型
        /// </summary>
        public string card_type { set; get; }
    }
}
