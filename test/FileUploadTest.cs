using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.client;
using sign_sdk_net.constant;
using sign_sdk_net.entity.request;
using sign_sdk_net.entity.response;
using sign_sdk_net.exception;

namespace sign_sdk_net.test
{
    /// <summary>
    /// 文件上传
    /// </summary>
    class FileUploadTest : BaseTest
    {
        private FileManagerClient client;

        public FileUploadTest(FileManagerClient fileManagerClient)
        {
            this.testName = "文件上传";
            this.client = fileManagerClient;
        }

        /// <summary>
        /// 上传印章文件
        /// </summary>
        public void uploadSeal()
        {
            try
            {
                FileUploadRequest fileUploadRequest = new FileUploadRequest("D:/seal/seal.png", "我的印章.png", FileType.impression, "00765245060136194048");

                FileUploadResponse response = client.fileUpload(fileUploadRequest);

                Console.WriteLine("上传印章文件-响应数据:" + JSONUtil.getJsonStringFromObject(response));
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("上传印章文件-网关异常状态码为：" + sae.return_code);
                Console.WriteLine("上传印章文件-网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("上传印章文件-业务异常状态码为：" + sse.result_code);
                Console.WriteLine("上传印章文件-业务异常信息为：" + sse.result_message);
            }
            catch (Exception e)
            {
                Console.WriteLine("上传印章文件-异常：" + e.Message);
            }
        }
        /// <summary>
        /// 上传合同文件
        /// </summary>
        public void uploadContract()
        {
            try
            {
                FileUploadRequest fileUploadRequest = new FileUploadRequest("D://contract//我的合同.pdf", "我的合同.pdf", FileType.contract, "00765245060136194048");

                FileUploadResponse response = client.fileUpload(fileUploadRequest);

                Console.WriteLine("上传合同文件-响应数据:" + JSONUtil.getJsonStringFromObject(response));
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("上传合同文件-网关异常状态码为：" + sae.return_code);
                Console.WriteLine("上传合同文件-网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("上传合同文件-业务异常状态码为：" + sse.result_code);
                Console.WriteLine("上传合同文件-业务异常信息为：" + sse.result_message);
            }
            catch (Exception e)
            {
                Console.WriteLine("上传合同文件-异常：" + e.Message);
            }
        }
        /// <summary>
        /// 上传模板文件
        /// </summary>
        public void uploadTemplate()
        {
            try
            {
                FileUploadRequest fileUploadRequest = new FileUploadRequest("D://telmplate//劳动合同模板.pdf", "劳动合同模板.pdf", FileType.template, "00765245060136194048");

                FileUploadResponse response = client.fileUpload(fileUploadRequest);

                Console.WriteLine("上传模板文件-响应数据:" + JSONUtil.getJsonStringFromObject(response));
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("上传模板文件-网关异常状态码为：" + sae.return_code);
                Console.WriteLine("上传模板文件-网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("上传模板文件-业务异常状态码为：" + sse.result_code);
                Console.WriteLine("上传模板文件-业务异常信息为：" + sse.result_message);
            }
            catch (Exception e)
            {
                Console.WriteLine("上传合同文件-异常：" + e.Message);
            }
        }
    }
}
