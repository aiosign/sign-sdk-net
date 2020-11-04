using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.entity.request.bases;

namespace sign_sdk_net.entity.request.contract
{

	/// <summary>
	/// 作废合同请求参数
	/// </summary>
	public class ContractAbolishRequest : BaseSignRequest
	{
		/// <summary>
		/// 签署id
		/// </summary>
		public string sign_id { set; get; }

		/// <summary>
		/// 用户id
		/// </summary>
		public string user_id { set; get; }


		public SignParams field{ set; get; }

		public class SignParams{
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
			/// 垂直纵坐标
			/// </summary>
			public double vertical { set; get; }
			/// <summary>
			/// 印章宽度
			/// </summary>
			public double width { set; get; }
		}


		public ContractAbolishRequest(string sign_id,string user_id,SignParams field)
		{
			this.sign_id = sign_id;
			this.user_id = user_id;
			this.field = field;
		}
    }
}