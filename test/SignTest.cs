using System;
using sign_sdk_net.client;
using sign_sdk_net.entity.request.sign;
using sign_sdk_net.entity.response.sign;
using sign_sdk_net.exception;

namespace sign_sdk_net.test
{
	/// <summary>
	/// 签章测试
	/// </summary>
	class SignTest : BaseTest
    {
		private SignClient client;

		public SignTest(SignClient signClient)
		{
            this.testName = "签章";
            this.client = signClient;
		}
		/// <summary>
		/// 单次模板签章
		/// </summary>
		public void signTemplateSingle()
		{
            SignTemplateSingleRequest signTemplateSingleRequest = new SignTemplateSingleRequest();
            signTemplateSingleRequest.template_id = "983e7c49532738a14e1d1aeb02d65775";
            SignField signField = new SignField();

            SignParams param = new SignParams();
            param.height = 50;
            param.width = 50;
            param.user_id = "00765245060136194048";
            param.seal_id = "babeef37549d22cbb50ce5436cdb3037";
            param.sign_key = "sign";
            signField.addSignParams(param);

            TextParams textParam = new TextParams();
            textParam.key = "name";
            textParam.value = "单测试";
            signField.addTextParams(textParam);

            signTemplateSingleRequest.sign_field = signField;

            try
            {
                SignTemplateSingleResponse response = client.SignOperate.signTemplateSingle(signTemplateSingleRequest);
                Console.WriteLine("单次模板签章-响应数据:" + JSONUtil.getJsonStringFromObject(response));
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("单次模板签章-网关异常状态码为：" + sae.return_code);
                Console.WriteLine("单次模板签章-网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("单次模板签章-业务异常状态码为：" + sse.result_code);
                Console.WriteLine("单次模板签章-业务异常信息为：" + sse.result_message);
            }
        }
        /// <summary>
        /// 批量模板签章
        /// </summary>
        public void signTemplateBatch()
        {
            SignTemplateBatchRequest signTemplateBatchRequest = new SignTemplateBatchRequest();
            signTemplateBatchRequest.template_id = "983e7c49532738a14e1d1aeb02d65775";
            BatchTemplates batchTemplates = new BatchTemplates();
            batchTemplates.custom_id = "63344f1ab262c3d75d4e5c6e1630b4da";

       
            SignParamsB param = new SignParamsB();
            param.height = 50;
            param.width = 50;
            param.user_id = "00765245060136194048";
            param.seal_id = "babeef37549d22cbb50ce5436cdb3037";
            param.sign_key = "sign";
            batchTemplates.addSignParams(param);

            TextParamsB textParam = new TextParamsB();
            textParam.key = "day2";
            textParam.value = "批量测试";
            batchTemplates.addTextParams(textParam);

            signTemplateBatchRequest.addBatchTempLate(batchTemplates);

            try
            {
                SignTemplateBatchResponse response = client.SignOperate.signTemplateBatch(signTemplateBatchRequest);
                Console.WriteLine("批量模板签章-响应数据:" + JSONUtil.getJsonStringFromObject(response));

            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("批量模板签章-网关异常状态码为：" + sae.return_code);
                Console.WriteLine("批量模板签章-网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("批量模板签章-业务异常状态码为：" + sse.result_code);
                Console.WriteLine("批量模板签章-业务异常信息为：" + sse.result_message);
            }
        }

        /// <summary>
        /// 合同坐标签章
        /// </summary>
        public void signCommon()
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
                SignCommonResponse response = client.SignOperate.signCommon(signCommonRequest);
                Console.WriteLine("合同坐标签章-响应数据:" + JSONUtil.getJsonStringFromObject(response));
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("合同坐标签章-网关异常状态码为：" + sae.return_code);
                Console.WriteLine("合同坐标签章-网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("合同坐标签章-业务异常状态码为：" + sse.result_code);
                Console.WriteLine("合同坐标签章-业务异常信息为：" + sse.result_message);
            }
        }
        /// <summary>
        /// 关键字签章
        /// </summary>
        public void keywordSign()
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
                SignKeywordSignResponse response = client.SignOperate.keywordSign(signKeywordSignRequest);
                Console.WriteLine("关键字签章-响应数据:" + JSONUtil.getJsonStringFromObject(response));
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("关键字签章-网关异常状态码为：" + sae.return_code);
                Console.WriteLine("关键字签章-网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("关键字签章-业务异常状态码为：" + sse.result_code);
                Console.WriteLine("关键字签章-业务异常信息为：" + sse.result_message);
            }
        }

        /// <summary>
        /// 会签签章
        /// </summary>
        public void meetingSingle()
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
                SignMeetingSingleResponse response = client.SignOperate.meetingSingle(signMeetingSingleRequest);
                Console.WriteLine("会签签章-响应数据:" + JSONUtil.getJsonStringFromObject(response));
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("会签签章-网关异常状态码为：" + sae.return_code);
                Console.WriteLine("会签签章-网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("会签签章-业务异常状态码为：" + sse.result_code);
                Console.WriteLine("会签签章-业务异常信息为：" + sse.result_message);
            }
        }
        /// <summary>
        /// 扫码签章
        /// </summary>
        public void scanSign()
        {
            try
            {
                SignScanContractResponse response = client.SignOperate.scanSign(new SignScanContractRequest("12f317a11c2c4852aef628bca9732b1c"));
                Console.WriteLine("扫码签章-响应数据:" + JSONUtil.getJsonStringFromObject(response));
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("扫码签章-网关异常状态码为：" + sae.return_code);
                Console.WriteLine("扫码签章-网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("扫码签章-业务异常状态码为：" + sse.result_code);
                Console.WriteLine("扫码签章-业务异常信息为：" + sse.result_message);
            }
        }
        /// <summary>
        /// 一步签署
        /// </summary>
        public void directSign()
        {
            DirectSignRequest directSignRequest = new DirectSignRequest();
            directSignRequest.contract_file_content = "Base64";
            directSignRequest.id_number = "370011123456712121";
            directSignRequest.user_name = "测试";
            directSignRequest.user_type = "1";
        
            DirectSignRequest.SignDetail signDetail = new DirectSignRequest.SignDetail();
            signDetail.page_num = 1;
            signDetail.seal_width = 50;
            signDetail.seal_height = 50;
            signDetail.seal_file_content = "Base64";//Base64文件
            signDetail.vertical = 40;
            signDetail.horizontal = 40;

            directSignRequest.addSignField(signDetail);
            try
            {
                DirectSignResponse response = client.SignOperate.directSign(directSignRequest);
                Console.WriteLine("一步签署-响应数据:" + JSONUtil.getJsonStringFromObject(response));
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("一步签署-网关异常状态码为：" + sae.return_code);
                Console.WriteLine("一步签署-网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("一步签署-业务异常状态码为：" + sse.result_code);
                Console.WriteLine("一步签署-业务异常信息为：" + sse.result_message);
            }
        }
    }
}
