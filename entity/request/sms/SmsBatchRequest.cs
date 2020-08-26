using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.entity.request.bases;

namespace sign_sdk_net.entity.request.sms
{
    /// <summary>
    /// 批量-短信通知 请求参数
    /// </summary>
    public class SmsBatchRequest : BaseSignRequest
    {
        /// <summary>
        /// 短信类型（参考短信类型列表）
        /// </summary>
        public string sms_type { set; get; }
        /// <summary>
        /// 短信参数
        /// </summary>
        public List<Params> @params { set; get; }
    }
    public class Params
    {
        /// <summary>
        /// 用户名称
        /// </summary>
        public string user_name { set; get; }
        /// <summary>
        /// 合同名称
        /// </summary>
        public string contract_name { set; get; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string phone { set; get; }
    }
}

