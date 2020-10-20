using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.response.seal
{
	/// <summary>
	/// 根据用户查询所有印章相应参数
	/// </summary>
	class GetSealInfosResponse
	{
		/// <summary>
		/// 文件id
		/// </summary>
		public string file_id {get;set;}
		/// <summary>
		/// 印章名字
		/// </summary>
		public string seal_name	{get;set;}
		/// <summary>
		/// 印章类型，具体参考印章类型列表 
		/// </summary>
		public string seal_type	{get;set;}
		/// <summary>
		/// 印章规格
		/// </summary>
		public string size {get;set;}
		/// <summary>
		/// 印章状态：1，正常；0，锁定
		/// </summary>
		public int status {get;set;}
		/// <summary>
		/// 印章i
		/// </summary>
		public string seal_id {get;set;}

	}
}
