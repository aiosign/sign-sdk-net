using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.response.sign
{
	/// <summary>
	/// 事件证书-关键字签章接口 响应参数
	/// </summary>
	class EventCertSignKeywordSignResponse
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
		/// <summary>
		/// hash
		/// </summary>
		public string hash { set; get; }
		/// <summary>
		/// 事件证书
		/// </summary>
		public List<EventCerts> event_certs { set; get; }
	}
}
