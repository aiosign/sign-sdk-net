using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.entity.request.bases;

namespace sign_sdk_net.entity.request.cert
{
	/// <summary>
	/// 证书查看的请求参数
	/// </summary>
	class CertCertinfoRequest: BaseSignRequest
	{
		/// <summary>
		/// 预处理id
		/// </summary>
		public string prepare_id { set; get; }

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="prepare_id"></param>
		public CertCertinfoRequest(string prepare_id)
		{
			this.prepare_id = prepare_id;
		}

	}
}
