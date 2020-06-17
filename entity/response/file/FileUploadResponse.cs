using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.response
{
    /// <summary>
    /// 文件上传响应对象
    /// </summary>
    public class FileUploadResponse
    {
        /// <summary>
        /// 文件的唯一标识
        /// </summary>
        public string file_id { get; set; }

        /// <summary>
        /// 文件类型1印模2合同3证书
        /// </summary>
        public string file_type { get; set; }
        /// <summary>
        /// 文件名字
        /// </summary>
        public string file_name { get; set; }
    }
}
