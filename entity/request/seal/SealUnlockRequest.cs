using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.entity.request.bases;

namespace sign_sdk_net.entity.request.seal
{
	/// <summary>
	/// 印章解锁请求参数
	/// </summary>
	public class SealUnlockRequest : BaseSignRequest
	{
		/// <summary>
		/// 印章id
		/// </summary>
		public string seal_id { set; get; }

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="seal_id"></param>
		public SealUnlockRequest(string seal_id)
		{
			this.seal_id = seal_id;
		}
	}
}
