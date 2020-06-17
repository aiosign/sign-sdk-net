using System;
using System.Collections.Generic;
using sign_sdk_net.entity;
using System.Text;
using sign_sdk_net.entity.request.template;
using sign_sdk_net.entity.response.template;
using sign_sdk_net.entity.request.bases;
using sign_sdk_net.entity.response.seal;
using sign_sdk_net.constant;
using sign_sdk_net.entity.request;
using sign_sdk_net.entity.response;

namespace sign_sdk_net.client
{
    /// <summary>
    /// 模板管理接口
    /// </summary>
    class TemplateClient : FileManagerClient
    {
        public TemplateClient(string baseUrl, TokenDataSource tokenDataSource, string appId, string appSecret) : base(baseUrl, tokenDataSource, appId, appSecret)
        { }
        /// <summary>
        /// 模板添加并上传模板文件接口
        /// </summary>
        /// <param name="templateFileAddRequest"></param>
        /// <returns></returns>
        public TemplateAddResponse templateAdd(TemplateFileAddRequest templateFileAddRequest)
        {
            //上传合同文件
            FileUploadRequest fileUploadRequest = templateFileAddRequest.fileUploadRequest;
            fileUploadRequest.fileType = FileType.template;
            FileUploadResponse fileUploadResponse = base.fileUpload(fileUploadRequest);
            //添加模板
            TemplateAddRequest templateAddRequest = templateFileAddRequest.templateAddRequest;
            templateAddRequest.file_id = fileUploadResponse.file_id;
            SignRequest signRequest = new SignRequest(templateAddRequest);
            signRequest.apiUrl = ApiUrlConstant.Template.Add;
            TemplateAddResponse response = this.Send<TemplateAddResponse>(signRequest);
            return response;
        }
        /// <summary>
        /// 模板添加接口
        /// </summary>
        /// <param name="sealAddRequest"></param>
        /// <returns></returns>
        public TemplateAddResponse templateAdd(TemplateAddRequest templateAddRequest)
        {
            SignRequest signRequest = new SignRequest(templateAddRequest);
            signRequest.apiUrl = ApiUrlConstant.Template.Add;
            TemplateAddResponse response = this.Send<TemplateAddResponse>(signRequest);
            return response;
        }
        /// <summary>
        /// 模板查询接口
        /// </summary>
        /// <param name="templateQueryRequest"></param>
        /// <returns></returns>
        public TemplateQueryResponse templateQuery(TemplateQueryRequest templateQueryRequest)
        {
            SignRequest signRequest = new SignRequest(templateQueryRequest);
            signRequest.apiUrl = ApiUrlConstant.Template.Query;
            TemplateQueryResponse response = this.Send<TemplateQueryResponse>(signRequest);
            return response;
        }
        /// <summary>
        /// 模板删除接口
        /// </summary>
        /// <param name="templateDelRequest"></param>
        /// <returns></returns>
        public TemplateDelResponse templateDelete(TemplateDelRequest templateDelRequest)
        {
            SignRequest signRequest = new SignRequest(templateDelRequest);
            signRequest.apiUrl = ApiUrlConstant.Template.Delete;
            TemplateDelResponse response = this.Send<TemplateDelResponse>(signRequest);
            return response;
        }
        /// <summary>
        /// 模板锁定接口
        /// </summary>
        /// <param name="templateLockRequest"></param>
        /// <returns></returns>
        public TemplateLockResponse templateLock(TemplateLockRequest templateLockRequest)
        {
            SignRequest signRequest = new SignRequest(templateLockRequest);
            signRequest.apiUrl = ApiUrlConstant.Template.Lock;
            TemplateLockResponse response = this.Send<TemplateLockResponse>(signRequest);
            return response;
        }
        /// <summary>
        /// 模板解锁接口
        /// </summary>
        /// <param name="templateUnlockRequest"></param>
        /// <returns></returns>
        public TemplateUnlockResponse templateUnlock(TemplateUnlockRequest templateUnlockRequest)
        {
            SignRequest signRequest = new SignRequest(templateUnlockRequest);
            signRequest.apiUrl = ApiUrlConstant.Template.Unlock;
            TemplateUnlockResponse response = this.Send<TemplateUnlockResponse>(signRequest);
            return response;
        }

    }
}
