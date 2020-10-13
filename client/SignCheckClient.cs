using sign_sdk_net.constant;
using sign_sdk_net.entity;
using sign_sdk_net.entity.request;
using sign_sdk_net.entity.request.bases;
using sign_sdk_net.entity.request.signCheck;
using sign_sdk_net.entity.response;
using sign_sdk_net.entity.response.signCheck;
using sign_sdk_net.exception;
using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.client
{
    /// <summary>
    /// 签章验章服务
    /// </summary>
    class SignCheckClient : BaseClient
    {
        public SignCheckClient(string baseUrl, TokenDataSource tokenDataSource, string appId, string appSecret) : base(baseUrl, tokenDataSource, appId, appSecret)
        {
        }

        /// <summary>
        /// 文件id 验章
        /// </summary>
        /// <param name="signCheckCommonRequest"></param>
        public SignCheckCommonResponse checkCommon(SignCheckCommonRequest signCheckCommonRequest)
        {
            SignRequest request = new SignRequest(signCheckCommonRequest);
            request.apiUrl = ApiUrlConstant.SignCheck.CheckCommon;
            return base.Send<SignCheckCommonResponse>(request);
        }
        /// <summary>
        /// 文件验章
        /// </summary>
        /// <param name="signCheckFileRequest"></param>
        /// <returns></returns>
        public SignCheckFileResponse checkFile(SignCheckFileRequest request) {
            if (
               request.fileData == null || request.fileData.Length == 0
               || request.fileDataName == null || request.fileDataName.Trim() == string.Empty
               )
            {
                BaseSignResponse baseSignResponse = new BaseSignResponse();
                baseSignResponse.result_code = "4001";
                baseSignResponse.result_message = "参数校验异常";
                throw new SignServerException("参数校验异常", baseSignResponse,JSONUtil.getJsonStringFromObject(request));
            }

            FileInfo info = new FileInfo();
            info.fileData = request.fileData;
            info.fileName = request.fileDataName;
            info.key = "file";

            Dictionary<string, string> @params = new Dictionary<string, string>();
            @params.Add("file_name", request.fileDataName);

            SignCheckFileResponse signCheckFileResponse = base.FileUpload<SignCheckFileResponse>(ApiUrlConstant.SignCheck.CheckFile, info, @params);
            return signCheckFileResponse;
        }
        /// <summary>
        /// 文件验章V2
        /// </summary>
        /// <param name="signCheckFileRequest"></param>
        /// <returns></returns>
        public SignCheckFileV2Response CheckFileV2(SignCheckFileV2Request request)
        {
            if (
               request.fileData == null || request.fileData.Length == 0
               || request.fileDataName == null || request.fileDataName.Trim() == string.Empty
               )
            {
                BaseSignResponse baseSignResponse = new BaseSignResponse();
                baseSignResponse.result_code = "4001";
                baseSignResponse.result_message = "参数校验异常";
                throw new SignServerException("参数校验异常", baseSignResponse, JSONUtil.getJsonStringFromObject(request));
            }

            FileInfo info = new FileInfo();
            info.fileData = request.fileData;
            info.fileName = request.fileDataName;
            info.key = "file";

            Dictionary<string, string> @params = new Dictionary<string, string>();
            @params.Add("file_name", request.fileDataName);

            SignCheckFileV2Response signCheckFileResponse = base.FileUpload<SignCheckFileV2Response>(ApiUrlConstant.SignCheck.CheckFileV2, info, @params);
            return signCheckFileResponse;
        }

    }
}
