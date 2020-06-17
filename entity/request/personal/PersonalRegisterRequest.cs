using sign_sdk_net.entity.request.bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.request
{
    /// <summary>
    /// 个人用户注册请求对象
    /// </summary>
    public class PersonalRegisterRequest : BaseSignRequest
    {
        /// <summary>
        /// 用户名称
        /// </summary>
        public string user_name { get; set; }
        /// <summary>
        /// 所属地区编码
        /// </summary>
        public string area_code { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string phone { get; set; }
        /// <summary>
        /// 注册人的证件号
        /// </summary>
        public string id_number { get; set; }
        /// <summary>
        /// 邮箱地址
        /// </summary>
        public string mail { get; set; }
        /// <summary>
        /// 证件类型
        /// </summary>
        public string id_type { get; set; }
        /// <summary>
        /// 描述信息
        /// </summary>
        public string description { get; set; }
    }
}
