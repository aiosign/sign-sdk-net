using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.response.auth
{
    /// <summary>
    /// 数据宝企业四要素认证 响应值
    /// </summary>
    public class SJBEntFourResponse
    {
        /// <summary>
        /// 姓名验证结果
        /// </summary>
        public string name_result { set; get; }
        /// <summary>
        /// 身份证号码验证结果
        /// </summary>
        public string idcard_result { set; get; }
        /// <summary>
        /// 企业名称验证结果
        /// </summary>
        public string ent_name_result { set; get; }
        /// <summary>
        /// 企业代码验证结果
        /// </summary>
        public string registration_number_result { set; get; }
    }
}
