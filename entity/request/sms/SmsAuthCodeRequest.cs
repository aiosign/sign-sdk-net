using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.entity.request.bases;

namespace sign_sdk_net.entity.request.sms
{
    /// <summary>
    /// 短信验证码下发 请求参数
    /// </summary>
    class SmsAuthCodeRequest : BaseSignRequest
    {
        /// <summary>
        /// 模板id
        /// </summary>
        public List<PhoneParam> phones { set; get; }

        /// <summary>
        /// 添加短信参数
        /// </summary>
        /// <param name="phoneParam"></param>
        public void addPhones(PhoneParam phoneParam) {
            (phones = phones == null ? new List<PhoneParam>() : phones).Add(phoneParam);
        }

    }

    public class PhoneParam {
        /// <summary>
        /// 自定义id
        /// </summary>
        public string custom_id { set; get; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string phone { set; get; }
    }
}
