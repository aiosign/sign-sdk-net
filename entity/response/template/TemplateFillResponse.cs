using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.response.template
{
	/// <summary>
	/// 模板填充返回参数
	/// </summary>
	public class TemplateFillResponse
    {
        /// <summary>
		/// 文件ID
		/// </summary>
		public string file_id { set; get; }
		/// <summary>
		/// 文件名称
		/// </summary>
		public string file_name { set; get; }
		/// <summary>
		/// 合同ID
		/// </summary>
		public string contract_id { set; get; }
	}
}
