using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.entity.request.bases;

namespace sign_sdk_net.entity.request.template
{
	/// <summary>
	/// 模板填充请求参数
	/// </summary>
	public class TemplateFillRequest: BaseSignRequest
    {
        /// <summary>
		/// 模板id
		/// </summary>
		public string template_id { set; get; }
		/// <summary>
		/// 合同名字
		/// </summary>
		public string name { set; get; }
		/// <summary>
		/// 用户id
		/// </summary>
		public string user_id { set; get; }
		/// <summary>
		/// 文本域参数
		/// </summary>
		public List<SimpleFormField> simple_form_fields;

		public void addSimpleFormField(SimpleFormField simpleFormField)
		{
			(simple_form_fields = simple_form_fields == null ? new List<SimpleFormField>() : simple_form_fields).Add(simpleFormField);
		}

		public class SimpleFormField
		{
			/// <summary>
			/// 合同名字
			/// </summary>
			public string key { set; get; }
			/// <summary>
			/// 合同名字
			/// </summary>
			public string value { set; get; }

		}
	}
}
