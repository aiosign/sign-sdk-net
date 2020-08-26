using System.Text;
using sign_sdk_net.entity.request.bases;

namespace sign_sdk_net.entity.request.sign
{
    /// <summary>
    /// 单模板签章请求参数
    /// </summary>
    public class EventCertSignTemplateSingleRequest : BaseSignRequest
	{   /// <summary>
		/// 模板id
		/// </summary>
		public string template_id { set; get; }
		/// <summary>
		/// 签章参数
		/// </summary>
		public EventCertSignField sign_field { set; get; }
	}


}
