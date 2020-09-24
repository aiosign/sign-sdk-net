using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.entity.request.bases;

namespace sign_sdk_net.entity.response.cert
{
	/// <summary>
	/// 证书续期请求参数
	/// </summary>
	class CertRenewalRequest : BaseSignRequest
	{
		/// <summary>
		/// 用户id
		/// </summary>
		public string user_id { set; get; }

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="user_id"></param>
		public CertRenewalRequest(string user_id)
		{
			this.user_id = user_id;
		}
	}
}
