using sign_sdk_net.entity.request.bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.request.company
{
    /// <summary>
    /// 企业用户信息查询 请求类
    /// </summary>
    public class CompanyUserinfoRequest : BaseSignRequest
    {
        /// <summary>
        /// 企业用户id
        /// </summary>
        public string user_id { get; set; }

        public CompanyUserinfoRequest(string user_id)
        {
            this.user_id = user_id;
        }

    }
}
