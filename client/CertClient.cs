using sign_sdk_net.constant;
using sign_sdk_net.entity;
using sign_sdk_net.entity.request.bases;
using sign_sdk_net.entity.request.cert;
using sign_sdk_net.entity.response.cert;

namespace sign_sdk_net.client
{
	/// <summary>
	/// 证书服务 客户端
	/// </summary>
	class CertClient : BaseClient
	{
		public CertClient(string baseUrl, TokenDataSource tokenDataSource, string appId, string appSecret) : base(baseUrl, tokenDataSource, appId, appSecret)
		{
		}

		/// <summary>
		/// 证书申请
		/// </summary>
		/// <param name="certApplyRequest"></param>
		/// <returns></returns>
		public CertApplyResponse certApply(CertApplyRequest certApplyRequest)
		{
			SignRequest signRequest = new SignRequest(certApplyRequest);
			signRequest.apiUrl = ApiUrlConstant.Cert.Apply;
			CertApplyResponse response = base.Send<CertApplyResponse>(signRequest);
			return response;
		}

		/// <summary>
		/// 证书续期
		/// </summary>
		/// <param name="certRenewalRequest"></param>
		/// <returns></returns>
		public CertRenewalResponse certRenewal(CertRenewalRequest certRenewalRequest)
		{
			SignRequest signRequest = new SignRequest(certRenewalRequest);
			signRequest.apiUrl = ApiUrlConstant.Cert.Renewal;
			CertRenewalResponse response = base.Send<CertRenewalResponse>(signRequest);
			return response;
		}

		/// <summary>
		/// 证书信息
		/// </summary>
		/// <param name="certCertinfoRequest"></param>
		/// <returns></returns>
		public CertCertinfoResponse certinfo(CertCertinfoRequest certCertinfoRequest)
		{
			SignRequest signRequest = new SignRequest(certCertinfoRequest);
			signRequest.apiUrl = ApiUrlConstant.Cert.Certinfo;
			CertCertinfoResponse response = base.Send<CertCertinfoResponse>(signRequest);
			return response;
		}

	}
}
