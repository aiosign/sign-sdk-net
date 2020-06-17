using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.response.cert
{
	/// <summary>
	/// 证书申请响应参数
	/// </summary>
	class CertApplyResponse : CertCertinfoResponse
	{
		/// <summary>
		/// 预处理id
		/// </summary>
		public string prepare_id { set; get; }
	}
}
