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
        /// <summary>
        /// 文本域信息
        /// </summary>
        public List<EventCertTextParams> text_params { set; get; }
    }
}
