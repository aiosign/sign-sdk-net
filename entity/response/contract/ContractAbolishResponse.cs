using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.response.contract
{
    /// <summary>
    /// 作废合同响应参数
    /// </summary>
    class ContractAbolishResponse
    {
        /// <summary>
        /// 签署Id
        /// </summary>
        public string sign_id { set; get; }
        /// <summary>
        /// 文件Id
        /// </summary>
        public string file_id { set; get; }
        /// <summary>
        /// 作废结果
        /// </summary>
        public Boolean result { set; get; }
    }
}
