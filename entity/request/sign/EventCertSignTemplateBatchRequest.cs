using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.entity.request.bases;

namespace sign_sdk_net.entity.request.sign
{
    class EventCertSignTemplateBatchRequest : BaseSignRequest
    {

        /// <summary>
        /// 模板id
        /// </summary>
        public string template_id { set; get; }
        /// <summary>
        /// 签章参数
        /// </summary>
        public List<EventCertBatchTemplates> batch_templates { set; get; }


        public class EventCertBatchTemplates
        {
            /// <summary>
            /// 用户自定义ID
            /// </summary>
            public string custom_id { set; get; }
            /// <summary>
            /// 签名域信息
            /// </summary>
            public List<EventCertSignParams> sign_params { set; get; }

            public void addSignParams(EventCertSignParams signParams)
            {
                (sign_params = sign_params == null ? new List<EventCertSignParams>() : sign_params).Add(signParams);
            }
            /// <summary>
            /// 文本域信息
            /// </summary>
            public List<EventCertTextParams> text_params { set; get; }
            public void addTextParams(EventCertTextParams textParams)
            {
                (text_params = text_params == null ? new List<EventCertTextParams>() : text_params).Add(textParams);
            }
        }

        /// <summary>
        /// 添加签章参数
        /// </summary>
        /// <param name="batchTemplate"></param>
        public void addBatchTempLate(EventCertBatchTemplates eventCertBatch)
        {
            (batch_templates = batch_templates == null ? new List<EventCertBatchTemplates>() : batch_templates).Add(eventCertBatch);
        }
    }
}
