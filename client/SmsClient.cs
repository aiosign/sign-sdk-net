using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.constant;
using sign_sdk_net.entity;
using sign_sdk_net.entity.request.bases;
using sign_sdk_net.entity.request.sms;
using sign_sdk_net.entity.response.sms;

namespace sign_sdk_net.client
{
    /// <summary>
    /// 短信
    /// </summary>
    class SmsClient : BaseClient
    {
        public SmsClient(string baseUrl, TokenDataSource tokenDataSource, string appId, string appSecret) : base(baseUrl, tokenDataSource, appId, appSecret)
        { }
        /// <summary>
        /// 单次发送短信
        /// </summary>
        /// <param name="smsSingleRequest"></param>
        /// <returns></returns>
        public SmsSingleResponse smsSingle(SmsSingleRequest smsSingleRequest)
        {
            SignRequest signRequest = new SignRequest(smsSingleRequest);
            signRequest.apiUrl = ApiUrlConstant.Sms.signle;
            SmsSingleResponse response = this.Send<SmsSingleResponse>(signRequest);
            return response;
        }

        /// <summary>
        /// 批量发送短信
        /// </summary>
        /// <param name="smsBatchRequest"></param>
        /// <returns></returns>
        public List<SmsBatchResponse> smsBatch(SmsBatchRequest smsBatchRequest)
        {
            SignRequest signRequest = new SignRequest(smsBatchRequest);
            signRequest.apiUrl = ApiUrlConstant.Sms.batch;
            List<SmsBatchResponse> response = this.Send<List<SmsBatchResponse>>(signRequest);
            return response;
        }

        /// <summary>
        /// 短信验证码
        /// </summary>
        /// <param name="smsAuthCodeRequest"></param>
        /// <returns></returns>
        public SmsAuthCodeResponse smsAuthCode(SmsAuthCodeRequest smsAuthCodeRequest)
        {
            SignRequest signRequest = new SignRequest(smsAuthCodeRequest);
            signRequest.apiUrl = ApiUrlConstant.Sms.authCode;
            SmsAuthCodeResponse response = this.Send<SmsAuthCodeResponse>(signRequest);
            return response;
        }

        /// <summary>
        /// 验证-短信验证码
        /// </summary>
        /// <param name="smsValidAuthCodeRequest"></param>
        /// <returns></returns>
        public SmsValidAuthCodeResponse smsValidAuthCode(SmsValidAuthCodeRequest smsValidAuthCodeRequest) {
            SignRequest signRequest = new SignRequest(smsValidAuthCodeRequest);
            signRequest.apiUrl = ApiUrlConstant.Sms.validAuthCode;
            SmsValidAuthCodeResponse response = this.Send<SmsValidAuthCodeResponse>(signRequest);
            return response;
        }
    }
}
