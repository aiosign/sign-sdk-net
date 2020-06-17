using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.entity.request.bases;

namespace sign_sdk_net.entity.request.seal
{
	/// <summary>
	/// 印章锁定请求参数接口
	/// </summary>
	public class SealLockRequest : BaseSignRequest
	{
		/// <summary>
		/// 印章id
		/// </summary>
		public string seal_id { set; get; }

		public SealLockRequest(string seal_id)
		{
			this.seal_id = seal_id;
		}




	}
}
