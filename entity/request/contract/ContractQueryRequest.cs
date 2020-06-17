using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.entity.request.bases;

namespace sign_sdk_net.entity.request.contract
{
	/// <summary>
	/// 模板查询请求参数
	/// </summary>
	public class ContractQueryRequest : BaseSignRequest
	{
		/// <summary>
		/// 模板id
		/// </summary>
		public string contract_id { set; get; }


		public ContractQueryRequest(string contract_id)
		{
			this.contract_id = contract_id;
		}
	}
}
