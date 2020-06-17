using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.request.contract
{
    class ContractFileAddRequest
    {
        /// <summary>
        /// 合同添加请求参数
        /// </summary>
        public ContractAddRequest contractAddRequest { set; get; }
        /// <summary>
        /// 合同文件
        /// </summary>
        public FileUploadRequest fileUploadRequest { set; get; }
    }
}
