using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.constant;
using sign_sdk_net.entity;
using sign_sdk_net.entity.request;
using sign_sdk_net.entity.request.bases;
using sign_sdk_net.entity.request.seal;
using sign_sdk_net.entity.response;
using sign_sdk_net.entity.response.seal;

namespace sign_sdk_net.client
{
    /// <summary>
    /// 印章管理接口
    /// </summary>
    class SealClient : FileManagerClient
    {
        public SealClient(string baseUrl, TokenDataSource tokenDataSource, string appId, string appSecret) : base(baseUrl, tokenDataSource, appId, appSecret)
        { }

        /// <summary>
        /// 印章以及文件添加接口
        /// </summary>
        /// <param name="sealFileAddRequest"></param>
        /// <returns></returns>
        public SealAddResponse addSealAndFile(SealFileAddRequest sealFileAddRequest)
        {
            //上传印章文件
            FileUploadRequest fileUploadRequest = sealFileAddRequest.fileUploadRequest;
            fileUploadRequest.fileType = FileType.impression;
            FileUploadResponse fileUploadResponse = base.fileUpload(fileUploadRequest);
            //添加印章信息
            SealAddRequest sealAddRequest = sealFileAddRequest.sealAddRequest;
            sealAddRequest.file_id = fileUploadResponse.file_id;
            SignRequest signRequest = new SignRequest(sealAddRequest);
            signRequest.apiUrl = ApiUrlConstant.Seal.Add;
            SealAddResponse response = this.Send<SealAddResponse>(signRequest);
            return response;
        }

        /// <summary>
        /// 印章添加接口
        /// </summary>
        /// <param name="sealAddRequest"></param>
        /// <returns></returns>
        public SealAddResponse add(SealAddRequest sealAddRequest)
        {
            SignRequest signRequest = new SignRequest(sealAddRequest);
            signRequest.apiUrl = ApiUrlConstant.Seal.Add;
            SealAddResponse response = this.Send<SealAddResponse>(signRequest);
            return response;
        }
        /// <summary>
        /// 印章查询接口
        /// </summary>
        /// <param name="sealQueryRequest"></param>
        /// <returns></returns>
        public SealQueryResponse query(SealQueryRequest sealQueryRequest)
        {
            SignRequest signRequest = new SignRequest(sealQueryRequest);
            signRequest.apiUrl = ApiUrlConstant.Seal.Query;
            SealQueryResponse response = this.Send<SealQueryResponse>(signRequest);
            return response;
        }

        /// <summary>
        /// 根据用户查询所有印章
        /// </summary>
        /// <param name="sealGetSealInfosRequest"></param>
        /// <returns></returns>
        public List<GetSealInfosResponse> getSealInfos(GetSealInfosRequest sealGetSealInfosRequest)
        {
            SignRequest signRequest = new SignRequest(sealGetSealInfosRequest);
            signRequest.apiUrl = ApiUrlConstant.Seal.GetSealInfos;
            List<GetSealInfosResponse> response = this.Send<List<GetSealInfosResponse>>(signRequest);
            return response;
        }
        /// <summary>
        /// 根据用户查询所有印章
        /// </summary>
        /// <param name="sealGetSealInfosRequest"></param>
        /// <returns></returns>
        public List<GetSealInfosByUserOrTypeResponse> getSealInfosByUserOrType(GetSealInfosByUserOrTypeRequest sealGetSealInfosRequest)
        {
            SignRequest signRequest = new SignRequest(sealGetSealInfosRequest);
            signRequest.apiUrl = ApiUrlConstant.Seal.GetSealInfosByUserOrType;
            List<GetSealInfosByUserOrTypeResponse> response = this.Send<List<GetSealInfosByUserOrTypeResponse>>(signRequest);
            return response;
        }

        /// <summary>
        /// 印章注销接口
        /// </summary>
        /// <param name="sealRemoveRequest"></param>
        /// <returns></returns>
        public SealRemoveResponse remove(SealRemoveRequest sealRemoveRequest)
        {
            SignRequest signRequest = new SignRequest(sealRemoveRequest);
            signRequest.apiUrl = ApiUrlConstant.Seal.Remove;
            SealRemoveResponse response = this.Send<SealRemoveResponse>(signRequest);
            return response;
        }
        /// <summary>
        /// 印章锁定接口
        /// </summary>
        /// <param name="sealLockRequest"></param>
        /// <returns></returns>
        public SealLockResponse sealLock(SealLockRequest sealLockRequest)
        {
            SignRequest signRequest = new SignRequest(sealLockRequest);
            signRequest.apiUrl = ApiUrlConstant.Seal.Lock;
            SealLockResponse response = this.Send<SealLockResponse>(signRequest);
            return response;
        }

        public SealUnlockResponse sealUnlock(SealUnlockRequest sealLockRequest)
        {
            SignRequest signRequest = new SignRequest(sealLockRequest);
            signRequest.apiUrl = ApiUrlConstant.Seal.Unlock;
            SealUnlockResponse response = this.Send<SealUnlockResponse>(signRequest);
            return response;
        }

    }
}
