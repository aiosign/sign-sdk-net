using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.entity.request.bases;

namespace sign_sdk_net.entity.request.contract
{
    /// <summary>
    /// 查询待签署合同请求参数
    /// </summary>
    class ContractQueryBindRequest : BaseSignRequest
    {
        /// <summary>
		/// 手机号码
		/// </summary>
		public string phone { set; get; }
        /// <summary>
        /// 合同名称
        /// </summary>
        public string contract_name { set; get; }
    }
}
