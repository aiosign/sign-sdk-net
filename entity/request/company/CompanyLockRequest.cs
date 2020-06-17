using sign_sdk_net.entity.request.bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.request.company
{

	/// <summary>
	/// 企业用户锁定
	/// </summary>
	public class CompanyLockRequest : BaseSignRequest
	{
		/// <summary>
		/// 用户id
		/// </summary>
		public string user_id { get; set; }

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="user_id"></param>
		public CompanyLockRequest(string user_id)
		{
			this.user_id = user_id;
		}

	}
}