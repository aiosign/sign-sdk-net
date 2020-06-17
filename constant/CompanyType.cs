using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.constant
{
    /// <summary>
    /// 企业类型
    /// </summary>
    public class CompanyType
    {
        /// <summary>
        /// 党政机关、人大、政协
        /// </summary>
        public const string institution = "01";
        /// <summary>
        /// 企业单位
        /// </summary>
        public const string Company = "02";
        /// <summary>
        /// 事业单位
        /// </summary>
        public const string public_institution = "03";
        /// <summary>
        /// 社会团体
        /// </summary>
        public const string social_organization = "04";
        /// <summary>
        /// 民营非企业单位
        /// </summary>
        public const string private_non_enterprise_units = "05";
        /// <summary>
        /// 其他
        /// </summary>
        public const string other = "99";
    }
}
