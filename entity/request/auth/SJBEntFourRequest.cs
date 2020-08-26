using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.entity.request.bases;

namespace sign_sdk_net.entity.request.auth
{
    public class SJBEntFourRequest : BaseSignRequest
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string name { set; get; }
        /// <summary>
        /// 企业名称
        /// </summary>
        public string entname { set; get; }
        /// <summary>
        /// 企业标识
        /// </summary>
        public string entmark { set; get; }
        /// <summary>
        /// 个人身份证号码
        /// </summary>
        public string idcard { set; get; }
    }
}
