using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.response.sign
{
	/// <summary>
	/// 合同坐标签章接口 相应数据
	/// </summary>
	class SignCommonResponse
	{
		/// <summary>
		/// 签署结果
		/// </summary>
		public Boolean sign_state { set; get; }
		/// <summary>
		/// 本次签署ID
		/// </summary>
		public string sign_id { set; get; }
		/// <summary>
		/// 文件下载ID
		/// </summary>
		public string file_id { set; get; }

	}
}
