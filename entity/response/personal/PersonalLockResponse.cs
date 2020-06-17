using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.request.personal
{
    /// <summary>
    /// 用户锁定
    /// </summary>
    public class PersonalLockResponse
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public string user_id { get; set; }
        /// <summary>
        /// 锁定结果
        /// </summary>
        public Boolean result { get; set; }
    }
}
