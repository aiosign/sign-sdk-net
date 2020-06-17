﻿using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.response.template
{
	/// <summary>
	/// 模板解锁响应参数
	/// </summary>
	public class TemplateUnlockResponse
	{
		/// <summary>
		/// 模板id
		/// </summary>
		public string template_id { set; get; }
		/// <summary>
		/// 返回结果
		/// </summary>
		public Boolean result { set; get; }
	}
}
