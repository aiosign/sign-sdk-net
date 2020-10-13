using System;
using System.Collections.Generic;
using System.Reflection;
using sign_sdk_net.client;
using sign_sdk_net.constant;
using sign_sdk_net.entity.request.sms;
using sign_sdk_net.entity.response.sms;
using sign_sdk_net.exception;

namespace sign_sdk_net.test
{
	/// <summary>
	/// 短信测试
	/// </summary>
	class SmsTest : BaseTest
	{
		private SignClient client;

		public SmsTest(SignClient signClient)
		{
			this.testName = "短信";
			this.client = signClient;
		}

		/// <summary>
		/// 单次短信
		/// </summary>
		public void smsSingle()
		{
			SmsSingleRequest request = new SmsSingleRequest();
			request.contract_name = "测试合同";
			request.phone = "1505315800";
			request.user_name = "测试人";
			request.sms_type = SmsType.LOADING_SIGN;

			try
			{
                SmsSingleResponse response = client.Sms.smsSingle(request);
			    Console.WriteLine("单次短信-响应数据：" + JSONUtil.getJsonStringFromObject(response));
			}
			catch (SignApplicationException sae)
			{
				// 捕获网关校验数据
				Console.WriteLine("单次短信-网关异常状态码为：" + sae.return_code);
				Console.WriteLine("单次短信-网关异常信息为：" + sae.return_message);
			}
			catch (SignServerException sse)
			{
				// 捕获网关校验数据
				Console.WriteLine("单次短信-业务异常状态码为：" + sse.result_code);
				Console.WriteLine("单次短信-业务异常信息为：" + sse.result_message);
			}
		}

		/// <summary>
		/// 批量短信通知
		/// </summary>
		public void smsBatch()
		{
			SmsBatchRequest smsBatchRequest = new SmsBatchRequest();
			smsBatchRequest.sms_type = SmsType.LOADING_SIGN;
			Params @params = new Params();
			@params.contract_name = "测试合同";
			@params.phone = "1505315800";
			@params.user_name = "测试人";
			smsBatchRequest.addParams(@params);

			try
			{
				List<SmsBatchResponse> response = client.Sms.smsBatch(smsBatchRequest);
				Console.WriteLine("批量短信通知-响应数据:" + JSONUtil.getJsonStringFromObject(response));
			}
			catch (SignApplicationException sae)
			{
				// 捕获网关校验数据
				Console.WriteLine("批量短信通知-网关异常状态码为：" + sae.return_code);
				Console.WriteLine("批量短信通知-网关异常信息为：" + sae.return_message);
			}
			catch (SignServerException sse)
			{
				// 捕获网关校验数据
				Console.WriteLine("批量短信通知-业务异常状态码为：" + sse.result_code);
				Console.WriteLine("批量短信通知-业务异常信息为：" + sse.result_message);
			}
		}

		/// <summary>
		/// 短信验证码
		/// </summary>
		public void smsAuthCode()
		{
			SmsAuthCodeRequest smsAuthCodeRequest = new SmsAuthCodeRequest();
			PhoneParam phoneParam = new PhoneParam();
			phoneParam.custom_id = "003144df7794744511d88cdcd9244eed";
			phoneParam.phone = "1505315800";
			smsAuthCodeRequest.addPhones(phoneParam);

			try
			{
				SmsAuthCodeResponse response = client.Sms.smsAuthCode(smsAuthCodeRequest);
				Console.WriteLine("短信验证码-响应数据:" + JSONUtil.getJsonStringFromObject(response));
				
			}
			catch (SignApplicationException sae)
			{
				// 捕获网关校验数据
				Console.WriteLine("短信验证码-网关异常状态码为：" + sae.return_code);
				Console.WriteLine("短信验证码-网关异常信息为：" + sae.return_message);
			}
			catch (SignServerException sse)
			{
				// 捕获网关校验数据
				Console.WriteLine("短信验证码-业务异常状态码为：" + sse.result_code);
				Console.WriteLine("短信验证码-业务异常信息为：" + sse.result_message);
			}
		}

		/// <summary>
		/// 验证-短信验证码
		/// </summary>
		public void smsValidAuthCode()
		{
			SmsValidAuthCodeRequest smsValidAuthCodeRequest = new SmsValidAuthCodeRequest();
			smsValidAuthCodeRequest.auth_code = "505693";
			smsValidAuthCodeRequest.uuid = "ffa2090f22a34ef9aa4122256e70b066";
			smsValidAuthCodeRequest.phone = "1505315800";

			try
			{
				SmsValidAuthCodeResponse response = client.Sms.smsValidAuthCode(smsValidAuthCodeRequest);
				Console.WriteLine("验证-短信验证码-响应数据:" + JSONUtil.getJsonStringFromObject(response));
			}
			catch (SignApplicationException sae)
			{
				// 捕获网关校验数据
				Console.WriteLine("验证-短信验证码-网关异常状态码为：" + sae.return_code);
				Console.WriteLine("验证-短信验证码-网关异常信息为：" + sae.return_message);
			}
			catch (SignServerException sse)
			{
				// 捕获网关校验数据
				Console.WriteLine("验证-短信验证码-业务异常状态码为：" + sse.result_code);
				Console.WriteLine("验证-短信验证码-业务异常信息为：" + sse.result_message);
			}
		}
	}
}
