using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.response.company
{
	/// <summary>
	/// 企业用户锁定响应
	/// </summary>
	class CompanyLockResponse
	{
		/// <summary>
		/// 响应用户id
		/// </summary>
		public string user_id { get; set; }

		/// <summary>
		/// 返回结果
		/// </summary>
		public Boolean result { get; set; } 
	}
}
