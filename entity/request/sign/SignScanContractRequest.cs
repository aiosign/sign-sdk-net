using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.entity.request.bases;

namespace sign_sdk_net.entity.request.sign
{
    /// <summary>
    /// 扫码签章接口 请求参数
    /// </summary>
    class SignScanContractRequest : BaseSignRequest
    {
        /// <summary>
        /// 预处理Id
        /// </summary>
        public string prepare_id { set; get; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="prepare_id"></param>
        public SignScanContractRequest(string prepare_id)
        {
            this.prepare_id = prepare_id;
        }
    }
}
