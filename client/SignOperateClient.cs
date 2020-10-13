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
        /// 单次模板签章
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
