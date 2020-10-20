using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.response.seal
{
    /// <summary>
	/// 查询用户所以印章返回参数
	/// </summary>
    class GetSealInfosByUserOrTypeResponse
    {
        /// <summary>
		/// 印章id
		/// </summary>
		public string seal_id { set; get; }
		/// <summary>
		/// 印章名称
		/// </summary>
		public string seal_name { set; get; }
		/// <summary>
		/// 印章类型
		/// </summary>
		public string seal_type { set; get; }
		/// <summary>
		/// 印章规格
		/// </summary>
		public string size { set; get; }
		/// <summary>
		/// 用户ID
		/// </summary>
		public string user_id { set; get; }
		/// <summary>
		/// 用户类型
		/// </summary>
		public string user_type { set; get; }
		/// <summary>
		/// 用户名称
		/// </summary>
		public string user_name { set; get; }
	}
}
