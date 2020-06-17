using sign_sdk_net.constant;
using sign_sdk_net.entity;
using sign_sdk_net.entity.request.bases;
using sign_sdk_net.entity.request.cert;
using sign_sdk_net.entity.request.company;
using sign_sdk_net.entity.response.cert;
using sign_sdk_net.entity.response.company;
using System;
using System.Collections.Generic;
using System.Text;

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

		public CertCertinfoResponse certinfo(CertCertinfoRequest certCertinfoRequest)
		{
			SignRequest signRequest = new SignRequest(certCertinfoRequest);
			signRequest.apiUrl = ApiUrlConstant.Cert.Certinfo;
			CertCertinfoResponse response = base.Send<CertCertinfoResponse>(signRequest);
			return response;
		}

	}
}
