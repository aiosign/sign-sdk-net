using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.entity.request.bases;

namespace sign_sdk_net.entity.request.company
{
	/// <summary>
	/// 企业用户解锁请求数据
	/// </summary>
	class CompanyUnlockRequest : BaseSignRequest
	{
		/// <summary>
		/// 用户id
		/// </summary>
		public string user_id { set; get; }

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="user_id"></param>
		public CompanyUnlockRequest(string user_id )
		{
			this.user_id = user_id;
		}
	}
}
