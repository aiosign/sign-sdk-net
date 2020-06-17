using sign_sdk_net.entity.request.bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.request.personal
{
    /// <summary>
    /// 用户锁定
    /// </summary>
    public class PersonalUnlockRequest : BaseSignRequest
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public string user_id { get; set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="user_id"></param>
        public PersonalUnlockRequest(string user_id) {
            this.user_id = user_id;
        }

    }
}
