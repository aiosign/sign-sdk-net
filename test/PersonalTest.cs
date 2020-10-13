using System;
using sign_sdk_net.client;
using sign_sdk_net.constant;
using sign_sdk_net.entity.request;
using sign_sdk_net.entity.request.personal;
using sign_sdk_net.entity.response;
using sign_sdk_net.exception;

namespace sign_sdk_net.test
{
    /// <summary>
    /// 个人用户测试
    /// </summary>
    class PersonalTest : BaseTest
	{
		private SignClient client;

		public PersonalTest(SignClient signClient)
		{
			this.testName = "个人用户";
			this.client = signClient;
		}

		/// <summary>
		/// 个人用户注册并申请证书
		/// </summary>
		public void personalCertRegister()
		{
			PersonalRegisterRequest personalRegisterRequest = new PersonalRegisterRequest();
			personalRegisterRequest.area_code = "370000";
			personalRegisterRequest.description = "描述信息：该用户位示例用户";
			personalRegisterRequest.id_number = "370011123456712121";
			personalRegisterRequest.id_type = IdType.IDCARD;
			personalRegisterRequest.mail = "123456@sdgd.com";
			personalRegisterRequest.phone = "13711111121";
			personalRegisterRequest.user_name = "测试个人用户";

			try
			{
				PersonalRegisterResponse response = client.Personal.personalCertRegister(personalRegisterRequest);
				Console.WriteLine("个人用户注册并申请证书-响应数据：" + JSONUtil.getJsonStringFromObject(response));
			}
			catch (SignApplicationException sae)
			{
				// 捕获网关校验数据
				Console.WriteLine("个人用户注册并申请证书-网关异常状态码为：" + sae.return_code);
				Console.WriteLine("个人用户注册并申请证书-网关异常信息为：" + sae.return_message);
			}
			catch (SignServerException sse)
			{
				// 捕获网关校验数据
				Console.WriteLine("个人用户注册并申请证书-业务异常状态码为：" + sse.result_code);
				Console.WriteLine("个人用户注册并申请证书-业务异常信息为：" + sse.result_message);
			}
		}
		/// <summary>
		/// 查询个人用户信息
		/// </summary>
		public void personalUserinfo()
		{
			try
			{

				PersonalUserinfoResponse personalUserinfoResponse = client.Personal.personalUserinfo(new PersonalUserinfoRequest("00765245060136194048"));
				Console.WriteLine("查询个人用户信息-响应数据:" + JSONUtil.getJsonStringFromObject(personalUserinfoResponse));
			}
			catch (SignApplicationException sae)
			{
				// 捕获网关校验数据
				Console.WriteLine("查询个人用户信息-网关异常状态码为：" + sae.return_code);
				Console.WriteLine("查询个人用户信息-网关异常信息为：" + sae.return_message);
			}
			catch (SignServerException sse)
			{
				// 捕获网关校验数据
				Console.WriteLine("查询个人用户信息-业务异常状态码为：" + sse.result_code);
				Console.WriteLine("查询个人用户信息-业务异常信息为：" + sse.result_message);
			}
		}
		/// <summary>
		/// 个人用户注册
		/// </summary>
		public void personalRegister()
		{
			PersonalRegisterRequest personalRegisterRequest = new PersonalRegisterRequest();
			personalRegisterRequest.area_code = "370000";
			personalRegisterRequest.description = "描述信息：该用户位示例用户";
			personalRegisterRequest.id_number = "370011123456712122";
			personalRegisterRequest.id_type = IdType.IDCARD;
			personalRegisterRequest.mail = "123456@sdgd.com";
			personalRegisterRequest.phone = "13711111121";
			personalRegisterRequest.user_name = "测试个人用户";

			try
			{
				PersonalRegisterResponse response = client.Personal.personalRegister(personalRegisterRequest);
				Console.WriteLine("个人用户注册-响应数据：" + JSONUtil.getJsonStringFromObject(response));
			}
			catch (SignApplicationException sae)
			{
				// 捕获网关校验数据
				Console.WriteLine("个人用户注册-网关异常状态码为：" + sae.return_code);
				Console.WriteLine("个人用户注册-网关异常信息为：" + sae.return_message);
			}
			catch (SignServerException sse)
			{
				// 捕获网关校验数据
				Console.WriteLine("个人用户注册-业务异常状态码为：" + sse.result_code);
				Console.WriteLine("个人用户注册-业务异常信息为：" + sse.result_message);
			}
		}

		/// <summary>
		/// 锁定个人用户
		/// </summary>
		public void personalLock()
		{
			try
			{
				PersonalLockResponse personalLockResponse = client.Personal.personalLock(new PersonalLockRequest("00765245060136194048"));
				Console.WriteLine("锁定个人用户-响应数据:" + JSONUtil.getJsonStringFromObject(personalLockResponse));
			}
			catch (SignApplicationException sae)
			{
				// 捕获网关校验数据
				Console.WriteLine("锁定个人用户-网关异常状态码为：" + sae.return_code);
				Console.WriteLine("锁定个人用户-网关异常信息为：" + sae.return_message);
			}
			catch (SignServerException sse)
			{
				// 捕获网关校验数据
				Console.WriteLine("锁定个人用户-业务异常状态码为：" + sse.result_code);
				Console.WriteLine("锁定个人用户-业务异常信息为：" + sse.result_message);
			}
		}

		/// <summary>
		/// 解锁个人用户
		/// </summary>
		public void personalUnlock()
		{
			try
			{
				PersonalUnlockResponse personalUnlockResponse = client.Personal.personalUnlock(new PersonalUnlockRequest("00765245060136194048"));
				Console.WriteLine("解锁个人用户-响应数据:" + JSONUtil.getJsonStringFromObject(personalUnlockResponse));
			}
			catch (SignApplicationException sae)
			{
				// 捕获网关校验数据
				Console.WriteLine("解锁个人用户-网关异常状态码为：" + sae.return_code);
				Console.WriteLine("解锁个人用户-网关异常信息为：" + sae.return_message);
			}
			catch (SignServerException sse)
			{
				// 捕获网关校验数据
				Console.WriteLine("解锁个人用户-业务异常状态码为：" + sse.result_code);
				Console.WriteLine("解锁个人用户-业务异常信息为：" + sse.result_message);
			}
		}
    }
}
