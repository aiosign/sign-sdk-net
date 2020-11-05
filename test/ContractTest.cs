using System;
using System.Collections.Generic;
using System.IO;
using sign_sdk_net.client;
using sign_sdk_net.constant;
using sign_sdk_net.entity.request;
using sign_sdk_net.entity.request.contract;
using sign_sdk_net.entity.response.contract;
using sign_sdk_net.exception;
using static sign_sdk_net.entity.request.contract.ContractAbolishRequest;

namespace sign_sdk_net.test
{
	/// <summary>
    /// 合同测试
    /// </summary>
	class ContractTest : BaseTest
	{
		private SignClient client;

		public ContractTest(SignClient signClient)
		{
			this.testName = "合同";
			this.client = signClient;
		}
		/// <summary>
		/// 合同添加并添加合同文件
		/// </summary>
		public void addContractAndFile()
		{
			// 创建合同以及文件 
			ContractFileAddRequest contractFileAddRequest = new ContractFileAddRequest();

			// 合同请求数据 
			ContractAddRequest contractAddRequest = new ContractAddRequest();
			contractAddRequest.name = "合同测试";
			contractAddRequest.user_id = "00765245060136194048";
			contractAddRequest.description = "这是个新加合同";
			contractFileAddRequest.contractAddRequest = contractAddRequest;

			try
			{
				//合同文件上传
				FileUploadRequest fileUploadRequest = new FileUploadRequest("D://contract//我的合同.pdf", "我的合同.pdf", FileType.contract, "00765245060136194048");
				contractFileAddRequest.fileUploadRequest = fileUploadRequest;

				ContractAddResponse response = client.Contract.addContractAndFile(contractFileAddRequest);
				Console.WriteLine("合同以及文件添加-响应数据：" + JSONUtil.getJsonStringFromObject(response));
			}
			catch (SignApplicationException sae)
			{
				// 捕获网关校验数据
				Console.WriteLine("合同以及文件添加-网关异常状态码为：" + sae.return_code);
				Console.WriteLine("合同以及文件添加-网关异常信息为：" + sae.return_message);
			}
			catch (SignServerException sse)
			{
				// 捕获网关校验数据
				Console.WriteLine("合同以及文件添加-业务异常状态码为：" + sse.result_code);
				Console.WriteLine("合同以及文件添加-业务异常信息为：" + sse.result_message);
			}
			catch (Exception e)
			{
				Console.WriteLine("合同以及文件添加-异常为：" + e.Message);
			}
		}
		/// <summary>
		/// 添加合同
		/// </summary>
		public void add()
		{
			ContractAddRequest contractAddRequest = new ContractAddRequest();
			contractAddRequest.name = "合同测试";
			contractAddRequest.user_id = "00765245060136194048";
			contractAddRequest.description = "这是个新加合同";
			contractAddRequest.file_id = "0026adc7ba67382d02e7e5a4502ca90e";

			try
			{
				ContractAddResponse response = client.Contract.add(contractAddRequest);
				Console.WriteLine("添加合同-响应数据：" + JSONUtil.getJsonStringFromObject(response));
			}
			catch (SignApplicationException sae)
			{
				// 捕获网关校验数据
				Console.WriteLine("添加合同-网关异常状态码为：" + sae.return_code);
				Console.WriteLine("添加合同-网关异常信息为：" + sae.return_message);
			}
			catch (SignServerException sse)
			{
				// 捕获网关校验数据
				Console.WriteLine("添加合同-业务异常状态码为：" + sse.result_code);
				Console.WriteLine("添加合同-业务异常信息为：" + sse.result_message);
			}
		}
		/// <summary>
		/// 查询合同
		/// </summary>
		public void query()
		{
			try
			{
				ContractQueryResponse response = client.Contract.query(new ContractQueryRequest("789c8146f45f9a219a5d5ad11db2902c"));
				Console.WriteLine("查询合同-响应数据:" + JSONUtil.getJsonStringFromObject(response));
			}
			catch (SignApplicationException sae)
			{
				// 捕获网关校验数据
				Console.WriteLine("查询合同-网关异常状态码为：" + sae.return_code);
				Console.WriteLine("查询合同-网关异常信息为：" + sae.return_message);
			}
			catch (SignServerException sse)
			{
				// 捕获网关校验数据
				Console.WriteLine("查询合同-业务异常状态码为：" + sse.result_code);
				Console.WriteLine("查询合同-业务异常信息为：" + sse.result_message);
			}
		}
		/// <summary>
		/// 删除合同
		/// </summary>
		public void remove() 
		{
			try
			{
				ContractRemoveResponse response = client.Contract.remove(new ContractRemoveRequest("04f75e30762e35243e60ddaab7933117"));
				Console.WriteLine("删除合同-响应数据:" + JSONUtil.getJsonStringFromObject(response));
			}
			catch (SignApplicationException sae)
			{
				// 捕获网关校验数据
				Console.WriteLine("删除合同-网关异常状态码为：" + sae.return_code);
				Console.WriteLine("删除合同-网关异常信息为：" + sae.return_message);
			}
			catch (SignServerException sse)
			{
				// 捕获网关校验数据
				Console.WriteLine("删除合同-业务异常状态码为：" + sse.result_code);
				Console.WriteLine("删除合同-业务异常信息为：" + sse.result_message);
			}
		}
		/// <summary>
		/// 异步合同渲染
		/// </summary>
		public void render()
		{
			try
			{
				ContractRenderResponse response = client.Contract.render(new ContractRenderRequest("789c8146f45f9a219a5d5ad11db2902c"));
				Console.WriteLine("异步合同渲染-响应数据:" + JSONUtil.getJsonStringFromObject(response));
			}
			catch (SignApplicationException sae)
			{
				// 捕获网关校验数据
				Console.WriteLine("异步合同渲染-网关异常状态码为：" + sae.return_code);
				Console.WriteLine("异步合同渲染-网关异常信息为：" + sae.return_message);
			}
			catch (SignServerException sse)
			{
				// 捕获网关校验数据
				Console.WriteLine("异步合同渲染-业务异常状态码为：" + sse.result_code);
				Console.WriteLine("异步合同渲染-业务异常信息为：" + sse.result_message);
			}
		}
		/// <summary>
		/// 作废合同
		/// </summary>
		public void abolish() 
		{
			try
			{
				SignParams signParams = new SignParams();
				signParams.height = 50.0;
				signParams.width = 50.0;
				signParams.page_number = 2;
				signParams.horizontal = 120;
				signParams.vertical = 20;
				ContractAbolishResponse response = client.Contract.abolish(new ContractAbolishRequest("0006690e31224ac3a29a0f921cca1756", "00735875524752723968", signParams));
				Console.WriteLine("作废合同-响应数据:" + JSONUtil.getJsonStringFromObject(response));


			}
			catch (SignApplicationException sae)
			{
				// 捕获网关校验数据
				Console.WriteLine("作废合同-网关异常状态码为：" + sae.return_code);
				Console.WriteLine("作废合同-网关异常信息为：" + sae.return_message);
			}
			catch (SignServerException sse)
			{
				// 捕获网关校验数据
				Console.WriteLine("作废合同-业务异常状态码为：" + sse.result_code);
				Console.WriteLine("作废合同-业务异常信息为：" + sse.result_message);
			}
		}
		/// <summary>
		/// 作废合同V2
		/// </summary>
		public void abolishV2()
		{
			try
			{
				ContractAbolishV2Request.SignParams signParams = new ContractAbolishV2Request.SignParams();
				signParams.height = 50.0;
				signParams.width = 50.0;
				signParams.page_number = 2;
				signParams.horizontal = 120;
				signParams.vertical = 20;
				List<ContractAbolishV2Request.SignParams> fields = new List<ContractAbolishV2Request.SignParams>();
				fields.Add(signParams);

				ContractAbolishResponse response = client.Contract.abolishV2(new ContractAbolishV2Request("0006690e31224ac3a29a0f921cca1756", "00735875524752723968", fields));
				Console.WriteLine("作废合同V2-响应数据:" + JSONUtil.getJsonStringFromObject(response));


			}
			catch (SignApplicationException sae)
			{
				// 捕获网关校验数据
				Console.WriteLine("作废合同-网关异常状态码为：" + sae.return_code);
				Console.WriteLine("作废合同-网关异常信息为：" + sae.return_message);
			}
			catch (SignServerException sse)
			{
				// 捕获网关校验数据
				Console.WriteLine("作废合同-业务异常状态码为：" + sse.result_code);
				Console.WriteLine("作废合同-业务异常信息为：" + sse.result_message);
			}
		}
		/// <summary>
		/// 绑定合同
		/// </summary>
		public void bind()
		{
			ContractBindPhoneRequest contractBindPhoneRequest = new ContractBindPhoneRequest();
			contractBindPhoneRequest.contract_id = "789c8146f45f9a219a5d5ad11db2902c";
			ContractBindPhoneRequest.BindInfo bindInfo = new ContractBindPhoneRequest.BindInfo();
			bindInfo.phone = "13721111111";
			contractBindPhoneRequest.addParams(bindInfo);

			try
			{
				ContractBindPhoneResponse response= client.Contract.bind(contractBindPhoneRequest);
				Console.WriteLine("绑定合同-响应数据:" + JSONUtil.getJsonStringFromObject(response));
			}
			catch (SignApplicationException sae)
			{
				// 捕获网关校验数据
				Console.WriteLine("绑定合同-网关异常状态码为：" + sae.return_code);
				Console.WriteLine("绑定合同-网关异常信息为：" + sae.return_message);
			}
			catch (SignServerException sse)
			{
				// 捕获网关校验数据
				Console.WriteLine("绑定合同-业务异常状态码为：" + sse.result_code);
				Console.WriteLine("绑定合同-业务异常信息为：" + sse.result_message);
			}
		}
		/// <summary>
		/// 查询绑定合同
		/// </summary>
		public void queryBindContract()
		{
			ContractQueryBindRequest contractQueryBindRequest = new ContractQueryBindRequest();
			contractQueryBindRequest.contract_name = "绑定测试合同";
			contractQueryBindRequest.phone = "13721111111";

			try
			{
                List<ContractQueryBindResponse> response = client.Contract.queryBindContract(contractQueryBindRequest);
				Console.WriteLine("查询绑定合同-响应数据:" + JSONUtil.getJsonStringFromObject(response));
			}
			catch (SignApplicationException sae)
			{
				// 捕获网关校验数据
				Console.WriteLine("查询绑定合同-网关异常状态码为：" + sae.return_code);
				Console.WriteLine("查询绑定合同-网关异常信息为：" + sae.return_message);
			}
			catch (SignServerException sse)
			{
				// 捕获网关校验数据
				Console.WriteLine("查询绑定合同-业务异常状态码为：" + sse.result_code);
				Console.WriteLine("查询绑定合同-业务异常信息为：" + sse.result_message);
			}
		}
	}
}
