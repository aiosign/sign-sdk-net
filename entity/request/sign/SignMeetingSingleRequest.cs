using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.entity.request.bases;

namespace sign_sdk_net.entity.request.sign
{
	/// <summary>
	/// 会签请求参数
	/// </summary>
	class SignMeetingSingleRequest:BaseSignRequest
	{
		/// <summary>
		/// 合同文件ID
		/// </summary>
		public string contract_id { set; get; }
		/// <summary>
		/// 
		/// </summary>
		public List<SignDetails> sign_details { set; get; }
	}
	public class SignDetails
	{
		/// <summary>
		/// 签章页码
		/// </summary>
		public int page_num { set; get; }
		/// <summary>
		/// 印章id
		/// </summary>
		public string seal_id { set; get; }
		/// <summary>
		/// 签署距离
		/// </summary>
		public int sign_left { set; get; }
		/// <summary>
		/// 印章宽度
		/// </summary>
		public double sign_width { set; get; }
		/// <summary>
		/// 印章高度
		/// </summary>
		public double sign_height { set; get; }
		/// <summary>
		/// 签署距离
		/// </summary>
		public int sign_top { set; get; }
		/// <summary>
		/// 用户id
		/// </summary>
		public string user_id { set; get; }
	}
}
