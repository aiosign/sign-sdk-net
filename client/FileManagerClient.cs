using sign_sdk_net.constant;
using sign_sdk_net.entity;
using sign_sdk_net.entity.request;
using sign_sdk_net.entity.request.bases;
using sign_sdk_net.entity.response;
using sign_sdk_net.exception;
using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.client
{
    /// <summary>
    /// 文件服务客户端
    /// </summary>
    public class FileManagerClient : BaseClient
    {
        public FileManagerClient(string baseUrl, TokenDataSource tokenDataSource, string appId, string appSecret) : base(baseUrl, tokenDataSource, appId, appSecret)
        {
        }
        /// <summary>
        /// 文件上传
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public FileUploadResponse fileUpload(FileUploadRequest request)
        {
            if (
                request.fileData == null || request.fileData.Length == 0
                || request.fileDataName == null || request.fileDataName.Trim() == string.Empty
                )
            {
                BaseSignResponse baseSignResponse = new BaseSignResponse();
                baseSignResponse.result_code = "4001";
                baseSignResponse.result_message = "参数校验异常";
                throw new SignServerException("参数校验异常", baseSignResponse,null);
            }

            FileInfo info = new FileInfo();
            info.fileData = request.fileData;
            info.fileName = request.fileName;
            info.key = "file";

            Dictionary<string, string> @params = new Dictionary<string, string>();
            @params.Add("file_type", request.fileType);
            @params.Add("file_name", request.fileName);
            @params.Add("user_id", request.userId);
            FileUploadResponse fileUploadResponse = base.FileUpload<FileUploadResponse>(ApiUrlConstant.FileManager.FileUpload, info, @params);

            return fileUploadResponse;
        }
    }
}
