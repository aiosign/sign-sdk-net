using System;
using System.Collections.Generic;
using sign_sdk_net.client;
using sign_sdk_net.entity.request;
using sign_sdk_net.entity.request.auth;
using sign_sdk_net.entity.response;
using sign_sdk_net.entity.response.auth;
using sign_sdk_net.exception;

namespace sign_sdk_net.test
{
	/// <summary>
	/// 认证测试
	/// </summary>
	class AuthTest : BaseTest
	{
		private SignClient client;
		public AuthTest(SignClient signClient)
		{
			this.testName = "认证";
			this.client = signClient;
		}

		/// <summary>
		/// 加密请求下三网认证
		/// </summary>
		public void encryQuery() {
			AuthEncryRequest request = new AuthEncryRequest();
			request.id_card = "370832199005060611X";
			request.name = "李牟";
			request.phone = "15053157700";

			try
			{
				AuthEncryResponse response = client.Auth.encryQuery(request);
				Console.WriteLine("三网认证-响应数据：" + JSONUtil.getJsonStringFromObject(response));
			}
			catch (SignApplicationException sae)
			{
				// 捕获网关校验数据
				Console.WriteLine("三网认证-网关异常状态码为：" + sae.return_code);
				Console.WriteLine("三网认证-网关异常信息为：" + sae.return_message);
			}
			catch (SignServerException sse)
			{
				// 捕获网关校验数据
				Console.WriteLine("三网认证-业务异常状态码为：" + sse.result_code);
				Console.WriteLine("三网认证-业务异常信息为：" + sse.result_message);
			}
		}
		/// <summary>
		/// 加密进行银行卡四要素认证
		/// </summary>
		public void blankFourEnCeryQuery()
		{
			BlankCardCheckRequest request = new BlankCardCheckRequest();
			request.idcard = "370832199005060611X";
			request.bankcard = "6217856000030139447";
			request.mobile = "15053153700";
			request.realname = "李司網";

			try
			{
				BankCardEncryResponse response = client.Auth.blankFourEnCeryQuery(request);
				Console.WriteLine("银行卡四要素认证-响应数据:" + JSONUtil.getJsonStringFromObject(response));
			}
			catch (SignApplicationException sae)
			{
				// 捕获网关校验数据
				Console.WriteLine("银行卡四要素认证-网关异常状态码为：" + sae.return_code);
				Console.WriteLine("银行卡四要素认证-网关异常信息为：" + sae.return_message);
			}
			catch (SignServerException sse)
			{
				// 捕获网关校验数据
				Console.WriteLine("银行卡四要素认证-业务异常状态码为：" + sse.result_code);
				Console.WriteLine("银行卡四要素认证-业务异常信息为：" + sse.result_message);
			}
		}
		/// <summary>
		/// OCR银行卡
		/// </summary>
		public void ocrBankCard()
		{
			OCRBankCardRequest request = new OCRBankCardRequest();
			request.image = "Base64"; //银行卡图片Base64

			try
			{
				OCRBankCardResponse response = client.Auth.ocrBankCard(request);
				Console.WriteLine("OCR银行卡-响应数据:" + JSONUtil.getJsonStringFromObject(response));
			}
			catch (SignApplicationException sae)
			{
				// 捕获网关校验数据
				Console.WriteLine("OCR银行卡-网关异常状态码为：" + sae.return_code);
				Console.WriteLine("OCR银行卡-网关异常信息为：" + sae.return_message);
			}
			catch (SignServerException sse)
			{
				// 捕获网关校验数据
				Console.WriteLine("OCR银行卡-业务异常状态码为：" + sse.result_code);
				Console.WriteLine("OCR银行卡-业务异常信息为：" + sse.result_message);
			}

		}
		/// <summary>
		/// 获取OCR可用识别类型
		/// </summary>
		public void ocrCardType()
		{
			try
			{
				Dictionary<string, object> response = client.Auth.ocrCardType();
				Console.WriteLine("OCR可用识别类型-响应数据:" + JSONUtil.getJsonStringFromObject(response));
			}
			catch (SignApplicationException sae)
			{
				// 捕获网关校验数据
				Console.WriteLine("OCR可用识别类型-网关异常状态码为：" + sae.return_code);
				Console.WriteLine("OCR可用识别类型-网关异常信息为：" + sae.return_message);
			}
			catch (SignServerException sse)
			{
				// 捕获网关校验数据
				Console.WriteLine("OCR可用识别类型-业务异常状态码为：" + sse.result_code);
				Console.WriteLine("OCR可用识别类型-业务异常信息为：" + sse.result_message);
			}
		}
		/// <summary>
		/// 证件识别
		/// </summary>
		public void ocrObject()
		{
			OCRObjectRequest request = new OCRObjectRequest();
			request.card_type = "17";//OCR可用识别类型
			request.file_base64 = "Base64";//识别卡图片Base64
			request.file_name = "我的银行卡.png";//文件名称，带后缀

			try
			{
				OCRObjectResponse response = client.Auth.ocrObject(request);
				Console.WriteLine("证件识别-响应数据:" + JSONUtil.getJsonStringFromObject(response));
			}
			catch (SignApplicationException sae)
			{
				// 捕获网关校验数据
				Console.WriteLine("证件识别-网关异常状态码为：" + sae.return_code);
				Console.WriteLine("证件识别-网关异常信息为：" + sae.return_message);
			}
			catch (SignServerException sse)
			{
				// 捕获网关校验数据
				Console.WriteLine("证件识别-业务异常状态码为：" + sse.result_code);
				Console.WriteLine("证件识别-业务异常信息为：" + sse.result_message);
			}
		}
		/// <summary>
		/// 企业三要素认证
		/// </summary>
		public void enterpriseThreeQuery()
		{
			EnterpriseQueryRequest request = new EnterpriseQueryRequest();
			request.keyword = "92370785MA3NTXJD9J";//注册号/统一社会信用代码(注册号支持15位，统一社会信用代码支持18位)
			request.name = "测试科技公司";//企业名称
			request.oper_name = "李牟";//企业法人

			try
			{
				EnterpriseQueryResponse response = client.Auth.enterpriseThreeQuery(request);
				Console.WriteLine("证件识别-响应数据:" + JSONUtil.getJsonStringFromObject(response));
			}
			catch (SignApplicationException sae)
			{
				// 捕获网关校验数据
				Console.WriteLine("证件识别-网关异常状态码为：" + sae.return_code);
				Console.WriteLine("证件识别-网关异常信息为：" + sae.return_message);
			}
			catch (SignServerException sse)
			{
				// 捕获网关校验数据
				Console.WriteLine("证件识别-业务异常状态码为：" + sse.result_code);
				Console.WriteLine("证件识别-业务异常信息为：" + sse.result_message);
			}
		}
		/// <summary>
		/// 支付宝认证-开始认证
		/// </summary>
		public void aliPayCertify()
		{
			AliPayCertifyRequest request = new AliPayCertifyRequest();
			request.name = "李牟";
			request.certify_type = "FACE";//认证模式
			request.id_card_num = "370782199511234771";//身份证号码

			try
			{
				AliPayCertifyResponse response = client.Auth.aliPayCertify(request);
				Console.WriteLine("支付宝认证-开始认证-响应数据:" + JSONUtil.getJsonStringFromObject(response));
			}
			catch (SignApplicationException sae)
			{
				// 捕获网关校验数据
				Console.WriteLine("支付宝认证-开始认证-网关异常状态码为：" + sae.return_code);
				Console.WriteLine("支付宝认证-开始认证-网关异常信息为：" + sae.return_message);
			}
			catch (SignServerException sse)
			{
				// 捕获网关校验数据
				Console.WriteLine("支付宝认证-开始认证-业务异常状态码为：" + sse.result_code);
				Console.WriteLine("支付宝认证-开始认证-业务异常信息为：" + sse.result_message);
			}
		}
		/// <summary>
		/// 支付宝认证-认证查询
		/// </summary>
		public void aliPayCertifyQuery()
		{
			AliPayQueryRequest request = new AliPayQueryRequest();
			request.certifty_id = "31ba84721a5f13d8c40fc33b9f86c7ce";

			try
			{
				AliPayQueryResponse response = client.Auth.aliPayCertifyQuery(request);
				Console.WriteLine("支付宝认证-认证查询-响应数据:" + JSONUtil.getJsonStringFromObject(response));
			}
			catch (SignApplicationException sae)
			{
				// 捕获网关校验数据
				Console.WriteLine("支付宝认证-认证查询-网关异常状态码为：" + sae.return_code);
				Console.WriteLine("支付宝认证-认证查询-网关异常信息为：" + sae.return_message);
			}
			catch (SignServerException sse)
			{
				// 捕获网关校验数据
				Console.WriteLine("支付宝认证-认证查询-业务异常状态码为：" + sse.result_code);
				Console.WriteLine("支付宝认证-认证查询-业务异常信息为：" + sse.result_message);
			}
		}
		/// <summary>
		/// 企业四要素认证
		/// </summary>
		public void entFour()
		{
			SJBEntFourRequest request = new SJBEntFourRequest();
			request.entname = "某科技有限公司";//企业名称
			request.entmark = "92370785MA3NTXJD9J";//企业标识（企业社会信用代码
			request.name = "李牟";//法人姓名
			request.idcard = "370782199511234771";//法人身份证号码

			try
			{
				SJBEntFourResponse response = client.Auth.entFour(request);
				Console.WriteLine("企业四要素认证-认证查询-响应数据:" + JSONUtil.getJsonStringFromObject(response));
			}
			catch (SignApplicationException sae)
			{
				// 捕获网关校验数据
				Console.WriteLine("企业四要素认证-认证查询-网关异常状态码为：" + sae.return_code);
				Console.WriteLine("企业四要素认证-认证查询-网关异常信息为：" + sae.return_message);
			}
			catch (SignServerException sse)
			{
				// 捕获网关校验数据
				Console.WriteLine("企业四要素认证-认证查询-业务异常状态码为：" + sse.result_code);
				Console.WriteLine("企业四要素认证-认证查询-业务异常信息为：" + sse.result_message);
			}
		}
		/// <summary>
		/// 企业打款
		/// </summary>
		public void enterprisePay()
		{
			EnterprisePayRequest request = new EnterprisePayRequest();
			request.key_type = "1"; //企业代码类型；1：社会统一信用代码；2：工商注册代码
			request.key = "92370785MA3NTXJD9J";
			request.name = "某科技有限公司";//企业名称
			request.usr_name = "李牟";//法人名称
			request.account_no = "6221501111111113900";//企业银行账户
			request.account_bank = "中国工商银行";//企业开户行
			request.account_province = "北京市"; //企业开户行所在省份
			request.account_city = "北京市";//企业开户行所在城市

			try
			{
				EnterprisePayResponse response = client.Auth.enterprisePay(request);
				Console.WriteLine("企业打款-响应数据:" + JSONUtil.getJsonStringFromObject(response));
			}
			catch (SignApplicationException sae)
			{
				// 捕获网关校验数据
				Console.WriteLine("企业打款-网关异常状态码为：" + sae.return_code);
				Console.WriteLine("企业打款-网关异常信息为：" + sae.return_message);
			}
			catch (SignServerException sse)
			{
				// 捕获网关校验数据
				Console.WriteLine("企业打款-业务异常状态码为：" + sse.result_code);
				Console.WriteLine("企业打款-业务异常信息为：" + sse.result_message);
			}
		}
		/// <summary>
		/// 企业打款查询
		/// </summary>
		public void enterprisePayQuery()
		{
			EnterprisePayQueryRequest request = new EnterprisePayQueryRequest();
			request.order_id = "067442e49f8c8b40ffd9d050e55ec3e0";//订单Id
			request.account_no = "6221501111111113900";//企业银行账户

			try
			{
				EnterprisePayQueryResponse response = client.Auth.enterprisePayQuery(request);
				Console.WriteLine("企业打款查询-响应数据:" + JSONUtil.getJsonStringFromObject(response));
			}
			catch (SignApplicationException sae)
			{
				// 捕获网关校验数据
				Console.WriteLine("企业打款查询-网关异常状态码为：" + sae.return_code);
				Console.WriteLine("企业打款查询-网关异常信息为：" + sae.return_message);
			}
			catch (SignServerException sse)
			{
				// 捕获网关校验数据
				Console.WriteLine("企业打款查询-业务异常状态码为：" + sse.result_code);
				Console.WriteLine("企业打款查询-业务异常信息为：" + sse.result_message);
			}
		}
		/// <summary>
		/// 企业打款验证
		/// </summary>
		public void enterprisePayValid()
		{
			EnterprisePayValidRequest request = new EnterprisePayValidRequest();
			request.order_id = "067442e49f8c8b40ffd9d050e55ec3e0";//订单Id
			request.account_no = "6221501111111113900";//企业银行账户
			request.amount = 1;//金额（分）

			try
			{
				EnterprisePayValidResponse response = client.Auth.enterprisePayValid(request);
				Console.WriteLine("企业打款验证-响应数据:" + JSONUtil.getJsonStringFromObject(response));
			}
			catch (SignApplicationException sae)
			{
				// 捕获网关校验数据
				Console.WriteLine("企业打款验证-网关异常状态码为：" + sae.return_code);
				Console.WriteLine("企业打款验证-网关异常信息为：" + sae.return_message);
			}
			catch (SignServerException sse)
			{
				// 捕获网关校验数据
				Console.WriteLine("企业打款验证-业务异常状态码为：" + sse.result_code);
				Console.WriteLine("企业打款验证-业务异常信息为：" + sse.result_message);
			}
		}
		/// <summary>
		/// 获取百度语音验证码
		/// </summary>
		public void baiduSessionCode()
		{
			try
			{
				BaiduSessionCodeResponse response = client.Auth.baiduSessionCode();
				Console.WriteLine("获取百度语音验证码-响应数据:" + JSONUtil.getJsonStringFromObject(response));
			}
			catch (SignApplicationException sae)
			{
				// 捕获网关校验数据
				Console.WriteLine("获取百度语音验证码-网关异常状态码为：" + sae.return_code);
				Console.WriteLine("获取百度语音验证码-网关异常信息为：" + sae.return_message);
			}
			catch (SignServerException sse)
			{
				// 捕获网关校验数据
				Console.WriteLine("获取百度语音验证码-业务异常状态码为：" + sse.result_code);
				Console.WriteLine("获取百度语音验证码-业务异常信息为：" + sse.result_message);
			}
		}
		/// <summary>
		///  百度语音验证
		/// </summary>
		public void baiduVideoVerify()
		{
			BaiDuAiFaceVideoVerifyRequest request = new BaiDuAiFaceVideoVerifyRequest();
			request.session_id = "01562e5349b0a4044a23784dc707d46f";

			try
			{
				FileUploadRequest fileUploadRequest = new FileUploadRequest("D://video//我的视频.mp4", "我的视频.mp4");
				request.video_file = fileUploadRequest.fileData;//建议视频大小控制在10M/1min以内

				BaiDuAiFaceVideoVerifyResponse response = client.Auth.baiduVideoVerify(request);
				Console.WriteLine("百度语音验证-响应数据:" + JSONUtil.getJsonStringFromObject(response));
			}
			catch (SignApplicationException sae)
			{
				// 捕获网关校验数据
				Console.WriteLine("百度语音验证-网关异常状态码为：" + sae.return_code);
				Console.WriteLine("百度语音验证-网关异常信息为：" + sae.return_message);
			}
			catch (SignServerException sse)
			{
				// 捕获网关校验数据
				Console.WriteLine("百度语音验证-业务异常状态码为：" + sse.result_code);
				Console.WriteLine("百度语音验证-业务异常信息为：" + sse.result_message);
			}
			catch (Exception e)
			{
				Console.WriteLine("百度语音验证-异常为：" + e.Message);
			}
		}
		/// <summary>
		/// 百度身份验证
		/// </summary>
		public void baiduCertifyVerify()
		{
			BaiDuAiFaceCertifyVerifyRequest request = new BaiDuAiFaceCertifyVerifyRequest();
			request.name = "李牟";
			request.image = "Base64";//图片Base64
			request.id_card_number = "370782199511234771";//证件号码

			try
			{
				BaiDuAiFaceCertifyVerifyResponse response = client.Auth.baiduCertifyVerify(request);
				Console.WriteLine("百度语音验证-响应数据:" + JSONUtil.getJsonStringFromObject(response));
			}
			catch (SignApplicationException sae)
			{
				// 捕获网关校验数据
				Console.WriteLine("百度语音验证-网关异常状态码为：" + sae.return_code);
				Console.WriteLine("百度语音验证-网关异常信息为：" + sae.return_message);
			}
			catch (SignServerException sse)
			{
				// 捕获网关校验数据
				Console.WriteLine("百度语音验证-业务异常状态码为：" + sse.result_code);
				Console.WriteLine("百度语音验证-业务异常信息为：" + sse.result_message);
			}
		}
	}
}
