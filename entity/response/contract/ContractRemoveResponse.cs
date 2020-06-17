using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.response.contract
{
	/// <summary>
	/// 删除合同响应参数
	/// </summary>
	public class ContractRemoveResponse
	{
		/// <summary>
		/// 合同id
		/// </summary>
		public string contract_id { set; get; }
		/// <summary>
		/// 响应数据
		/// </summary>
		public string result { set; get; }
	}
}
