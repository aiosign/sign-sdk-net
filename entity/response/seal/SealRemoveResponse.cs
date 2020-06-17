using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.response.seal
{
	/// <summary>
	/// 印章注銷响应参数
	/// </summary>
	public class SealRemoveResponse
	{
		/// <summary>
		/// 印章id
		/// </summary>
		public string seal_id { set; get; }
		/// <summary>
		/// 返回结果
		/// </summary>
		public Boolean result { set; get; }
	}
}
