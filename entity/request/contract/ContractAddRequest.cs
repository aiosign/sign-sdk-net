using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.entity.request.bases;

namespace sign_sdk_net.entity.request.contract
{
	/// <summary>
	/// 合同添加请求参数
	/// </summary>
	public class ContractAddRequest:BaseSignRequest
	{
		/// <summary>
		/// 合同名称
		/// </summary>
		public string name { set; get; }
		/// <summary>
		/// 用户ID
		/// </summary>
		public string user_id { set; get; }
		/// <summary>
		/// 文件id
		/// </summary>
		public string file_id { set; get; }
		/// <summary>
		/// 描述信息 
		/// </summary>
		public string description { set; get; }


	}
}
