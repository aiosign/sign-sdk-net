using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.entity.request.bases;

namespace sign_sdk_net.entity.request.seal
{
    /// <summary>
    /// 查询用户所有的印章 请求参数
    /// </summary>
    class GetSealInfosByUserOrTypeRequest : BaseSignRequest
    {
        /// <summary>
        /// 用户id，以逗号分隔
        /// </summary>
        public string user_ids { set; get; }
        /// <summary>
        /// 印章类型，以逗号分隔
        /// </summary>
        public string seal_types { set; get; }
        /// <summary>
        /// 数据页码值
        /// </summary>
        public int page_num { set; get; }
        /// <summary>
        /// 数据长度
        /// </summary>
        public int page_size { set; get; }
    }
}
