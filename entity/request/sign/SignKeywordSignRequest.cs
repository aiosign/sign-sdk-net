using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.entity.request.bases;

namespace sign_sdk_net.entity.request.sign
{
	/// <summary>
	/// 关键字签章接口
	/// </summary>
	class SignKeywordSignRequest:BaseSignRequest
	{
		/// <summary>
		/// 合同文件ID
		/// </summary>
		public string contract_id { set; get; }
		/// <summary>
		/// 用户ID
		/// </summary>
		public string user_id { set; get; }
		/// <summary>
		/// 关键字
		/// </summary>
		public string keyword { set; get; }
		/// <summary>
		/// 印章高度
		/// </summary>
		public double height { set; get; }
		/// <summary>
		/// true：合同内所有匹配位置全部签署；false：只签署第一个匹配；默认false
		/// </summary>
		public Boolean sign_all { set; get; }
		/// <summary>
		/// 印章ID
		/// </summary>
		public string seal_id { set; get; }
		/// <summary>
		/// 印章宽度
		/// </summary>
		public double width { set; get; }
	}
}
