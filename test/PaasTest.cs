using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.client;
using sign_sdk_net.entity.request.bases;
using sign_sdk_net.exception;

namespace sign_sdk_net.test
{
    /// <summary>
    /// 原始调用Paas Api
    /// </summary>
    class PaasTest :BaseTest
    {
        private PaasClient client;

        public PaasTest(PaasClient paasClient)
        {
            testName = "Paas-Api接口";
            client = paasClient;
        }
        /// <summary>
        /// 原始调用Paas Api接口
        /// </summary>
        public void callApi()
        {
            //初始化请求参数，请参考API文档
            SignRequest request = new SignRequest();

            //请求API接口地址
            request.apiUrl = "/v1/seal/query";

            //请求API参数
            Dictionary<string, object> requestBody = new Dictionary<string, object>();
            requestBody.Add("seal_id", "051a3ebaa027d6bd530c2724b97c518c");
            request.requestBody = requestBody;

            
            try
            {
                Dictionary<string, object> response = client.Send<Dictionary<string, object>>(request);
                Console.WriteLine("原始调用Paas-Api接口-响应数据：" + JSONUtil.getJsonStringFromObject(response));
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("原始调用Paas-Api接口-网关异常状态码为：" + sae.return_code);
                Console.WriteLine("原始调用Paas-Api接口-网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("原始调用Paas-Api接口-业务异常状态码为：" + sse.result_code);
                Console.WriteLine("原始调用Paas-Api接口-业务异常信息为：" + sse.result_message);
            }
        }
    }
}
