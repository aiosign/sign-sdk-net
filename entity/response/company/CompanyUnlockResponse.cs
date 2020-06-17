using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace sign_sdk_net.entity.response.company
{	
	/// <summary>
	/// 企业用户解锁响应
	/// </summary>
	class CompanyUnlockResponse
	{
		/// <summary>
		/// 用户id
		/// </summary>
		public string user_id { get; set; }
		/// <summary>
		/// 返回结果
		/// </summary>
		public Boolean result { get; set; }
	}
}
