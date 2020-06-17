using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.response.sign
{
	/// <summary>
	/// 批量模板签章相应参数
	/// </summary>
	class SignTemplateBatchResponse 
	{
		/// <summary>
		/// 批量处理ID
		/// </summary>
		public string batch_id { set; get; }
		public List<SignInfos> sign_infos { set; get; }
	}
	public class SignInfos
	{
		/// <summary>
		/// 签章ID
		/// </summary>
		public string sign_id { set; get; }
		/// <summary>
		/// 签章状态
		/// </summary>
		public Boolean sign_state { set; get; }
		/// <summary>
		/// 文件下载ID
		/// </summary>
		public string file_id { set; get; }
		/// <summary>
		/// 返回自定义ID
		/// </summary>
		public string custom_id { set; get; }

	}
}
