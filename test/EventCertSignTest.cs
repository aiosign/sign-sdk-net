using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.client;
using sign_sdk_net.entity.request.sign;
using sign_sdk_net.entity.response.sign;
using sign_sdk_net.exception;
using static sign_sdk_net.entity.request.sign.EventCertSignTemplateBatchRequest;

namespace sign_sdk_net.test
{
    /// <summary>
    /// 事件证书签章
    /// </summary>
    class EventCertSignTest : BaseTest
    {
        private SignClient client;

        public EventCertSignTest(SignClient signClient)
        {
            this.testName = "事件证书-签章";
            this.client = signClient;
        }

        public void eventCertSignTemplateSingle()
        {
            EventCertSignTemplateSingleRequest signTemplateSingleRequest = new EventCertSignTemplateSingleRequest();

            signTemplateSingleRequest.template_id = "983e7c49532738a14e1d1aeb02d65775";
            EventCertSignField signField = new EventCertSignField();

            EventCertSignParams param = new EventCertSignParams();
            param.height = 50;
            param.width = 50;
            param.user_id = "00765245060136194048";
            param.seal_id = "babeef37549d22cbb50ce5436cdb3037";
            param.sign_key = "sign";
            signField.addSignParams(param);

            EventCertTextParams textParam = new EventCertTextParams();
            textParam.key = "name";
            textParam.value = "单测试";
            signField.addTextParams(textParam);

            signTemplateSingleRequest.sign_field = signField;

            try
            {
                EventCertSignTemplateSingleResponse response = client.EventCertSign.eventCertSignTemplateSingle(signTemplateSingleRequest);
                Console.WriteLine("事件证书-单次模板签章-响应数据:" + JSONUtil.getJsonStringFromObject(response));
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("事件证书-单次模板签章-网关异常状态码为：" + sae.return_code);
                Console.WriteLine("事件证书-单次模板签章-网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("事件证书-单次模板签章-业务异常状态码为：" + sse.result_code);
                Console.WriteLine("事件证书-单次模板签章-业务异常信息为：" + sse.result_message);
            }
        }
        public void eventCertSignTemplateBatch()
        {
            EventCertSignTemplateBatchRequest signTemplateBatchRequest = new EventCertSignTemplateBatchRequest();
            signTemplateBatchRequest.template_id = "983e7c49532738a14e1d1aeb02d65775";
            EventCertBatchTemplates batchTemplates = new EventCertBatchTemplates();
            batchTemplates.custom_id = "12639f12a9e5374d824b45981f276cc5";

            EventCertSignParams param = new EventCertSignParams();
            param.height = 50;
            param.width = 50;
            param.user_id = "00765245060136194048";
            param.seal_id = "babeef37549d22cbb50ce5436cdb3037";
            param.sign_key = "sign";
            batchTemplates.addSignParams(param);

            EventCertTextParams textParam = new EventCertTextParams();
            textParam.key = "day2";
            textParam.value = "批量测试";
            batchTemplates.addTextParams(textParam);

            signTemplateBatchRequest.addBatchTempLate(batchTemplates);

            try
            {
                EventCertSignTemplateBatchResponse response = client.EventCertSign.eventCertSignTemplateBatch(signTemplateBatchRequest);
                Console.WriteLine("事件证书-批量签章-响应数据:" + JSONUtil.getJsonStringFromObject(response));

            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("事件证书-批量签章-网关异常状态码为：" + sae.return_code);
                Console.WriteLine("事件证书-批量签章-网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("事件证书-批量签章-业务异常状态码为：" + sse.result_code);
                Console.WriteLine("事件证书-批量签章-业务异常信息为：" + sse.result_message);
            }
        }
        /// <summary>
        /// 事件证书-合同坐标签章
        /// </summary>
        public void eventCertSignCommon()
        {
            SignCommonRequest signCommonRequest = new SignCommonRequest();
            signCommonRequest.contract_id = "789c8146f45f9a219a5d5ad11db2902c";
            signCommonRequest.user_id = "00765245060136194048";
            signCommonRequest.remark = "坐标签章";

            Fields field = new Fields();
            field.height = 40;
            field.width = 40;
            field.horizontal = 30;
            field.vertical = 30;
            field.page_number = 2;
            field.seal_id = "babeef37549d22cbb50ce5436cdb3037";
          
            signCommonRequest.addFields(field);

            try
            {
                EventCertSignCommonResponse response = client.EventCertSign.eventCertSignCommon(signCommonRequest);
                Console.WriteLine("事件证书-合同坐标签章-响应数据:" + JSONUtil.getJsonStringFromObject(response));
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("事件证书-合同坐标签章-网关异常状态码为：" + sae.return_code);
                Console.WriteLine("事件证书-合同坐标签章-网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("事件证书-合同坐标签章-业务异常状态码为：" + sse.result_code);
                Console.WriteLine("事件证书-合同坐标签章-业务异常信息为：" + sse.result_message);
            }

        }
        /// <summary>
        /// 事件证书-关键字签章接口
        /// </summary>
        public void eventCertKeywordSign()
        {
            SignKeywordSignRequest signKeywordSignRequest = new SignKeywordSignRequest();
            signKeywordSignRequest.contract_id = "789c8146f45f9a219a5d5ad11db2902c";
            signKeywordSignRequest.keyword = "测试";
            signKeywordSignRequest.seal_id = "babeef37549d22cbb50ce5436cdb3037";
            signKeywordSignRequest.sign_all = false;
            signKeywordSignRequest.user_id = "00765245060136194048";
            signKeywordSignRequest.width = 50;
            signKeywordSignRequest.height = 50;

            try
            {
                EventCertSignKeywordSignResponse response = client.EventCertSign.eventCertKeywordSign(signKeywordSignRequest);
                Console.WriteLine("事件证书-关键字签章-响应数据:" + JSONUtil.getJsonStringFromObject(response));
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("事件证书-关键字签章-网关异常状态码为：" + sae.return_code);
                Console.WriteLine("事件证书-关键字签章-网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("事件证书-关键字签章-业务异常状态码为：" + sse.result_code);
                Console.WriteLine("事件证书-关键字签章-业务异常信息为：" + sse.result_message);
            }
        }
        /// <summary>
        /// 事件证书-会签接口
        /// </summary>
        public void eventCertMeetingSingle()
        {
            SignMeetingSingleRequest signMeetingSingleRequest = new SignMeetingSingleRequest();
            signMeetingSingleRequest.contract_id = "789c8146f45f9a219a5d5ad11db2902c";
         
            SignDetails sign = new SignDetails();
            sign.page_num = 1;
            sign.seal_id = "babeef37549d22cbb50ce5436cdb3037";
            sign.user_id = "00765245060136194048";
            sign.sign_height = 40;
            sign.sign_width = 50;
            sign.sign_top = 10;
            sign.sign_left = 20;

            signMeetingSingleRequest.addSignDetails(sign);

            try
            {
                EventCertSignMeetingSingleResponse response = client.EventCertSign.eventCertMeetingSingle(signMeetingSingleRequest);
                Console.WriteLine("事件证书-会签-响应数据:" + JSONUtil.getJsonStringFromObject(response));
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("事件证书-会签-网关异常状态码为：" + sae.return_code);
                Console.WriteLine("事件证书-会签-网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("事件证书-会签-业务异常状态码为：" + sse.result_code);
                Console.WriteLine("事件证书-会签-业务异常信息为：" + sse.result_message);
            }
        }
        /// <summary>
        /// 事件证书-扫码签章
        /// </summary>
        public void eventCertScanSign()
        {
            try
            {
                EventCertSignScanContractResponse signScanContractResponse = client.EventCertSign.eventCertScanSign(new SignScanContractRequest("419aac08f35245b597002c1b8eae2745"));
                Console.WriteLine("事件证书-扫码签章-响应数据:" + JSONUtil.getJsonStringFromObject(signScanContractResponse));
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("事件证书-扫码签章-网关异常状态码为：" + sae.return_code);
                Console.WriteLine("事件证书-扫码签章-网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("事件证书-扫码签章-业务异常状态码为：" + sse.result_code);
                Console.WriteLine("事件证书-扫码签章-业务异常信息为：" + sse.result_message);
            }
        }
    }
}
