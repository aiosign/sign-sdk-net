using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.entity.request.bases;

namespace sign_sdk_net.entity.request.seal
{
	/// <summary>
	/// 印章注销请求参数
	/// </summary>
	public class SealRemoveRequest:BaseSignRequest
	{
		/// <summary>
		/// 印章id
		/// </summary>
		public string seal_id { set; get; }
		public SealRemoveRequest(string seal_id)
		{
			this.seal_id = seal_id;
		}
	}
}
