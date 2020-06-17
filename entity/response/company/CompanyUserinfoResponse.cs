using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.response.company
{
    /// <summary>
    /// 企业用户信息查询 响应
    /// </summary>
    public class CompanyUserinfoResponse
    {
        /// <summary>
        /// 证书信息
        /// </summary>
        public CertInfo cert_info { get; set; }
        /// <summary>
        /// 企业客户信息
        /// </summary>
        public CompanyUserInfo company_user_info { get; set; }
    }
    /// <summary>
    /// 证书信息
    /// </summary>
    public class CertInfo
    {
        /// <summary>
        /// 证书使用者名称
        /// </summary>
        public string award_to { get; set; }
        /// <summary>
        /// 证书id
        /// </summary>
        public string cert_id { get; set; }
        /// <summary>
        /// 证书名字

        /// </summary>
        public string cert_name { get; set; }
        /// <summary>
        /// 证书失效时间
        /// </summary>
        public string end_date { get; set; }
        /// <summary>
        /// 注册证件号
        /// </summary>
        public string id_number { get; set; }
        /// <summary>
        /// 颁发者
        /// </summary>
        public string issuer { get; set; }
        /// <summary>
        /// 证书序列
        /// </summary>
        public string sn { get; set; }
        /// <summary>
        /// 证书生效时间
        /// </summary>
        public string start_date { get; set; }
        /// <summary>
        /// 证书状态,可用值:0注销;1正常
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 版本号
        /// </summary>
        public int? version { get; set; }
    }
    /// <summary>
    /// 企业客户信息
    /// </summary>
    public class CompanyUserInfo
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
        /// <summary>
        /// 企业用户名
        /// </summary> 
        public string user_id { get; set; }
    }
}
