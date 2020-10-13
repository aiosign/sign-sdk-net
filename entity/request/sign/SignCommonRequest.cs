using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.entity.request.bases;

namespace sign_sdk_net.entity.request.sign
{
	/// <summary>
	/// 合同坐标签章接口 请求参数
	/// </summary>
	class SignCommonRequest : BaseSignRequest
	{
		/// <summary>
		/// 合同文件ID
		/// </summary>
		public string contract_id { set; get; }
		/// <summary>
		/// 用户ID
		/// </summary>
		public string user_id { set; get; }
		/// <summary>
		/// /本次签章备注
		/// </summary>
		public string remark { set; get; }
		/// <summary>
		/// 
		/// </summary>
		public List<Fields> fields { set; get; }

		public void addFields(Fields field)
		{
			(fields = fields == null ? new List<Fields>() : fields).Add(field);
		}
	}
	public class Fields
	{
		/// <summary>
		/// 印章高度
		/// </summary>
		public double height { set; get; }
		/// <summary>
		/// 水平横坐标
		/// </summary>
		public double horizontal { set; get; }
		/// <summary>
		/// 签章页数
		/// </summary>
		public int page_number { set; get; }
		/// <summary>
		/// 印章ID
		/// </summary>
		public string seal_id { set; get; }
		/// <summary>
		/// 垂直纵坐标
		/// </summary>
		public double vertical { set; get; }
		/// <summary>
		/// 印章宽度
		/// </summary>
		public double width { set; get; }
	}
}
