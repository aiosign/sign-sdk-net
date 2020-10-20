using System;
using System.Collections.Generic;
using System.IO;
using sign_sdk_net.client;
using sign_sdk_net.constant;
using sign_sdk_net.entity.request;
using sign_sdk_net.entity.request.seal;
using sign_sdk_net.entity.response.seal;
using sign_sdk_net.exception;

namespace sign_sdk_net.test
{
	/// <summary>
    /// 印章测试
    /// </summary>
	class SealTest : BaseTest
	{
		private SignClient client;

        public SealTest(SignClient signClient)
		{
			this.testName = "印章";
			this.client = signClient;
		}

		/// <summary>
		/// 新增印章以及文件
		/// </summary>
		public void addSealAndFile()
		{
			SealFileAddRequest sealFileAddRequest = new SealFileAddRequest();
			
			SealAddRequest sealAddRequest = new SealAddRequest();
			sealAddRequest.user_id = "00765245060136194048";
			sealAddRequest.seal_name = "测试印章D";
			sealAddRequest.seal_type = SealType.CORPORATE;
			sealAddRequest.size = "40*40";
			sealAddRequest.description = "备注法人章";
			sealFileAddRequest.sealAddRequest = sealAddRequest;

			try
			{
				//印章文件上传
				FileUploadRequest fileUploadRequest = new FileUploadRequest("D:/seal/seal.png", "我的印章.png", FileType.impression, "00765245060136194048");
				sealFileAddRequest.fileUploadRequest = fileUploadRequest;

				SealAddResponse response = client.Seal.addSealAndFile(sealFileAddRequest);
				Console.WriteLine("新增印章以及文件-响应数据：" + JSONUtil.getJsonStringFromObject(response));
			}
			catch (SignApplicationException sae)
			{
				// 捕获网关校验数据
				Console.WriteLine("新增印章以及文件-网关异常状态码为：" + sae.return_code);
				Console.WriteLine("新增印章以及文件-网关异常信息为：" + sae.return_message);
			}
			catch (SignServerException sse)
			{
				// 捕获网关校验数据
				Console.WriteLine("新增印章以及文件-业务异常状态码为：" + sse.result_code);
				Console.WriteLine("新增印章以及文件-业务异常信息为：" + sse.result_message);
			}
			catch (Exception e)
			{
				Console.WriteLine("新增印章以及文件-异常为：" + e.Message);
			}

		}
		/// <summary>
		/// 新增印章
		/// </summary>
		public void add()
		{
			SealAddRequest sealAddRequest = new SealAddRequest();
			sealAddRequest.user_id = "00765245060136194048";
			sealAddRequest.seal_name = "测试印章D";
			sealAddRequest.seal_type = SealType.CORPORATE;
			sealAddRequest.size = "40*40";
			sealAddRequest.description = "备注法人章";
			sealAddRequest.file_id = "1044188e6f337c07a0f18087ea5e6a74";

			try
			{
				SealAddResponse response = client.Seal.add(sealAddRequest);
				Console.WriteLine("印章以及文件添加-响应数据：" + JSONUtil.getJsonStringFromObject(response));
			}
			catch (SignApplicationException sae)
			{
				// 捕获网关校验数据
				Console.WriteLine("印章以及文件添加-网关异常状态码为：" + sae.return_code);
				Console.WriteLine("印章以及文件添加-网关异常信息为：" + sae.return_message);
			}
			catch (SignServerException sse)
			{
				// 捕获网关校验数据
				Console.WriteLine("印章以及文件添加-业务异常状态码为：" + sse.result_code);
				Console.WriteLine("印章以及文件添加-业务异常信息为：" + sse.result_message);
			}
		}
		/// <summary>
		///  根据用户查询所有印章
		/// </summary>
		public void sealGetSealInfos()
		{
			try
			{
				List<GetSealInfosResponse> getSealInfosResponse = client.Seal.getSealInfos(new GetSealInfosRequest("00765245060136194048"));
				Console.WriteLine("根据用户查询印章-响应数据:" + JSONUtil.getJsonStringFromObject(getSealInfosResponse));

			}
			catch (SignApplicationException sae)
			{
				// 捕获网关校验数据
				Console.WriteLine("根据用户查询印章-网关异常状态码为：" + sae.return_code);
				Console.WriteLine("根据用户查询印章-网关异常信息为：" + sae.return_message);
			}
			catch (SignServerException sse)
			{
				// 捕获网关校验数据
				Console.WriteLine("根据用户查询印章-业务异常状态码为：" + sse.result_code);
				Console.WriteLine("根据用户查询印章-业务异常信息为：" + sse.result_message);
			}
		}
		/// <summary>
		///  根据用户、印章类型查询所有印章
		/// </summary>
		public void getSealInfosByUserOrType()
		{
			GetSealInfosByUserOrTypeRequest request = new GetSealInfosByUserOrTypeRequest();
			request.page_num = 1;//数据页码
			request.page_size = 10;//数据长度
			request.user_ids = "00765245060136194048,10728297460485214208";//用户ID，以逗号分隔
			request.seal_types = "01,99";//印章类型，以逗号分隔
			try
			{
				List<GetSealInfosByUserOrTypeResponse> getSealInfosResponse = client.Seal.getSealInfosByUserOrType(request);
				Console.WriteLine("根据用户、印章类型查询所有印章-响应数据:" + JSONUtil.getJsonStringFromObject(getSealInfosResponse));

			}
			catch (SignApplicationException sae)
			{
				// 捕获网关校验数据
				Console.WriteLine("根据用户、印章类型查询所有印章-网关异常状态码为：" + sae.return_code);
				Console.WriteLine("根据用户、印章类型查询所有印章-网关异常信息为：" + sae.return_message);
			}
			catch (SignServerException sse)
			{
				// 捕获网关校验数据
				Console.WriteLine("根据用户、印章类型查询所有印章-业务异常状态码为：" + sse.result_code);
				Console.WriteLine("根据用户、印章类型查询所有印章-业务异常信息为：" + sse.result_message);
			}
		}

