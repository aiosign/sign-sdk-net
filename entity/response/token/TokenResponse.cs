using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.response
{
    /// <summary>
    /// 获取token response
    /// </summary>
    class TokenResponse
    {
        /// <summary>
        /// token 
        /// </summary>
        public string access_token { get; set; }
        /// <summary>
        /// 授权类型
        /// </summary>
        public string scopy { get; set; }
        /// <summary>
        /// Token类型
        /// </summary>
        public string token_type { get; set; }
        /// <summary>
        /// 过期时间
        /// </summary>
        public string expires_in { get; set; }
        
    }
}
