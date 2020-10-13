using System;
using System.IO;
using sign_sdk_net.client;
using sign_sdk_net.constant;
using sign_sdk_net.entity.request;
using sign_sdk_net.entity.request.template;
using sign_sdk_net.entity.response.template;
using sign_sdk_net.exception;
using static sign_sdk_net.entity.request.template.TemplateFillRequest;

namespace sign_sdk_net.test
{
	/// <summary>
    /// 模板测试
    /// </summary>
	class TemplateTest : BaseTest
	{
		private SignClient client;

		public TemplateTest(SignClient signClient)
		{
			this.testName = "模板";
			this.client = signClient;
		}
		/// <summary>
		/// 添加模板以及文件
		/// </summary>
		public void addTemplateAndFile()
		{
			// 创建模板以及文件 begin
			TemplateFileAddRequest templateFileAddRequest = new TemplateFileAddRequest();
			//模板文件上传
			FileUploadRequest fileUploadRequest = new FileUploadRequest("D://telmplate//劳动合同模板.pdf", "劳动合同模板.pdf", FileType.template, "00765245060136194048");
			templateFileAddRequest.fileUploadRequest = fileUploadRequest;
			// 模板请求数据 begin
			TemplateAddRequest templateAddRequest = new TemplateAddRequest();
			templateAddRequest.name = "我的模板";
			templateFileAddRequest.templateAddRequest = templateAddRequest;

			try
			{
				TemplateAddResponse response = client.Template.addTemplateAndFile(templateFileAddRequest);
				Console.WriteLine("添加模板以及文件-响应数据：" + JSONUtil.getJsonStringFromObject(response));
			}
			catch (SignApplicationException sae)
			{
				// 捕获网关校验数据
				Console.WriteLine("添加模板以及文件-网关异常状态码为：" + sae.return_code);
				Console.WriteLine("添加模板以及文件-网关异常信息为：" + sae.return_message);
			}
			catch (SignServerException sse)
			{
				// 捕获网关校验数据
				Console.WriteLine("添加模板以及文件-业务异常状态码为：" + sse.result_code);
				Console.WriteLine("添加模板以及文件-业务异常信息为：" + sse.result_message);
			}
			catch (Exception e)
			{
				Console.WriteLine("添加模板以及文件-异常为：" + e.Message);
			}
		}
		/// <summary>
		/// 添加模板
		/// </summary>
		public void add()
		{
			TemplateAddRequest templateAddRequest = new TemplateAddRequest();
			templateAddRequest.file_id = "b5b1bcc77e74a5dc54a32215c25ea22d";
			templateAddRequest.name = "劳动合同模板";
			try
			{
				
				TemplateAddResponse response = client.Template.add(templateAddRequest);
				Console.WriteLine("添加模板-响应数据:" + JSONUtil.getJsonStringFromObject(response));
			}
			catch (SignApplicationException sae)
			{
				// 捕获网关校验数据
				Console.WriteLine("添加模板-网关异常状态码为：" + sae.return_code);
				Console.WriteLine("添加模板-网关异常信息为：" + sae.return_message);
			}
			catch (SignServerException sse)
			{
				// 捕获网关校验数据
				Console.WriteLine("添加模板-业务异常状态码为：" + sse.result_code);
				Console.WriteLine("添加模板-业务异常信息为：" + sse.result_message);
			}
		}
		/// <summary>
		/// 查询模板
		/// </summary>
		public void query()
		{
			try
			{
				TemplateQueryResponse response = client.Template.query(new TemplateQueryRequest("983e7c49532738a14e1d1aeb02d65775"));
				Console.WriteLine("查询模板-响应数据:" + JSONUtil.getJsonStringFromObject(response));
			}
			catch (SignApplicationException sae)
			{
				// 捕获网关校验数据
				Console.WriteLine("查询模板-网关异常状态码为：" + sae.return_code);
				Console.WriteLine("查询模板-网关异常信息为：" + sae.return_message);
			}
			catch (SignServerException sse)
			{
				// 捕获网关校验数据
				Console.WriteLine("查询模板-业务异常状态码为：" + sse.result_code);
				Console.WriteLine("查询模板-业务异常信息为：" + sse.result_message);
			}
		}
		/// <summary>
		/// 删除模板
		/// </summary>
		public void remove()
		{
			try
			{
				TemplateDelResponse templateDelResponse = client.Template.remove(new TemplateDelRequest("05571ec8d8681499783db4ff6609b73b"));
				Console.WriteLine("删除模板-响应数据:" + JSONUtil.getJsonStringFromObject(templateDelResponse));

			}
			catch (SignApplicationException sae)
			{
				// 捕获网关校验数据
				Console.WriteLine("删除模板-网关异常状态码为：" + sae.return_code);
				Console.WriteLine("删除模板-网关异常信息为：" + sae.return_message);
			}
			catch (SignServerException sse)
			{
				// 捕获网关校验数据
				Console.WriteLine("删除模板-业务异常状态码为：" + sse.result_code);
				Console.WriteLine("删除模板-业务异常信息为：" + sse.result_message);
			}
		}
		/// <summary>
		/// 锁定模板
		/// </summary>
		public void templateLock()
		{
			try
			{
				TemplateLockResponse response = client.Template.templateLock(new TemplateLockRequest("983e7c49532738a14e1d1aeb02d65775"));
				Console.WriteLine("锁定模板-响应数据:" + JSONUtil.getJsonStringFromObject(response));

			}
			catch (SignApplicationException sae)
			{
				// 捕获网关校验数据
				Console.WriteLine("锁定模板-网关异常状态码为：" + sae.return_code);
				Console.WriteLine("锁定模板-网关异常信息为：" + sae.return_message);
			}
			catch (SignServerException sse)
			{
				// 捕获网关校验数据
				Console.WriteLine("锁定模板-业务异常状态码为：" + sse.result_code);
				Console.WriteLine("锁定模板-业务异常信息为：" + sse.result_message);
			}
		}
		/// <summary>
		/// 解锁模板
		/// </summary>
		public void templateUnlock()
		{
			try
			{
				TemplateUnlockResponse response = client.Template.templateUnlock(new TemplateUnlockRequest("983e7c49532738a14e1d1aeb02d65775"));
				Console.WriteLine("解锁模板-响应数据:" + JSONUtil.getJsonStringFromObject(response));

			}
			catch (SignApplicationException sae)
			{
				// 捕获网关校验数据
				Console.WriteLine("解锁模板-网关异常状态码为：" + sae.return_code);
				Console.WriteLine("解锁模板-网关异常信息为：" + sae.return_message);
			}
			catch (SignServerException sse)
			{
				// 捕获网关校验数据
				Console.WriteLine("解锁模板-业务异常状态码为：" + sse.result_code);
				Console.WriteLine("解锁模板-业务异常信息为：" + sse.result_message);
			}
		}
		/// <summary>
		/// 填充模板
		/// </summary>
		public void templateFill()
		{
			TemplateFillRequest templateFillRequest = new TemplateFillRequest();
			templateFillRequest.template_id = "983e7c49532738a14e1d1aeb02d65775";
			templateFillRequest.user_id = "00765245060136194048";
			templateFillRequest.name = "测试合同";

			SimpleFormField simpleFormField = new SimpleFormField();
			simpleFormField.key = "name";
			simpleFormField.value = "我的印章测试";

			templateFillRequest.addSimpleFormField(simpleFormField);
			try
			{
				TemplateFillResponse response = client.Template.templateFill(templateFillRequest);
				Console.WriteLine("填充模板-响应数据:" + JSONUtil.getJsonStringFromObject(response));
			}
			catch (SignApplicationException sae)
			{
				// 捕获网关校验数据
				Console.WriteLine("填充模板-网关异常状态码为：" + sae.return_code);
				Console.WriteLine("填充模板-网关异常信息为：" + sae.return_message);
			}
			catch (SignServerException sse)
			{
				// 捕获网关校验数据
				Console.WriteLine("填充模板-业务异常状态码为：" + sse.result_code);
				Console.WriteLine("填充模板-业务异常信息为：" + sse.result_message);
			}
		}
	}
}
