using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.entity.request.bases;

namespace sign_sdk_net.entity.request.scanContract
{
    /// <summary>
    /// 扫码合同添加请求参数
    /// </summary>
    class ScanContractAddRequest : BaseSignRequest
    {
        /// <summary>
        /// 合同id
        /// </summary>
        public string contract_id { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public string user_id { get; set; }
        /// <summary>
        /// 签署备注
        /// </summary>
        public string remark { get; set; }
        /// <summary>
        /// 扫码回调地址
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 二维码宽度
        /// </summary>
        public int qr_code_width { get; set; }
        /// <summary>
        /// 二维码高度
        /// </summary>
        public int qr_code_height { get; set; }
        /// <summary>
        /// 扫码回调地址
        /// </summary>
        public string expire_time { get; set; }
        /// <summary>
		/// 预处理签署信息
		/// </summary>
		public List<Fields> fields { set; get; }
        /// <summary>
        /// 预处理签署信息
        /// </summary>
        public class Fields
        {
            /// <summary>
            /// 印章高度
            /// </summary>
            public double height { set; get; }
            /// <summary>
            /// 水平横坐标
            /// </summary>
            public double horizontal { set; get; }
            /// <summary>
            /// 签章页数
            /// </summary>
            public int page_number { set; get; }
            /// <summary>
            /// 印章ID
            /// </summary>
            public string seal_id { set; get; }
            /// <summary>
            /// 垂直纵坐标
            /// </summary>
            public double vertical { set; get; }
            /// <summary>
            /// 印章宽度
            /// </summary>
            public double width { set; get; }
        }
    }
}
