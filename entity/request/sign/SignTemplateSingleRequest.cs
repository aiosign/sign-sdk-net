using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.entity.request.bases;

namespace sign_sdk_net.entity.request.sign
{
	/// <summary>
	/// 单模板签章请求参数
	/// </summary>
	public class SignTemplateSingleRequest : BaseSignRequest
	{
		/// <summary>
		/// 模板id
		/// </summary>
		public string template_id { set; get; }
		/// <summary>
		/// 签章参数
		/// </summary>
		public SignField sign_field { set; get; }
		

	}
	/// <summary>
	/// 文本域
	/// </summary>
	public class TextParams
	{
		/// <summary>
		/// 填充参数key
		/// </summary>
		public string key { set; get; }
		/// <summary>
		/// 填充值
		/// </summary>
		public string value { set; get; }
	}
	public class SignField {

		/// <summary>
		/// 签名域信息
		/// </summary>
		public List<SignParams> sign_params { set; get; }
		/// <summary>
		/// 文本域信息
		/// </summary>
		public List<TextParams> text_params { set; get; }
	}
	/// <summary>
	/// 签名域信息
	/// </summary>
	public class SignParams
	{
		/// <summary>
		/// 印章ID
		/// </summary>
		public string seal_id { set; get; }
		/// <summary>
		/// 签名域
		/// </summary>
		public string sign_key { set; get; }
		/// <summary>
		/// 用户ID
		/// </summary>
		public string user_id { set; get; }
		/// <summary>
		/// 印章宽度
		/// </summary>
		public double width { set; get; }
		/// <summary>
		/// 印章高度
		/// </summary>
		public double height { set; get; }
	}
}
