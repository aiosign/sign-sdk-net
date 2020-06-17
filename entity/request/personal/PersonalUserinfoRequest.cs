using sign_sdk_net.entity.request.bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.request
{
    /// <summary>
    /// 个人用户查询请求对象
    /// </summary>
    class PersonalUserinfoRequest : BaseSignRequest
    {
        /// <summary>
        /// 个人用户id
        /// </summary>
        public string user_id { get; set; }

        public PersonalUserinfoRequest(string user_id) {
            this.user_id = user_id;
        }
    }
}
