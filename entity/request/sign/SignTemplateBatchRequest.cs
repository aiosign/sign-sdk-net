using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.entity.request.bases;

namespace sign_sdk_net.entity.request.sign
{
    /// <summary>
    /// 批量模板签章请求参数
    /// </summary>
    public class SignTemplateBatchRequest : BaseSignRequest
    {

        /// <summary>
        /// 模板id
        /// </summary>
        public string template_id { set; get; }
        /// <summary>
        /// 签章参数
        /// </summary>
        public List<BatchTemplates> batch_templates { set; get; }

        /// <summary>
        /// 添加签章参数
        /// </summary>
        /// <param name="batchTemplate"></param>
        public void addBatchTempLate(BatchTemplates batchTemplate)
        {
            (batch_templates = batch_templates == null ? new List<BatchTemplates>() : batch_templates).Add(batchTemplate);
        }
    }
    /// <summary>
    /// 文本域
    /// </summary>
    public class TextParamsB
    {
        /// <summary>
        /// 填充参数key
        /// </summary>
        public string key { set; get; }
        /// <summary>
        /// 填充值
        /// </summary>
        public string value { set; get; }
    }
    public class BatchTemplates
    {
        /// <summary>
        /// 用户自定义ID
        /// </summary>
        public string custom_id { set; get; }
        /// <summary>
        /// 签名域信息
        /// </summary>
        public List<SignParamsB> sign_params { set; get; }
        /// <summary>
        /// 文本域信息
        /// </summary>
        public List<TextParamsB> text_params { set; get; }
    }
    /// <summary>
    /// 签名域信息
    /// </summary>
    public class SignParamsB
    {
        /// <summary>
        /// 印章ID
        /// </summary>
        public string seal_id { set; get; }
        /// <summary>
        /// 签名域
        /// </summary>
        public string sign_key { set; get; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public string user_id { set; get; }
        /// <summary>
        /// 印章宽度
        /// </summary>
        public double width { set; get; }
        /// <summary>
        /// 印章高度
        /// </summary>
        public double height { set; get; }
        /// <summary>
		/// 是否为图章入参
		/// </summary>
		public Boolean is_picture { set; get; }
    }
}
