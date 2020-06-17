using sign_sdk_net.constant;
using sign_sdk_net.entity;
using sign_sdk_net.entity.request.bases;
using sign_sdk_net.entity.request.cert;
using sign_sdk_net.entity.request.company;
using sign_sdk_net.entity.response.cert;
using sign_sdk_net.entity.response.company;
using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.client
{
    /// <summary>
    /// 企业客户 客户端对象
    /// </summary>
    class CompanyClient : BaseClient
    {
        public CompanyClient(string baseUrl, TokenDataSource tokenDataSource, string appId, string appSecret) : base(baseUrl, tokenDataSource, appId, appSecret)
        {
        }

        /// <summary>
        /// 企业用户注册并申请证书
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public CompanyRegisterResponse companyCertRegister(CompanyRegisterRequest companyRegisterRequest)
        {
            //企业用户注册
            SignRequest signRequest = new SignRequest(companyRegisterRequest);
            signRequest.apiUrl = ApiUrlConstant.Company.Register;
            CompanyRegisterResponse response = base.Send<CompanyRegisterResponse>(signRequest);
            //证书申请
            signRequest = new SignRequest(new CertApplyRequest(response.user_id));
            signRequest.apiUrl = ApiUrlConstant.Cert.Apply;
            CertApplyResponse certApplyResponse = base.Send<CertApplyResponse>(signRequest);
            return response;
        }
        /// <summary>
        /// 企业用户注册
        /// </summary>
        /// <param name="companyRegisterRequest"></param>
        /// <returns></returns>
        public CompanyRegisterResponse companyRegister(CompanyRegisterRequest companyRegisterRequest)
        {
            SignRequest signRequest = new SignRequest(companyRegisterRequest);
            signRequest.apiUrl = ApiUrlConstant.Company.Register;
            CompanyRegisterResponse response = base.Send<CompanyRegisterResponse>(signRequest);
            return response;
        }
        /// <summary>
        /// 查询企业信息
        /// </summary>
        /// <param name="companyUserinfoRequest"></param>
        /// <returns></returns>
        public CompanyUserinfoResponse companyUserinfo(CompanyUserinfoRequest request)
        {
            SignRequest signRequest = new SignRequest(request);
            signRequest.apiUrl = ApiUrlConstant.Company.Userinfo;
            CompanyUserinfoResponse response = base.Send<CompanyUserinfoResponse>(signRequest);
            return response;
        }
        ///<summary>
        ///企业用户锁定
        ///</summary>
        ///<param name="companyLockRequest"></param>
        ///<returns></returns>
        public CompanyLockResponse companylock(CompanyLockRequest companyLockRequest)
        {
            SignRequest signRequest = new SignRequest(companyLockRequest);
            signRequest.apiUrl = ApiUrlConstant.Company.Lock;
            CompanyLockResponse response = base.Send<CompanyLockResponse>(signRequest);
            return response;
        }
        /// <summary>
        /// 企业用户解锁
        /// </summary>
        /// <param name="companyUnlockRequest"></param>
        /// <returns></returns>
        public CompanyUnlockResponse companyUnlock(CompanyUnlockRequest companyUnlockRequest)
        {
            SignRequest signRequest = new SignRequest(companyUnlockRequest);
            signRequest.apiUrl = ApiUrlConstant.Company.Unlock;
            CompanyUnlockResponse response = base.Send<CompanyUnlockResponse>(signRequest);
            return response;

        }


    }
}
