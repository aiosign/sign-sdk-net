using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.request.seal
{
    /// <summary>
    /// 新增印章文件以及印章信息 请求参数
    /// </summary>
    class SealFileAddRequest
    {
        /// <summary>
        /// 新增印章信息 请求参数
        /// </summary>
        public SealAddRequest sealAddRequest { set; get; }

        /// <summary>
        /// 印章文件
        /// </summary>
        public FileUploadRequest fileUploadRequest { set; get; }
    }
}
