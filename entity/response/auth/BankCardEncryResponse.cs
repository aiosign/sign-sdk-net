using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.response.auth
{
    /// <summary>
    /// 加密进行银行卡四要素认证 响应值
    /// </summary>
    public class BankCardEncryResponse
    {
        /// <summary>
        /// 匹配结果
        /// </summary>
        public string res { set; get; }
        /// <summary>
        /// 响应信息
        /// </summary>
        public string message { set; get; }
    }
}
