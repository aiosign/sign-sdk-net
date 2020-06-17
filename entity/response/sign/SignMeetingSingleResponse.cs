using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.response.sign
{
	/// <summary>
	/// 会签相应参数
	/// </summary>
	class SignMeetingSingleResponse
	{
		/// <summary>
		/// 合同Id
		/// </summary>
		public string sign_id { set; get; }
		/// <summary>
		/// 文件Id
		/// </summary>
		public string file_id { set; get; }
		/// <summary>
		/// 签署状态
		/// </summary>
		public Boolean sign_state { set; get; }
	}
}
