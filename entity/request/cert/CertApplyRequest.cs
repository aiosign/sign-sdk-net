using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.entity.request.bases;

namespace sign_sdk_net.entity.request.cert
{
	/// <summary>
	/// 证书申请请求参数
	/// </summary>
	class CertApplyRequest: BaseSignRequest
	{
		/// <summary>
		/// 用户id
		/// </summary>
		public string user_id { set; get; }

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="user_id"></param>
		public CertApplyRequest(string user_id)
		{
			this.user_id = user_id;
		}
	}
}
