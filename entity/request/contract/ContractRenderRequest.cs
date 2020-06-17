using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.entity.request.bases;

namespace sign_sdk_net.entity.request.contract
{
	/// <summary>
	/// 异步渲染合同请求参数
	/// </summary>
	public class ContractRenderRequest:BaseSignRequest
	{
		/// <summary>
		/// 合同id
		/// </summary>
		public string contract_id { set; get; }

		public ContractRenderRequest(string contract_id)
		{
			this.contract_id = contract_id;
		}
	}
}
