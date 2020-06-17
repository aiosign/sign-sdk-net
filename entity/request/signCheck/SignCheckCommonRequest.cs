using sign_sdk_net.entity.request.bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.request
{
    /// <summary>
    /// 文件验章
    /// </summary>
    class SignCheckCommonRequest :BaseSignRequest 
    {
        /// <summary>
        /// 文件id
        /// </summary>
        public string file_id { get; set; }
        /// <summary>
        /// 初始化对象
        /// </summary>
        public SignCheckCommonRequest(string file_id) {
            this.file_id = file_id;
        }
    }
}
