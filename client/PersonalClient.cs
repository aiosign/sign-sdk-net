using sign_sdk_net.constant;
using sign_sdk_net.entity;
using sign_sdk_net.entity.request;
using sign_sdk_net.entity.request.bases;
using sign_sdk_net.entity.request.cert;
using sign_sdk_net.entity.request.personal;
using sign_sdk_net.entity.response;
using sign_sdk_net.entity.response.cert;
using sign_sdk_net.util;
using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.client
{
    /// <summary>
    /// 个人用户请求对象
    /// </summary>
    class PersonalClient : BaseClient
    {
        public PersonalClient(string baseUrl, TokenDataSource tokenDataSource, string appId, string appSecret) : base(baseUrl, tokenDataSource, appId, appSecret)
        {
        }

        /// <summary>
        /// 个人用户注册并申请证书
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PersonalRegisterResponse personalCertRegister(PersonalRegisterRequest request)
        {
            //个人用户注册
            SignRequest signRequest = new SignRequest(request);
            signRequest.apiUrl = ApiUrlConstant.Personal.Register;
            PersonalRegisterResponse response = this.Send<PersonalRegisterResponse>(signRequest);
            //证书申请
            signRequest = new SignRequest(new CertApplyRequest(response.user_id));
            signRequest.apiUrl = ApiUrlConstant.Cert.Apply;
            CertApplyResponse certApplyResponse = base.Send<CertApplyResponse>(signRequest);
            return response;
        }

        /// <summary>
        /// 获取个人用户信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PersonalUserinfoResponse personalUserinfo(PersonalUserinfoRequest request)
        {
            SignRequest signRequest = new SignRequest(request);
            signRequest.apiUrl = ApiUrlConstant.Personal.UserInfo;
            PersonalUserinfoResponse response = this.Send<PersonalUserinfoResponse>(signRequest);
            return response;
        }
        /// <summary>
        /// 创建个人用户
        /// </summary>
        /// <param name="personalRegisterRequest"></param>
        /// <returns></returns>
        public PersonalRegisterResponse personalRegister(PersonalRegisterRequest request)
        {
            SignRequest signRequest = new SignRequest(request);
            signRequest.apiUrl = ApiUrlConstant.Personal.Register;
            PersonalRegisterResponse response = this.Send<PersonalRegisterResponse>(signRequest);
            return response;
        }
        /// <summary>
        /// 锁定个人用户
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PersonalLockResponse personalLock(PersonalLockRequest request)
        {
            SignRequest signRequest = new SignRequest(request);
            signRequest.apiUrl = ApiUrlConstant.Personal.Lock;
            PersonalLockResponse response = this.Send<PersonalLockResponse>(signRequest);
            return response;
        }
        /// <summary>
        /// 解锁个人用户
        /// </summary>
        /// <param name="personalUnlockRequest"></param>
        /// <returns></returns>
        public PersonalUnlockResponse personalUnlock(PersonalUnlockRequest request)
        {
            SignRequest signRequest = new SignRequest(request);
            signRequest.apiUrl = ApiUrlConstant.Personal.Unlock;
            PersonalUnlockResponse response = this.Send<PersonalUnlockResponse>(signRequest);
            return response;
        }
    }
}
