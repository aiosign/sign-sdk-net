using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.entity.request.bases;

namespace sign_sdk_net.entity.request.seal
{
	/// <summary>
	/// 印章添加请求参数
	/// </summary>
	class SealAddRequest : BaseSignRequest
	{
		/// <summary>
		/// 用户ID
		/// </summary>
		public string user_id { set; get; }
		/// <summary>
		/// 印章名称
		/// </summary>
		public string seal_name { set; get; }
		/// <summary>
		/// 印章类型(参考印章类型列表)
		/// </summary>
		public string seal_type { set; get; }
		/// <summary>
		/// 印章文件id
		/// </summary>
		public string file_id { get; set; }
		/// <summary>
		/// 印章规格 40*40
		/// </summary>
		public string size { get; set; }
		/// <summary>
		/// 描述信息
		/// </summary>
		public string description { get; set; }


	}
}
