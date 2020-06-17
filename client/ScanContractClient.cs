using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.constant;
using sign_sdk_net.entity;
using sign_sdk_net.entity.request.bases;
using sign_sdk_net.entity.request.personal;
using sign_sdk_net.entity.request.scanContract;
using sign_sdk_net.entity.response.scanContract;

namespace sign_sdk_net.client
{
    /// <summary>
    /// 扫码合同管理
    /// </summary>
    class ScanContractClient : BaseClient
    {
        public ScanContractClient(string baseUrl, TokenDataSource tokenDataSource, string appId, string appSecret) : base(baseUrl, tokenDataSource, appId, appSecret)
        { }

        /// <summary>
        /// 扫码合同添加接口
        /// </summary>
        /// <param name="scanContractAddRequest"></param>
        /// <returns></returns>
        public ScanContractAddResonse add(ScanContractAddRequest scanContractAddRequest)
        {
            SignRequest signRequest = new SignRequest(scanContractAddRequest);
            signRequest.apiUrl = ApiUrlConstant.ScanContract.Add;
            ScanContractAddResonse response = base.Send<ScanContractAddResonse>(signRequest);
            return response;
        }
        /// <summary>
        /// 扫码合同查询接口
        /// </summary>
        /// <param name="scanContractAddRequest"></param>
        /// <returns></returns>
        public ScanContractQueryResonse query(ScanContractQueryRequest scanContractQueryRequest)
        {
            SignRequest signRequest = new SignRequest(scanContractQueryRequest);
            signRequest.apiUrl = ApiUrlConstant.ScanContract.Query;
            ScanContractQueryResonse response = base.Send<ScanContractQueryResonse>(signRequest);
            return response;
        }

    }
}
