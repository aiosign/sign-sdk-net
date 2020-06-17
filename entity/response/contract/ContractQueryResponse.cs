using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.response.contract
{
	/// <summary>
	/// 合同查询响应参数
	/// </summary>
	public class ContractQueryResponse
	{
		/// <summary>
		/// 合同id
		/// </summary>
		public string contract_id { set; get; }
		/// <summary>
		/// 合同创建时间
		/// </summary>
		public string create_time { set; get; }
		/// <summary>
		/// 文件id
		/// </summary>
		public string file_id { set; get; }
		/// <summary>
		/// 合同名字
		/// </summary>
		public string name { set; get; }
		/// <summary>
		/// 合同页数
		/// </summary>
		public string page_count { set; get; }
		/// <summary>
		/// 是否渲染完成:0渲染失败1渲染成功2渲染中
		/// </summary>
		public string render_complete { set; get; }
		/// <summary>
		/// 合同大小
		/// </summary>
		public string size { set; get; }
		/// <summary>
		/// 合同状态：1，正常；0，废除
		/// </summary>
		public string status { set; get; }
		/// <summary>
		/// 合同详细数据
		/// </summary>
		public List<ContractInfos> contract_infos { set; get; }

	}
	/// <summary>
	/// 合同信息
	/// </summary>
	public class ContractInfos
	{
		/// <summary>
		/// 图片文件id
		/// </summary>
		public string image_file_id { set; get; }
		/// <summary>
		/// 第几页
		/// </summary>
		public string number { set; get; }
	}
}
