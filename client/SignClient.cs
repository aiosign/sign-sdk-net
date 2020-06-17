using sign_sdk_net.constant;
using sign_sdk_net.entity;
using sign_sdk_net.entity.request;
using sign_sdk_net.entity.request.bases;
using sign_sdk_net.entity.response;
using sign_sdk_net.enums;
using sign_sdk_net.exception;
using sign_sdk_net.util;
using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.client
{
    class SignClient
    {
        /// <summary>
        ///  远程服务 base URl
        /// </summary>
        private string baseUrl; 
        /// <summary>
        /// token 存储池
        /// </summary>
        private TokenDataSource tokenDataSource { get; set; }
        /// <summary>
        /// 应用id
        /// </summary>
        private string appId { get; set; }
        /// <summary>
        /// 应用秘钥
        /// </summary>
        private string appSecret { get; set; }
        /// <summary>
        /// 个人用户 api 对象
        /// </summary>
        public PersonalClient Personal { get; private set; }
        public CompanyClient Company { get; private set; }
        /// <summary>
        /// 印章管理
        /// </summary>
        public SealClient Seal { get; private set; }
        /// <summary>
        /// 模板管理
        /// </summary>
        public TemplateClient Template { get; private set; }
        /// <summary>
        /// 合同管理
        /// </summary>
        public ContractClient Contract { get; private set; }
        /// <summary>
        /// 扫码合同
        /// </summary>
        public ScanContractClient ScanContract { get; private set; }
        /// <summary>
        /// 证书 api对象
        /// </summary>
        public CertClient Cert { get; private set; }
        /// <summary>
        /// 签章 api对象
        /// </summary>
        public SignOperateClient SignOperate { get; private set; }

        /// <summary>
        /// 文件管理
        /// </summary>
        public FileManagerClient FileManager { get; private set; }
        /// <summary>
        /// 文件验章
        /// </summary>
        /// <returns></returns>
        public SignCheckClient SignCheck { get; set; }
        /// <summary>
        /// 初始化相关 参数对象
        /// </summary>
        private void init()
        {
            this.Personal = new PersonalClient(baseUrl, tokenDataSource, appId, appSecret);
            this.FileManager = new FileManagerClient(baseUrl, tokenDataSource, appId, appSecret);
            this.Company = new CompanyClient(baseUrl, tokenDataSource, appId, appSecret);
            this.Cert = new CertClient(baseUrl, tokenDataSource, appId, appSecret);
            this.Seal = new SealClient(baseUrl, tokenDataSource, appId, appSecret);
            this.Template = new TemplateClient(baseUrl, tokenDataSource, appId, appSecret);
            this.Contract = new ContractClient(baseUrl, tokenDataSource, appId, appSecret);
            this.ScanContract = new ScanContractClient(baseUrl, tokenDataSource, appId, appSecret);
            this.SignOperate = new SignOperateClient(baseUrl, tokenDataSource, appId, appSecret);
            this.SignCheck = new SignCheckClient(baseUrl, tokenDataSource, appId, appSecret);
        }

        /// <summary>
        /// 初始化 客户端对象
        /// </summary>
        /// <param name="baseUrl">服务端api</param>
        /// <param name="tokenDataSource">token存储库</param>
        /// <param name="appId">应用id</param>
        /// <param name="appSecret">应用秘钥</param>
        public SignClient(string baseUrl, TokenDataSource tokenDataSource, string appId, string appSecret)
        {
            if (
                string.IsNullOrEmpty(baseUrl) ||
                tokenDataSource == null ||
                string.IsNullOrEmpty(appId) ||
                string.IsNullOrEmpty(appSecret) ||
                tokenDataSource == null
                )
            {
                throw new SignClientInitException("签名客户端初始失败！请核对相关参数");
            }

            if (appId.Length != 18)
            {
                throw new SignClientInitException("签名客户端初始失败！AppId 参数异常");
            }

            this.baseUrl = baseUrl;
            this.tokenDataSource = tokenDataSource;
            this.appId = appId;
            this.appSecret = appSecret;
            // 初始化对象
            init();
        }
        /// <summary>
        /// 获取token
        /// </summary>
        /// <returns></returns>
        public string getToken()
        {
            return Personal.getToken().access_token;
        }


    }
}
