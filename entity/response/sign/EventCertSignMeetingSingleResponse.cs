using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.response.sign
{
    /// <summary>
    /// 事件证书-会签相应参数
    /// </summary>
    class EventCertSignMeetingSingleResponse
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
