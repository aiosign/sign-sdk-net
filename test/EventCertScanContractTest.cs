using System;
using System.Collections.Generic;
using sign_sdk_net.client;
using sign_sdk_net.entity.request.scanContract;
using sign_sdk_net.entity.response.scanContract;
using sign_sdk_net.exception;

namespace sign_sdk_net.test
{
	/// <summary>
	///事件证书-扫码合同
	/// </summary>
	class EventCertScanContractTest : BaseTest
	{
		private SignClient client;

		public EventCertScanContractTest(SignClient signClient)
		{
			this.testName = "事件证书-扫码合同";
			this.client = signClient;
		}

		/// <summary>
		/// 添加扫码合同
		/// </summary>
		public void add()
		{
			ScanContractAddRequest scanContractAddRequest = new ScanContractAddRequest();
			scanContractAddRequest.contract_id = "789c8146f45f9a219a5d5ad11db2902c";
			scanContractAddRequest.user_id = "00765245060136194048";
			scanContractAddRequest.expire_time = "2020-12-18 22:53:30";
			scanContractAddRequest.remark = "无数据";
			scanContractAddRequest.qr_code_width = 125;
			scanContractAddRequest.qr_code_height = 125;
			scanContractAddRequest.url = "https://aiosign.com/";//扫码跳转地址
			List<ScanContractAddRequest.Fields> fields = new List<ScanContractAddRequest.Fields>();
			ScanContractAddRequest.Fields field = new ScanContractAddRequest.Fields();
			field.height = 50;
			field.width = 50;
			field.horizontal = 40;
			field.page_number = 1;
			field.vertical = 40;
			field.seal_id = "babeef37549d22cbb50ce5436cdb3037";
			fields.Add(field);
			scanContractAddRequest.fields = fields;
			try
			{
				ScanContractAddResonse resonse = client.EventCertScanContract.add(scanContractAddRequest);
				Console.WriteLine("事件证书-扫码合同添加-响应数据:" + JSONUtil.getJsonStringFromObject(resonse));
			}
			catch (SignApplicationException sae)
			{
				// 捕获网关校验数据
				Console.WriteLine("事件证书-扫码合同添加-网关异常状态码为：" + sae.return_code);
				Console.WriteLine("事件证书-扫码合同添加-网关异常信息为：" + sae.return_message);
			}
			catch (SignServerException sse)
			{
				// 捕获网关校验数据
				Console.WriteLine("事件证书-扫码合同添加-业务异常状态码为：" + sse.result_code);
				Console.WriteLine("事件证书-扫码合同添加-业务异常信息为：" + sse.result_message);
			}
		}
	}
}
