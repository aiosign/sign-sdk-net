using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.response.scanContract
{
    /// <summary>
    /// 扫码合同响应值
    /// </summary>
    class ScanContractAddResonse
    {
        /// <summary>
		/// 预处理Id
		/// </summary>
		public string prepare_id { set; get; }

        /// <summary>
        /// 二维码
        /// </summary>
        public string qr { set; get; }
    }
}
