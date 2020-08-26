using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.response.auth
{
    /// <summary>
    /// OCR银行卡 响应值
    /// </summary>
    public class OCRBankCardResponse
    {
        /// <summary>
        /// 银行卡号
        /// </summary>
        public string bank_card_number { set; get; }
        /// <summary>
        /// 验证日期
        /// </summary>
        public string valid_date { set; get; }
        /// <summary>
        /// 开户银行
        /// </summary>
        public string bank_name { set; get; }
        /// <summary>
        /// 银行卡类型
        /// </summary>
        public string bank_card_type { set; get; }
    }
}
