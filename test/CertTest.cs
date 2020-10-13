using System;
using sign_sdk_net.client;
using sign_sdk_net.entity.request.cert;
using sign_sdk_net.entity.response.cert;
using sign_sdk_net.exception;

namespace sign_sdk_net.test
{
	/// <summary>
	/// 证书测试
	/// </summary>
	class CertTest : BaseTest
	{
		private SignClient client;

		public CertTest(SignClient signClient)
		{
			this.testName = "证书";
			this.client = signClient;
		}

		/// <summary>
		/// 证书申请
		/// </summary>
		public void certApply()
		{
			try
			{
				CertApplyResponse response = client.Cert.certApply(new CertApplyRequest("00765245060136194048"));
				Console.WriteLine("证书申请-响应数据：" + JSONUtil.getJsonStringFromObject(response));
			}
			catch (SignApplicationException sae)
			{
				// 捕获网关校验数据
				Console.WriteLine("证书申请-网关异常状态码为: " + sae.return_code);
				Console.WriteLine("证书申请-网关异常信息为: " + sae.return_message);
			}
			catch (SignServerException sse)
			{
				// 捕获网关校验数据
				Console.WriteLine("证书申请-业务异常状态码为：" + sse.result_code);
				Console.WriteLine("证书申请-业务异常信息为：" + sse.result_message);
			}
		}
		/// <summary>
		/// 证书续期
		/// </summary>
		public void certRenewal() 
		{
			try
			{
				CertRenewalResponse response = client.Cert.certRenewal(new CertRenewalRequest("00765245060136194048"));
				Console.WriteLine("证书续期-响应数据：" + JSONUtil.getJsonStringFromObject(response));
			}
			catch (SignApplicationException sae)
			{
				// 捕获网关校验数据
				Console.WriteLine("证书续期-网关异常状态码为: " + sae.return_code);
				Console.WriteLine("证书续期-网关异常信息为: " + sae.return_message);
			}
			catch (SignServerException sse)
			{
				// 捕获网关校验数据
				Console.WriteLine("证书续期-业务异常状态码为：" + sse.result_code);
				Console.WriteLine("证书续期-业务异常信息为：" + sse.result_message);
			}
		}
		/// <summary>
		/// 证书查询
		/// </summary>
		public void certinfo() 
		{
			try
			{
				CertCertinfoResponse response = client.Cert.certinfo(new CertCertinfoRequest("45010018443a4d58a6c2c0724bb306c7"));
				Console.WriteLine("证书查询-响应数据：" + JSONUtil.getJsonStringFromObject(response));
			}
			catch (SignApplicationException sae)
			{
				// 捕获网关校验数据
				Console.WriteLine("证书查询-网关异常状态码为: " + sae.return_code);
				Console.WriteLine("证书查询-网关异常信息为: " + sae.return_message);
			}
			catch (SignServerException sse)
			{
				// 捕获网关校验数据
				Console.WriteLine("证书查询-业务异常状态码为：" + sse.result_code);
				Console.WriteLine("证书查询-业务异常信息为：" + sse.result_message);
			}
		}
	}
}
