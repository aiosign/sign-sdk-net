using sign_sdk_net.constant;
using sign_sdk_net.entity;
using sign_sdk_net.entity.request;
using sign_sdk_net.entity.request.bases;
using sign_sdk_net.entity.request.file;
using sign_sdk_net.entity.response;
using sign_sdk_net.exception;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
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
        /// <summary>
        /// 文件下载
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public bool downloadFile(FileDownloadRequest request)
        {
            bool isDownload = false;
            if (request.file_id == null || request.file_id.Trim() == string.Empty|| request.file_name == null || request.file_name.Trim() == string.Empty) {
                BaseSignResponse baseSignResponse = new BaseSignResponse();
                baseSignResponse.result_code = "4001";
                baseSignResponse.result_message = "参数校验异常";
                throw new SignServerException("参数校验异常", baseSignResponse, null);
            }
            string downloadUrl = baseUrl + ApiUrlConstant.FileManager.FileDownload + "?fileId=" + request.file_id + "&" + access_token_key + "=" + base.getToken().access_token;
            try
            {
                HttpWebRequest httpWebRequest = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(downloadUrl);
                HttpWebResponse httpWebResponse = (System.Net.HttpWebResponse)httpWebRequest.GetResponse();
                if (httpWebResponse.ContentLength == -1) {
                    throw new SignServerException("文件下载异常", null,null);
                }
                Stream st = httpWebResponse.GetResponseStream();
                Stream so = new System.IO.FileStream(request.file_name, System.IO.FileMode.Create);
                byte[] by = new byte[1024];
                int osize = st.Read(by, 0, (int)by.Length);
                while (osize > 0)
                {
                    so.Write(by, 0, osize);
                    osize = st.Read(by, 0, (int)by.Length);
                }
                so.Close();
                st.Close();
                httpWebResponse.Close();
                httpWebRequest.Abort();
                isDownload = true;
            }
            catch (Exception e) {
                throw new SignServerException("文件下载异常", null, e.Message);
            }
            return isDownload;
        }
    }
}
