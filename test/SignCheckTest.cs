using System;
using System.IO;
using sign_sdk_net.client;
using sign_sdk_net.entity.request;
using sign_sdk_net.entity.request.signCheck;
using sign_sdk_net.entity.response.signCheck;
using sign_sdk_net.exception;

namespace sign_sdk_net.test
{
	/// <summary>
    /// 验签测试
    /// </summary>
	class SignCheckTest : BaseTest
	{
		private SignClient client;

		public SignCheckTest(SignClient signClient)
		{
			this.testName = "验签";
			this.client = signClient;
		}
		/// <summary>
		/// 文件id 验章
		/// </summary>
		public void checkCommon()
		{
			try
			{
				SignCheckCommonResponse response = client.SignCheck.checkCommon(new SignCheckCommonRequest("94b7ea6be791ca55cb21f76f5a9ebbc3"));
				Console.WriteLine("文件Id验章-响应数据:" + JSONUtil.getJsonStringFromObject(response));

			}
			catch (SignApplicationException sae)
			{
				// 捕获网关校验数据
				Console.WriteLine("文件Id验章-网关异常状态码为：" + sae.return_code);
				Console.WriteLine("文件Id验章-网关异常信息为：" + sae.return_message);
			}
			catch (SignServerException sse)
			{
				// 捕获网关校验数据
				Console.WriteLine("文件Id验章-业务异常状态码为：" + sse.result_code);
				Console.WriteLine("文件Id验章-业务异常信息为：" + sse.result_message);
			}
		}
		/// <summary>
		/// 文件验签
		/// </summary>
		public void checkFile()
		{

			try
			{
				FileUploadRequest fileUploadRequest = new FileUploadRequest("D://contract//签署完成合同.pdf", "签署完成合同.pdf");

				SignCheckFileRequest signCheckFileRequest = new SignCheckFileRequest();
				signCheckFileRequest.fileData = fileUploadRequest.fileData;
				signCheckFileRequest.fileDataName = fileUploadRequest.fileDataName;

				SignCheckFileResponse signCheckFileResponse = client.SignCheck.checkFile(signCheckFileRequest);
				Console.WriteLine("文件验签-响应数据:" + JSONUtil.getJsonStringFromObject(signCheckFileResponse));

			}
			catch (SignApplicationException sae)
			{
				// 捕获网关校验数据
				Console.WriteLine("文件验签-网关异常状态码为：" + sae.return_code);
				Console.WriteLine("文件验签-网关异常信息为：" + sae.return_message);
			}
			catch (SignServerException sse)
			{
				// 捕获网关校验数据
				Console.WriteLine("文件验签-业务异常状态码为：" + sse.result_code);
				Console.WriteLine("文件验签-业务异常信息为：" + sse.result_message);
			}
			catch (Exception e) 
			{
				Console.WriteLine("文件验签-异常为：" + e.Message);
			}
		}
	}
}
