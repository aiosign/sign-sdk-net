using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.response.template
{
	/// <summary>
	/// 模板查询响应参数
	/// </summary>
	public class TemplateQueryResponse
	{
		/// <summary>
		/// 模版id
		/// </summary>
		public string template_id { set; get; }
		/// <summary>
		/// 模版名称
		/// </summary>
		public string name { set; get; }
		/// <summary>
		/// 创建日期
		/// </summary>
		public string create_time { set; get; }
		/// <summary>
		/// 文件ID
		/// </summary>
		public string file_id { set; get; }
		/// <summary>
		/// 签名域
		/// </summary>
		public string sign_params { set; get; }
		/// <summary>
		/// 文字域
		/// </summary>
		public string text_params { set; get; }
		/// <summary>
		/// 状态
		/// </summary>
		public int status { set; get; }
	}
}
