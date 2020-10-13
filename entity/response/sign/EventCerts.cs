using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.response.sign
{
    /// <summary>
    /// 事件证书 相应数据
    /// </summary>
    public class EventCerts
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public string user_id { set; get; }
        /// <summary>
        /// 证书Id
        /// </summary>
        public string cert_id { set; get; }
    }
}
