using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.entity.request.bases;

namespace sign_sdk_net.entity.request.auth
{
    /// <summary>
    /// 银行卡/身份证/姓名/手机号 四要素校验 请求参数
    /// </summary>
    public class BlankCardCheckRequest : BaseSignRequest
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string realname { set; get; }
        /// <summary>
        /// 身份证号码
        /// </summary>
        public string idcard { set; get; }
        /// <summary>
        /// 银行卡密码
        /// </summary>
        public string bankcard { set; get; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string mobile { set; get; }
    }
}
