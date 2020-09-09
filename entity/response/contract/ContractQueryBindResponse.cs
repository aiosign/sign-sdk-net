using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.response.contract
{
    /// <summary>
    /// 合同绑定手机号 返回参数
    /// </summary>
    public class ContractQueryBindResponse
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 合同id
        /// </summary>
        public string contract_id { get; set; }
        /// <summary>
        /// 合同id
        /// </summary>
        public string contract_name { get; set; }
        /// <summary>
        /// 合同创建时间
        /// </summary>
        public string contract_create_time { get; set; }
        /// <summary>
        /// 合同状态
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 绑定信息
        /// </summary>
        public string unique_identifier { get; set; }
        /// <summary>
        /// 应用ID
        /// </summary>
        public string app_id { get; set; }
        /// <summary>
        /// 绑定信息创建时间
        /// </summary>
        public string create_time { get; set; }
        /// <summary>
        /// 最后一次更新时间
        /// </summary>
        public string update_time { get; set; }
    }
}
