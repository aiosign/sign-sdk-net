using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using sign_sdk_net.entity.request.bases;

namespace sign_sdk_net.entity.request.contract
{
    /// <summary>
    ///合同绑定手机号请求参数
    /// </summary>
    class ContractBindPhoneRequest : BaseSignRequest
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public string contract_id { get; set; }
        /// <summary>
        /// 绑定手机信息
        /// </summary>
        [JsonProperty(PropertyName = "params")]
        public List<BindInfo> req_params { set; get; }
       
        public void addParams(BindInfo param)
        {
            (req_params = req_params == null ? new List<BindInfo>() : req_params).Add(param);
        }
        /// <summary>
        /// 绑定手机信息
        /// </summary>
        public class BindInfo
    {
            /// <summary>
            /// 手机号
            /// </summary>
            public string phone { set; get; }
        }
    }
}
