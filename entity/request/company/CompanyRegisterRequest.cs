using sign_sdk_net.entity.request.bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.request.company
{
    /// <summary>
    /// 企业客户申请注册请求对象
    /// </summary>
    public class CompanyRegisterRequest : BaseSignRequest
    {
        /// <summary>
        /// 企业名称
        /// </summary>
        public string user_name { get; set; }
        /// <summary>
        /// 所属地区编码
        /// </summary>
        public string area_code { get; set; }
        /// <summary>
        /// 单位类型(参考单位类型列表)
        /// </summary>
        public string unit_type { get; set; }
        /// <summary>
        /// 统一社会信用代码
        /// </summary>
        public string credi_code { get; set; }
        /// <summary>
        /// 法人名称
        /// </summary>
        public string legal_name { get; set; }
        /// <summary>
        /// 法人证件号
        /// </summary>
        public string legal_id_number { get; set; }
        /// <summary>
        /// 法人证件类型(参考证件列表)
        /// </summary>
        public string legal_id_type { get; set; }
        /// <summary>
        /// 法人手机号
        /// </summary>
        public string legal_phone { get; set; }
        /// <summary>
        /// 法人邮箱
        /// </summary>
        public string legal_email { get; set; }
        /// <summary>
        /// 经办人姓名
        /// </summary>
        public string agent_name { get; set; }
        /// <summary>
        /// 经办人证件号
        /// </summary>
        public string agent_id_number { get; set; }
        /// <summary>
        /// 经办人证件类型（参考证件列表）
        /// </summary>
        public string agent_id_type { get; set; }
        /// <summary>
        /// 经办人手机号
        /// </summary>
        public string agent_phone { get; set; }
        /// <summary>
        /// 经办人邮箱
        /// </summary>
        public string agent_email { get; set; }
        /// <summary>
        /// 描述信息
        /// </summary>
        public string description { get; set; }

    }
}
