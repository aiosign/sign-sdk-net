using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.entity.request.bases;

namespace sign_sdk_net.entity.request.personal
{
    /// <summary>
    /// 扫码合同查询请求参数
    /// </summary>
    class ScanContractQueryRequest : BaseSignRequest
    {
        /// <summary>
        /// 预处理Id
        /// </summary>
        public string prepare_id { get; set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="prepare_id"></param>
        public ScanContractQueryRequest(string prepare_id)
        {
            this.prepare_id = prepare_id;
        }

    }
}
