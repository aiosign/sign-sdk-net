using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.response.seal
{
	/// <summary>
	/// 印章查询响应参数
	/// </summary>
	class SealQueryResponse
	{
		/// <summary>
		/// 文件id
		/// </summary>
		public string file_id { set; get; }
		/// <summary>
		/// 印章名字
		/// </summary>
		public string seal_name { set; get; }
		/// <summary>
		/// 印章类型，具体参考印章类型列表 
		/// </summary>
		public string seal_type { set; get; }
		/// <summary>
		/// 印章规格
		/// </summary>
		public string size { set; get; }
		/// <summary>
		/// 印章状态：1，正常；0，锁定
		/// </summary>
		public string status { set; get; }
		/// <summary>
		/// 用户id
		/// </summary>
		public string user_id { set; get; }

	}
}
