using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.response.seal
{
	/// <summary>
	/// 印章锁定响应参数
	/// </summary>
	class SealLockResponse
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
