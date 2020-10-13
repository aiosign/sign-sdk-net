using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.constant;
using sign_sdk_net.entity;
using sign_sdk_net.entity.request.auth;
using sign_sdk_net.entity.request.bases;
using sign_sdk_net.entity.response;
using sign_sdk_net.entity.response.auth;

namespace sign_sdk_net.client
{
    /// <summary>
    /// 认证接口
    /// </summary>
    class AuthClient : BaseClient
    {
        public AuthClient(string baseUrl, TokenDataSource tokenDataSource, string appId, string appSecret) : base(baseUrl, tokenDataSource, appId, appSecret)
        {
        }

        /// <summary>
        /// 加密请求下三网认证
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public AuthEncryResponse encryQuery(AuthEncryRequest request)
        {

            SignRequest signRequest = new SignRequest(request);
            signRequest.apiUrl = ApiUrlConstant.Auth.encryQuery;
            AuthEncryResponse response = this.Send<AuthEncryResponse>(signRequest);
            return response;
        }
        /// <summary>
        /// 加密进行银行卡四要素认证
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public BankCardEncryResponse blankFourEnCeryQuery(BlankCardCheckRequest request)
        {
            SignRequest signRequest = new SignRequest(request);
            signRequest.apiUrl = ApiUrlConstant.Auth.blankFourEnCeryQuery;
            BankCardEncryResponse response = this.Send<BankCardEncryResponse>(signRequest);
            return response;
        }
        /// <summary>
        /// OCR银行卡
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public OCRBankCardResponse ocrBankCard(OCRBankCardRequest request) {
            SignRequest signRequest = new SignRequest(request);
            signRequest.apiUrl = ApiUrlConstant.Auth.ocrBankCard;
            OCRBankCardResponse response = this.Send<OCRBankCardResponse>(signRequest);
            return response;
        }
        /// <summary>
        /// 获取OCR可用识别类型
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Dictionary<string, object> ocrCardType()
        {
            SignRequest signRequest = new SignRequest();
            signRequest.apiUrl = ApiUrlConstant.Auth.ocrCardType;
            Dictionary<string, object> response = this.Send<Dictionary<string, object>>(signRequest);
            return response;
        }

        /// <summary>
        /// 证件识别
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public OCRObjectResponse ocrObject(OCRObjectRequest request)
        {
            SignRequest signRequest = new SignRequest(request);
            signRequest.apiUrl = ApiUrlConstant.Auth.ocrObject;
            OCRObjectResponse response = this.Send<OCRObjectResponse>(signRequest);
            return response;
        }
        /// <summary>
        /// 企业三要素认证
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public EnterpriseQueryResponse enterpriseThreeQuery(EnterpriseQueryRequest request)
        {
            SignRequest signRequest = new SignRequest(request);
            signRequest.apiUrl = ApiUrlConstant.Auth.enterpriseThreeQuery;
            EnterpriseQueryResponse response = this.Send<EnterpriseQueryResponse>(signRequest);
            return response;
        }
        /// <summary>
        /// 支付宝认证-开始认证
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public AliPayCertifyResponse aliPayCertify(AliPayCertifyRequest request)
        {
            SignRequest signRequest = new SignRequest(request);
            signRequest.apiUrl = ApiUrlConstant.Auth.alipayCertify;
            AliPayCertifyResponse response = this.Send<AliPayCertifyResponse>(signRequest);
            return response;
        }
        /// <summary>
        /// 支付宝认证-认证查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public AliPayQueryResponse aliPayCertifyQuery(AliPayQueryRequest request)
        {
            SignRequest signRequest = new SignRequest(request);
            signRequest.apiUrl = ApiUrlConstant.Auth.alipayCertifyQuery;
            AliPayQueryResponse response = this.Send<AliPayQueryResponse>(signRequest);
            return response;
        }
        /// <summary>
        /// 企业四要素认证
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public SJBEntFourResponse entFour(SJBEntFourRequest request)
        {
            SignRequest signRequest = new SignRequest(request);
            signRequest.apiUrl = ApiUrlConstant.Auth.entFour;
            SJBEntFourResponse response = this.Send<SJBEntFourResponse>(signRequest);
            return response;
        }
        /// <summary>
        /// 企业打款
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public EnterprisePayResponse enterprisePay(EnterprisePayRequest request)
        {
            SignRequest signRequest = new SignRequest(request);
            signRequest.apiUrl = ApiUrlConstant.Auth.enterprisePay;
            EnterprisePayResponse response = this.Send<EnterprisePayResponse>(signRequest);
            return response;
        }
        /// <summary>
        /// 企业打款查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public EnterprisePayQueryResponse enterprisePayQuery(EnterprisePayQueryRequest request)
        {
            SignRequest signRequest = new SignRequest(request);
            signRequest.apiUrl = ApiUrlConstant.Auth.enterprisePayQuery;
            EnterprisePayQueryResponse response = this.Send<EnterprisePayQueryResponse>(signRequest);
            return response;
        }
        /// <summary>
        /// 企业打款验证
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public EnterprisePayValidResponse enterprisePayValid(EnterprisePayValidRequest request)
        {
            SignRequest signRequest = new SignRequest(request);
            signRequest.apiUrl = ApiUrlConstant.Auth.enterprisePayValid;
            EnterprisePayValidResponse response = this.Send<EnterprisePayValidResponse>(signRequest);
            return response;
        }
        /// <summary>
        /// 获取百度语音验证码
        /// </summary>
        /// <returns></returns>
        public BaiduSessionCodeResponse baiduSessionCode()
        {
            SignRequest signRequest = new SignRequest(new BaseSignRequest());
            signRequest.apiUrl = ApiUrlConstant.Auth.baiduSessionCode;
            BaiduSessionCodeResponse response = this.Send<BaiduSessionCodeResponse>(signRequest);
            return response;
        }
        /// <summary>
        /// 百度语音验证
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public BaiDuAiFaceVideoVerifyResponse baiduVideoVerify(BaiDuAiFaceVideoVerifyRequest request)
        {
            SignRequest signRequest = new SignRequest(request);
            signRequest.apiUrl = ApiUrlConstant.Auth.baiduVideoVerify;
            BaiDuAiFaceVideoVerifyResponse response = this.Send<BaiDuAiFaceVideoVerifyResponse>(signRequest);
            return response;
        }
        /// <summary>
        /// 百度身份验证
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public BaiDuAiFaceCertifyVerifyResponse baiduCertifyVerify(BaiDuAiFaceCertifyVerifyRequest request)
        {
            SignRequest signRequest = new SignRequest(request);
            signRequest.apiUrl = ApiUrlConstant.Auth.baiduCertifyVerify;
            BaiDuAiFaceCertifyVerifyResponse response = this.Send<BaiDuAiFaceCertifyVerifyResponse>(signRequest);
            return response;
        }
    }
}
