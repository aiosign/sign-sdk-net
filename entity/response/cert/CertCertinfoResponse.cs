using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.response.cert
{
	/// <summary>
	/// 证书查询响应参数
	/// </summary>
	class CertCertinfoResponse
	{
		/// <summary>
		/// 用户ID
		/// </summary>
		public string user_id { set; get; }

		/// <summary>
		/// 证书信息
		/// </summary>
		public CertInfo cert_info { set; get; }

	}
	/// <summary>
	/// 证书信息
	/// </summary>
	public class CertInfo
	{

		/// <summary>
		/// 证书id
		/// </summary>
		public string cert_id { set; get; }
		/// <summary>
		/// 证书序列号
		/// </summary>
		public string sn { set; get; }
		/// <summary>
		/// 证书名字
		/// </summary>
		public string cert_name { set; get; }
		/// <summary>
		/// 注册证件号
		/// </summary>
		public string id_number { set; get; }
		/// <summary>
		/// 颁发者
		/// </summary>
		public string issuer { set; get; }
		/// <summary>
		/// 版本号
		/// </summary>
		public string version { set; get; }
		/// <summary>
		/// 证书生效时间
		/// </summary>
		public string start_date { set; get; }
		/// <summary>
		/// 证书失效时间
		/// </summary>
		public string end_date { set; get; }
		/// <summary>
		/// 证书使用者名称
		/// </summary>
		public string award_to { set; get; }
		/// <summary>
		/// 证书状态
		/// </summary>
		public int status { set; get; }
	}

}
