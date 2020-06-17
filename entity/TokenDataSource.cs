using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity
{
    /// <summary>
    /// token 存储池 需自行实现token 存储规则
    /// </summary>    
    public interface TokenDataSource
    {
        /// <summary>
        /// 存储token
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Token setToken(string appId, Token token);
        /// <summary>
        /// 提取token
        /// </summary>
        /// <param name="appId">应用id</param>
        /// <returns></returns>
        public Token getToken(string appId);
        /// <summary>
        /// 删除 token
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public Token deleteToken(string appId);

    }
    /// <summary>
    /// token存储对象
    /// </summary>
    public class Token
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
        /// expires_in 2020-07-08 08:37:46
        /// </summary>
        public string expires_in { get; set; }
    }
}
