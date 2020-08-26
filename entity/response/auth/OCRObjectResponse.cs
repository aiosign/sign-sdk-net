using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.response.auth
{
    /// <summary>
    /// OCRObject 响应参数
    /// </summary>
    public class OCRObjectResponse
    {
        /// <summary>
        /// 返回值
        /// </summary>
        public Dictionary<string, string> result { set; get; }
    }
}
