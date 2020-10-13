using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.constant;
using sign_sdk_net.entity;
using sign_sdk_net.entity.request.bases;
using sign_sdk_net.entity.request.sign;
using sign_sdk_net.entity.response.sign;

namespace sign_sdk_net.client
{
    /// <summary>
    /// 事件证书-签章接口
    /// </summary>
    class EventCertSignClient : BaseClient
    {
        public EventCertSignClient(string baseUrl, TokenDataSource tokenDataSource, string appId, string appSecret) : base(baseUrl, tokenDataSource, appId, appSecret)
        { }
        /// <summary>
        /// 事件证书-单模板签章
        /// </summary>
        /// <param name="signTemplateSingleRequest"></param>
        /// <returns></returns>
        public EventCertSignTemplateSingleResponse eventCertSignTemplateSingle(EventCertSignTemplateSingleRequest eventCertSignTemplateSingle)
        {
            SignRequest signRequest = new SignRequest(eventCertSignTemplateSingle);
            signRequest.apiUrl = ApiUrlConstant.Sign.EventCertTemplateSingle;
            EventCertSignTemplateSingleResponse response = this.Send<EventCertSignTemplateSingleResponse>(signRequest);
            return response;
        }
        /// <summary>
        /// 事件证书-批量模板签章
        /// </summary>
        /// <param name="signTemplateSingleRequest"></param>
        /// <returns></returns>
        public EventCertSignTemplateBatchResponse eventCertSignTemplateBatch(EventCertSignTemplateBatchRequest eventCertSignTemplateBatch)
        {
            SignRequest signRequest = new SignRequest(eventCertSignTemplateBatch);
            signRequest.apiUrl = ApiUrlConstant.Sign.EventCertTemplateBatch;
            EventCertSignTemplateBatchResponse response = this.Send<EventCertSignTemplateBatchResponse>(signRequest);
            return response;
        }
        /// <summary>
        /// 事件证书-合同坐标签章
        /// </summary>
        /// <param name="signCommonRequest"></param>
        /// <returns></returns>
        public EventCertSignCommonResponse eventCertSignCommon(SignCommonRequest signCommonRequest)
        {
            SignRequest signRequest = new SignRequest(signCommonRequest);
            signRequest.apiUrl = ApiUrlConstant.Sign.EventCertCommon;
            EventCertSignCommonResponse response = this.Send<EventCertSignCommonResponse>(signRequest);
            return response;
        }
        /// <summary>
        /// 事件证书-关键字签章接口
        /// </summary>
        /// <param name="signKeywordSignRequest"></param>
        /// <returns></returns>
        public EventCertSignKeywordSignResponse eventCertKeywordSign(SignKeywordSignRequest signKeywordSignRequest)
        {
            SignRequest signRequest = new SignRequest(signKeywordSignRequest);
            signRequest.apiUrl = ApiUrlConstant.Sign.EventCertKeywordSign;
            EventCertSignKeywordSignResponse response = this.Send<EventCertSignKeywordSignResponse>(signRequest);
            return response;
        }
        /// <summary>
        /// 事件证书-会签接口
        /// </summary>
        /// <param name="signMeetingSingleRequest"></param>
        /// <returns></returns>
        public EventCertSignMeetingSingleResponse eventCertMeetingSingle(SignMeetingSingleRequest signMeetingSingleRequest)
        {
            SignRequest signRequest = new SignRequest(signMeetingSingleRequest);
            signRequest.apiUrl = ApiUrlConstant.Sign.EventCertMeetingSingle;
            EventCertSignMeetingSingleResponse response = this.Send<EventCertSignMeetingSingleResponse>(signRequest);
            return response;
        }
        /// <summary>
        /// 事件证书-扫码签章接口
        /// </summary>
        /// <param name="signScanContractRequest"></param>
        /// <returns></returns>
        public EventCertSignScanContractResponse eventCertScanSign(SignScanContractRequest signScanContractRequest)
        {
            SignRequest signRequest = new SignRequest(signScanContractRequest);
            signRequest.apiUrl = ApiUrlConstant.Sign.EventCertScanSign;
            EventCertSignScanContractResponse response = this.Send<EventCertSignScanContractResponse>(signRequest);
            return response;
        }
    }
}
