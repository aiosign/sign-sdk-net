using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.entity.request.bases;

namespace sign_sdk_net.entity.request.sign
{
    /// <summary>
    /// 一步签署 请求参数
    /// </summary>
    class DirectSignRequest : BaseSignRequest
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string user_name { set; get; }
        /// <summary>
        /// 用户类型,1个人，2企业
        /// </summary>
        public string user_type { set; get; }
        /// <summary>
        /// 证件号（个人对应身份证号，企业对应社会统一信用代码）
        /// </summary>
        public string id_number { set; get; }
        /// <summary>
        /// 合同文件
        /// </summary>
        public string contract_file_content { set; get; }
        /// <summary>
        /// 签署详情
        /// </summary>
        public List<SignDetail> sign_fields { set; get; }

        public void addSignField(SignDetail signDetail)
        {
            (sign_fields = sign_fields == null ? new List<SignDetail>() : sign_fields).Add(signDetail);
        }
        /// <summary>
        /// 签署详情
        /// </summary>
        public class SignDetail {
            /// <summary>
            /// 印章文件
            /// </summary>
            public string seal_file_content { set; get; }
            /// <summary>
            /// 印章宽度
            /// </summary>
            public double seal_width { set; get; }
            /// <summary>
            /// 印章高度
            /// </summary>
            public double seal_height { set; get; }
            /// <summary>
            /// 签署页数
            /// </summary>
            public int page_num { set; get; }
            /// <summary>
            /// 签章需要的横坐标
            /// </summary>
            public double horizontal { set; get; }
            /// <summary>
            /// 签章需要的纵坐标
            /// </summary>
            public double vertical { set; get; }
        }
    }
}
