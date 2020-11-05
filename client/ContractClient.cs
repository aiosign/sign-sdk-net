using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.constant;
using sign_sdk_net.entity;
using sign_sdk_net.entity.request;
using sign_sdk_net.entity.request.bases;
using sign_sdk_net.entity.request.contract;
using sign_sdk_net.entity.response;
using sign_sdk_net.entity.response.contract;

namespace sign_sdk_net.client
{
    /// <summary>
    /// 合同管理
    /// </summary>
    class ContractClient : FileManagerClient
    {
        public ContractClient(string baseUrl, TokenDataSource tokenDataSource, string appId, string appSecret) : base(baseUrl, tokenDataSource, appId, appSecret)
        { }

        /// <summary>
        /// 合同添加并添加合同文件
        /// </summary>
        /// <param name="contractFileAddRequest"></param>
        /// <returns></returns>
        public ContractAddResponse addContractAndFile(ContractFileAddRequest contractFileAddRequest)
        {
            //上传合同文件
            FileUploadRequest fileUploadRequest = contractFileAddRequest.fileUploadRequest;
            fileUploadRequest.fileType = FileType.contract;
            FileUploadResponse fileUploadResponse = base.fileUpload(fileUploadRequest);
            //添加合同
            ContractAddRequest contractAddRequest = contractFileAddRequest.contractAddRequest;
            contractAddRequest.file_id = fileUploadResponse.file_id;
            SignRequest signRequest = new SignRequest(contractAddRequest);
            signRequest.apiUrl = ApiUrlConstant.Contract.Add;
            ContractAddResponse response = base.Send<ContractAddResponse>(signRequest);
            return response;
        }
        /// <summary>
        /// 合同添加接口
        /// </summary>
        /// <param name="contractAddRequest"></param>
        /// <returns></returns>
        public ContractAddResponse add(ContractAddRequest contractAddRequest)
        {
            SignRequest signRequest = new SignRequest(contractAddRequest);
            signRequest.apiUrl = ApiUrlConstant.Contract.Add;
            ContractAddResponse response = base.Send<ContractAddResponse>(signRequest);
            return response;
        }
        /// <summary>
        /// 合同查询
        /// </summary>
        /// <param name="contractQueryRequest"></param>
        /// <returns></returns>
        public ContractQueryResponse query(ContractQueryRequest contractQueryRequest)
        {
            SignRequest signRequest = new SignRequest(contractQueryRequest);
            signRequest.apiUrl = ApiUrlConstant.Contract.Query;
            ContractQueryResponse response = base.Send<ContractQueryResponse>(signRequest);
            return response;
        }
        /// <summary>
        /// 删除合同接口
        /// </summary>
        /// <param name="contractRemoveRequest"></param>
        /// <returns></returns>
        public ContractRemoveResponse remove(ContractRemoveRequest contractRemoveRequest)
        {
            SignRequest signRequest = new SignRequest(contractRemoveRequest);
            signRequest.apiUrl = ApiUrlConstant.Contract.Remove;
            ContractRemoveResponse response = base.Send<ContractRemoveResponse>(signRequest);
            return response;
        }
        /// <summary>
        /// 渲染合同
        /// </summary>
        /// <param name="contractRenderRequest"></param>
        /// <returns></returns>
        public ContractRenderResponse render(ContractRenderRequest contractRenderRequest)
        {
            SignRequest signRequest = new SignRequest(contractRenderRequest);
            signRequest.apiUrl = ApiUrlConstant.Contract.Render;
            ContractRenderResponse response = base.Send<ContractRenderResponse>(signRequest);
            return response;
        }
        /// <summary>
        /// 作废合同
        /// </summary>
        /// <param name="contractRenderRequest"></param>
        /// <returns></returns>
        public ContractAbolishResponse abolish(ContractAbolishRequest contractAbolishRequest)
        {
            SignRequest signRequest = new SignRequest(contractAbolishRequest);
            signRequest.apiUrl = ApiUrlConstant.Contract.Abolish;
            ContractAbolishResponse response = base.Send<ContractAbolishResponse>(signRequest);
            return response;
        }
        /// <summary>
        /// 作废合同V2
        /// </summary>
        /// <param name="contractRenderRequest"></param>
        /// <returns></returns>
        public ContractAbolishResponse abolishV2(ContractAbolishV2Request contractAbolishV2Request)
        {
            SignRequest signRequest = new SignRequest(contractAbolishV2Request);
            signRequest.apiUrl = ApiUrlConstant.Contract.AbolishV2;
            ContractAbolishResponse response = base.Send<ContractAbolishResponse>(signRequest);
            return response;
        }
        /// <summary>
        /// 绑定合同
        /// </summary>
        /// <param name="contractBindPhoneRequest"></param>
        /// <returns></returns>
        public ContractBindPhoneResponse bind(ContractBindPhoneRequest contractBindPhoneRequest) 
        {
            SignRequest signRequest = new SignRequest(contractBindPhoneRequest);
            signRequest.apiUrl = ApiUrlConstant.Contract.Bind;
            ContractBindPhoneResponse response = base.Send<ContractBindPhoneResponse>(signRequest);
            return response;
        }
        /// <summary>
        /// 查询绑定合同
        /// </summary>
        /// <param name="contractQueryBindRequest"></param>
        /// <returns></returns>
        public List<ContractQueryBindResponse> queryBindContract(ContractQueryBindRequest contractQueryBindRequest)
        {
            SignRequest signRequest = new SignRequest(contractQueryBindRequest);
            signRequest.apiUrl = ApiUrlConstant.Contract.QueryBindContract;
            List<ContractQueryBindResponse> response = base.Send<List<ContractQueryBindResponse>>(signRequest);
            return response;
        }
    }
}
