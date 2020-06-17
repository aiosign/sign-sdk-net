using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.entity.request.bases;

namespace sign_sdk_net.entity.request.seal
{
	/// <summary>
	/// 印章查询请求参数
	/// </summary>
	class SealQueryRequest:BaseSignRequest
	{
		/// <summary>
		/// 印章ID
		/// </summary>
		public string seal_id { set; get; }

		public SealQueryRequest(String seal_id)
		{
			this.seal_id = seal_id;
		}

	}
}
