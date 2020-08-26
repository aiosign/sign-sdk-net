using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.request.sign
{
    public class EventCertSignParams
    {
        /// <summary>
        /// 印章ID
        /// </summary>
        public string seal_id { set; get; }
        /// <summary>
        /// 签名域
        /// </summary>
        public string sign_key { set; get; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public string user_id { set; get; }
        /// <summary>
        /// 印章宽度
        /// </summary>
        public double width { set; get; }
        /// <summary>
        /// 印章高度
        /// </summary>
        public double height { set; get; }
    }
}
