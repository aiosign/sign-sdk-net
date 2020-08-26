using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.entity.request.bases;

namespace sign_sdk_net.entity.request.auth
{
    /// <summary>
    /// OCR银行卡 请求参数
    /// </summary>
    public class OCRBankCardRequest: BaseSignRequest
    {
        /// <summary>
        ///银行卡图片Base64
        /// </summary>
        public string image { set; get; }
    }
}
