using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.request.sign
{
    public class EventCertSignField
    {
        /// <summary>
        /// 签名域信息
        /// </summary>
        public List<EventCertSignParams> sign_params { set; get; }

        public void addSignParams(EventCertSignParams signParams)
        {
            (sign_params = sign_params == null ? new List<EventCertSignParams>() : sign_params).Add(signParams);
        }
        /// <summary>
        /// 文本域信息
        /// </summary>
        public List<EventCertTextParams> text_params { set; get; }

        public void addTextParams(EventCertTextParams textParams) {
            (text_params = text_params == null ? new List<EventCertTextParams>() : text_params).Add(textParams);
        }
    }
}
