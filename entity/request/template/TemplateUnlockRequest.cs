using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.entity.request.bases;

namespace sign_sdk_net.entity.request.template
{
	/// <summary>
	/// 模板解锁请求参数
	/// </summary>
	public class TemplateUnlockRequest:BaseSignRequest
	{
		/// <summary>
		/// 模板id
		/// </summary>
		public string template_id { set; get; }
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="template_id"></param>
		public TemplateUnlockRequest(string template_id)
		{
			this.template_id = template_id;
		}
	}
}
