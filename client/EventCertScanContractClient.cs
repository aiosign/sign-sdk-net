using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.constant;
using sign_sdk_net.entity;
using sign_sdk_net.entity.request.bases;
using sign_sdk_net.entity.request.scanContract;
using sign_sdk_net.entity.response.scanContract;

namespace sign_sdk_net.client
{
    /// <summary>
    /// 事件证书-扫码合同
    /// </summary>
    class EventCertScanContractClient : BaseClient
    {
        public EventCertScanContractClient(string baseUrl, TokenDataSource tokenDataSource, string appId, string appSecret) : base(baseUrl, tokenDataSource, appId, appSecret)
        { }

        /// <summary>
        /// 扫码合同添加接口
        /// </summary>
        /// <param name="scanContractAddRequest"></param>
        /// <returns></returns>
        public ScanContractAddResonse add(ScanContractAddRequest scanContractAddRequest)
        {
            SignRequest signRequest = new SignRequest(scanContractAddRequest);
            signRequest.apiUrl = ApiUrlConstant.EventCertScanContract.Add;
            ScanContractAddResonse response = base.Send<ScanContractAddResonse>(signRequest);
            return response;
        }
    }
}
