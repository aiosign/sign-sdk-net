using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.response.auth
{
    /// <summary>
    /// 加密请求下三网认证 响应值
    /// </summary>
    public class AuthEncryResponse
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string name { set; get; }
        /// <summary>
        /// 身份证号码
        /// </summary>
        public string id_card { set; get; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string phone { set; get; }
        /// <summary>
        /// 状态
        /// </summary>
        public string res { set; get; }
        /// <summary>
        /// 结果信息
        /// </summary>
        public string resmsg { set; get; }
        /// <summary>
        /// 运营商
        /// </summary>
        public string type { set; get; }
        /// <summary>
        /// 省份
        /// </summary>
        public string province { set; get; }
        /// <summary>
        /// 市区
        /// </summary>
        public string city { set; get; }
        /// <summary>
        /// 详情码
        /// </summary>
        public string rescode { set; get; }
    }
}
