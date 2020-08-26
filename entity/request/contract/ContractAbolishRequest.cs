using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.entity.request.bases;

namespace sign_sdk_net.entity.request.contract
{

	/// <summary>
	/// 作废合同请求参数
	/// </summary>
	public class ContractAbolishRequest : BaseSignRequest
	{
		/// <summary>
		/// 签署id
		/// </summary>
		public string sign_id { set; get; }

		/// <summary>
		/// 用户id
		/// </summary>
		public string user_id { set; get; }


		public ContractAbolishRequest(string sign_id,string user_id)
		{
			this.sign_id = sign_id;
			this.user_id = user_id;
		}
    }
}
