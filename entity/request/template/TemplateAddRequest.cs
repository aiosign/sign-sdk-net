using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.entity.request.bases;

namespace sign_sdk_net.entity.request.template
{
	/// <summary>
	/// 模板添加请求参数
	/// </summary>
	public class TemplateAddRequest:BaseSignRequest
	{
		/// <summary>
		/// 模板名称
		/// </summary>
		public string name { set; get; }
		/// <summary>
		/// 文件id
		/// </summary>
		public string file_id { set; get; }
	}
}
