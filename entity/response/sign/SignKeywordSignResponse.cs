using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.response.sign
{
	/// <summary>
	/// 关键字签章接口 响应参数
	/// </summary>
	class SignKeywordSignResponse
	{
		public Boolean sign_state { set; get; }
		public string sign_id { set; get; }
		public string file_id { set; get; }
	}
}