		/// <summary>
		/// 注销印章
		/// </summary>
		public void remove()
		{
			try
			{
				SealRemoveResponse sealRemoveResponse = client.Seal.remove(new SealRemoveRequest("babeef37549d22cbb50ce5436cdb3137"));
				Console.WriteLine("注销印章-响应数据:" + JSONUtil.getJsonStringFromObject(sealRemoveResponse));

			}
			catch (SignApplicationException sae)
			{
				// 捕获网关校验数据
				Console.WriteLine("注销印章-网关异常状态码为：" + sae.return_code);
				Console.WriteLine("注销印章-网关异常信息为：" + sae.return_message);
			}
			catch (SignServerException sse)
			{
				// 捕获网关校验数据
				Console.WriteLine("注销印章-业务异常状态码为：" + sse.result_code);
				Console.WriteLine("注销印章-业务异常信息为：" + sse.result_message);
			}
		}

		/// <summary>
		/// 印章锁定
		/// </summary>
		public void sealLock()
		{
			try
			{
				SealLockResponse sealRemoveResponse = client.Seal.sealLock(new SealLockRequest("babeef37549d22cbb50ce5436cdb3037"));
				Console.WriteLine("锁定印章-响应数据:" + JSONUtil.getJsonStringFromObject(sealRemoveResponse));

			}
			catch (SignApplicationException sae)
			{
				// 捕获网关校验数据
				Console.WriteLine("锁定印章-网关异常状态码为：" + sae.return_code);
				Console.WriteLine("锁定印章-网关异常信息为：" + sae.return_message);
			}
			catch (SignServerException sse)
			{
				// 捕获网关校验数据
				Console.WriteLine("锁定印章-业务异常状态码为：" + sse.result_code);
				Console.WriteLine("锁定印章-业务异常信息为：" + sse.result_message);
			}
		}
		/// <summary>
		/// 解锁印章
		/// </summary>
		public void sealUnlock()
		{
			try
			{
				SealUnlockResponse sealRemoveResponse = client.Seal.sealUnlock(new SealUnlockRequest("babeef37549d22cbb50ce5436cdb3037"));
				Console.WriteLine("解锁印章-响应数据:" + JSONUtil.getJsonStringFromObject(sealRemoveResponse));

			}
			catch (SignApplicationException sae)
			{
				// 捕获网关校验数据
				Console.WriteLine("解锁印章-网关异常状态码为：" + sae.return_code);
				Console.WriteLine("解锁印章-网关异常信息为：" + sae.return_message);
			}
			catch (SignServerException sse)
			{
				// 捕获网关校验数据
				Console.WriteLine("解锁印章-业务异常状态码为：" + sse.result_code);
				Console.WriteLine("解锁印章-业务异常信息为：" + sse.result_message);
			}
		}
	}
}
