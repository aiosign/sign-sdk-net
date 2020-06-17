using sign_sdk_net.entity.request.bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.response
{
    /// <summary>
    /// 个人用户查询响应
    /// </summary>
    class PersonalUserinfoResponse
    {

        /// <summary>
        /// 用户信息
        /// </summary>
        public PersonalInfo personal_info { get; set; }
        /// <summary>
        /// 用户证书信息
        /// </summary>
        public CertInfo cert_info { get; set; }


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
    /// 个人用户信息
    /// </summary>
    public class PersonalInfo
    {

        /// <summary>
        /// 地区编码
        /// </summary>
        public string area_code { get; set; }
        /// <summary>
        /// 注册人的证件号
        /// </summary>
        public string id_number { get; set; }
        /// <summary>
        /// 证件类型1,身份证;2,护照;3,驾驶证;4, 居住证
        /// </summary>
        public string id_type { get; set; }
        /// <summary>
        ///  用户邮箱 xxxxxx@qq.com
        /// </summary>
        public string mail { get; set; }
        /// <summary>
        ///  用户手机号
        /// </summary>
        public string phone { get; set; }
        /// <summary>
        /// 用户状态:1正常,0注销,2锁定
        /// </summary>
        public string status { get; set; }
        /// <summary>
        ///  用户id
        /// </summary>
        public string user_id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string user_name { get; set; }



    }
}
