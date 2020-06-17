using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.entity.request.bases;

namespace sign_sdk_net.entity.request.contract
{
	/// <summary>
	/// 删除合同请求参数
	/// </summary>
	public class ContractRemoveRequest:BaseSignRequest
	{
		/// <summary>
		/// 合同id
		/// </summary>
		public string contract_id { set; get; }
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="contract_id"></param>
		public ContractRemoveRequest(string contract_id)
		{
			this.contract_id = contract_id;
		}
	}
}
