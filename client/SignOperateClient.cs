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
    /// 签章接口
    /// </summary>
    class SignOperateClient : BaseClient
    {
        public SignOperateClient(string baseUrl, TokenDataSource tokenDataSource, string appId, string appSecret) : base(baseUrl, tokenDataSource, appId, appSecret)
        { }
        /// <summary>
        /// 单模板签章
        /// </summary>
        /// <param name="signTemplateSingleRequest"></param>
        /// <returns></returns>
        public SignTemplateSingleResponse signTemplateSingle(SignTemplateSingleRequest signTemplateSingleRequest)
        {
            SignRequest signRequest = new SignRequest(signTemplateSingleRequest);
            signRequest.apiUrl = ApiUrlConstant.Sign.TemplateSingle;
            SignTemplateSingleResponse response = this.Send<SignTemplateSingleResponse>(signRequest);
            return response;
        }
        /// <summary>
        /// 批量模板签章
        /// </summary>
        /// <param name="signTemplateSingleRequest"></param>
        /// <returns></returns>
        public SignTemplateBatchResponse signTemplateBatch(SignTemplateBatchRequest signTemplateBatchRequest)
        {
            SignRequest signRequest = new SignRequest(signTemplateBatchRequest);
            signRequest.apiUrl = ApiUrlConstant.Sign.TemplateBatch;
            SignTemplateBatchResponse response = this.Send<SignTemplateBatchResponse>(signRequest);
            return response;
        }
        /// <summary>
        /// 合同坐标签章
        /// </summary>
        /// <param name="signCommonRequest"></param>
        /// <returns></returns>
        public SignCommonResponse signCommon(SignCommonRequest signCommonRequest)
        {
            SignRequest signRequest = new SignRequest(signCommonRequest);
            signRequest.apiUrl = ApiUrlConstant.Sign.Common;
            SignCommonResponse response = this.Send<SignCommonResponse>(signRequest);
            return response;
        }
        /// <summary>
        /// 关键字签章接口
        /// </summary>
        /// <param name="signKeywordSignRequest"></param>
        /// <returns></returns>
        public SignKeywordSignResponse keywordSign(SignKeywordSignRequest signKeywordSignRequest)
        {
            SignRequest signRequest = new SignRequest(signKeywordSignRequest);
            signRequest.apiUrl = ApiUrlConstant.Sign.KeywordSign;
            SignKeywordSignResponse response = this.Send<SignKeywordSignResponse>(signRequest);
            return response;
        }
        /// <summary>
        /// 会签接口
        /// </summary>
        /// <param name="signMeetingSingleRequest"></param>
        /// <returns></returns>
        public SignMeetingSingleResponse meetingSingle(SignMeetingSingleRequest signMeetingSingleRequest)
        {
            SignRequest signRequest = new SignRequest(signMeetingSingleRequest);
            signRequest.apiUrl = ApiUrlConstant.Sign.MeetingSingle;
            SignMeetingSingleResponse response = this.Send<SignMeetingSingleResponse>(signRequest);
            return response;
        }
        /// <summary>
        /// 扫码签章接口
        /// </summary>
        /// <param name="signScanContractRequest"></param>
        /// <returns></returns>
        public SignScanContractResponse scanSign(SignScanContractRequest signScanContractRequest)
        {
            SignRequest signRequest = new SignRequest(signScanContractRequest);
            signRequest.apiUrl = ApiUrlConstant.Sign.ScanSign;
            SignScanContractResponse response = this.Send<SignScanContractResponse>(signRequest);
            return response;
        }
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
        /// <summary>
        /// 一步签署接口
        /// </summary>
        /// <param name="directSignRequest"></param>
        /// <returns></returns>
        public DirectSignResponse directSign(DirectSignRequest directSignRequest) 
        {
            SignRequest signRequest = new SignRequest(directSignRequest);
            signRequest.apiUrl = ApiUrlConstant.Sign.DirectSign;
            DirectSignResponse response = this.Send<DirectSignResponse>(signRequest);
            return response;
        }
    }
}
