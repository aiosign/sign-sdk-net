using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.response.seal
{
	/// <summary>
	/// 印章解锁响应参数
	/// </summary>
	class SealUnlockResponse
	{
		/// <summary>
		/// 印章id
		/// </summary>
		public string seal_id { set; get; }
		/// <summary>
		/// 结果
		/// </summary>
		public Boolean result { set; get; }
	}
}
