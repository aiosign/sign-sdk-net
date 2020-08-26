using sign_sdk_net.client;
using sign_sdk_net.constant;
using sign_sdk_net.entity;
using sign_sdk_net.entity.request;
using sign_sdk_net.entity.request.auth;
using sign_sdk_net.entity.request.cert;
using sign_sdk_net.entity.request.company;
using sign_sdk_net.entity.request.contract;
using sign_sdk_net.entity.request.personal;
using sign_sdk_net.entity.request.scanContract;
using sign_sdk_net.entity.request.seal;
using sign_sdk_net.entity.request.sign;
using sign_sdk_net.entity.request.signCheck;
using sign_sdk_net.entity.request.sms;
using sign_sdk_net.entity.request.template;
using sign_sdk_net.entity.response;
using sign_sdk_net.entity.response.auth;
using sign_sdk_net.entity.response.cert;
using sign_sdk_net.entity.response.company;
using sign_sdk_net.entity.response.contract;
using sign_sdk_net.entity.response.scanContract;
using sign_sdk_net.entity.response.seal;
using sign_sdk_net.entity.response.sign;
using sign_sdk_net.entity.response.signCheck;
using sign_sdk_net.entity.response.sms;
using sign_sdk_net.entity.response.template;
using sign_sdk_net.enums;
using sign_sdk_net.exception;
using sign_sdk_net.util;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Intrinsics.X86;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using static sign_sdk_net.entity.request.sign.EventCertSignTemplateBatchRequest;
using static sign_sdk_net.TestDemo;

namespace sign_sdk_net
{
    class TestDemo
    {


        /// <summary>
        /// token 存储池实现类
        /// </summary>
        public class DictionaryTokenDataSource : TokenDataSource
        {
            Dictionary<string, Token> dataSource = new Dictionary<string, Token>();

            Token TokenDataSource.deleteToken(string appId)
            {
                TokenDataSource ds = (TokenDataSource)this;
                Token token = ds.getToken(appId);
                dataSource.Remove(appId);
                return token;
            }

            Token TokenDataSource.getToken(string appId)
            {
                if (dataSource.ContainsKey(appId))
                {
                    return dataSource[appId];
                }
                return null;
            }

            Token TokenDataSource.setToken(string appId, Token token)
            {
                TokenDataSource ds = (TokenDataSource)this;
                ds.deleteToken(appId);
                dataSource.Add(appId, token);
                return token;
            }

        }

        const string baseUrl = "http://127.0.0.1:80";
        const string appId = "Your AppId.";
        const string appSecret = "Your AppSecret.";



        static void Main(string[] args)
        {
            //检查个人签章流程
            //Console.WriteLine("***********************************************************************");
            //Console.WriteLine("************************检查个人签章流程 start ************************");
            //checkPersonalSign();
            //Console.WriteLine("***********************************************************************");
            //Console.WriteLine("************************检查个人签章流程 end **************************");

            //检查企业签章流程
            //Console.WriteLine("***********************************************************************");
            // Console.WriteLine("************************检查企业签章流程 start ************************");
            // checkCompanySign();
            //Console.WriteLine("***********************************************************************");
            //Console.WriteLine("************************检查企业签章流程 end **************************");

            //检查复合接口
            checkMergesApi();

            //检查认证接口
            checkAuth();

            //检查短信接口
            checkSms();

            Console.ReadKey();
        }

        /// <summary>
        /// 新增合并接口 
        /// 1.用户证书注册
        /// 2.印章以及文件添加
        /// 3.合同以及文件添加
        /// 4.模板以及文件添加
        /// </summary>
        static void checkMergesApi()
        {
            Console.WriteLine("***********************************************************************");
            Console.WriteLine("************************检查个人签章聚合流程 start ********************");
            checkMergesPersonal();
            Console.WriteLine("***********************************************************************");
            Console.WriteLine("************************检查个人签章聚合流程 end **********************");

            Console.WriteLine("***********************************************************************");
            Console.WriteLine("************************检查企业签章聚合流程 start ********************");
            checkMergesCompany();
            Console.WriteLine("***********************************************************************");
            Console.WriteLine("************************检查企业签章聚合流程 end **********************");
        }
        /// <summary>
        /// 检查认证流程
        /// </summary>
        static void checkAuth() {
            Console.WriteLine("***********************************************************************");
            Console.WriteLine("************************检查认证流程 start ****************************");
            //三网认证 
            AuthEncryRequest authEncryRequest = new AuthEncryRequest();
            authEncryRequest.name = "测试";
            authEncryRequest.id_card = "37081119900506061X";
            authEncryRequest.phone = "15011188888";
            authEncryQuery(authEncryRequest);

            //银行卡四要素认证
            BlankCardCheckRequest blankCardCheckRequest = new BlankCardCheckRequest();
            blankCardCheckRequest.bankcard = "372926198908020031";
            blankCardCheckRequest.idcard = "37081119900506061X";
            blankCardCheckRequest.mobile = "15011188888";
            blankCardCheckRequest.realname = "测试";
            blankFourEnCeryQuery(blankCardCheckRequest);

            //企业三要素认证
            EnterpriseQueryRequest enterpriseQueryRequest = new EnterpriseQueryRequest();
            enterpriseQueryRequest.oper_name = "测试";
            enterpriseQueryRequest.name = "山东国盾网信息科技有限公司";
            enterpriseQueryRequest.keyword = "91320112MA3F6JM111";
            enterpriseThreeQuery(enterpriseQueryRequest);

            //支付宝认证-开始认证
            AliPayCertifyRequest aliPayCertifyRequest = new AliPayCertifyRequest();
            aliPayCertifyRequest.name = "测试";
            aliPayCertifyRequest.certify_type = CertifyType.CERT_PHOTO;
            aliPayCertifyRequest.id_card_num = "37081119900506061X";
            string certify_id=aliPayCertify(aliPayCertifyRequest);

            //支付宝认证-认证查询
            AliPayQueryRequest aliPayQueryRequest = new AliPayQueryRequest();
            aliPayQueryRequest.certifty_id = certify_id;
            aliPayCertifyQuery(aliPayQueryRequest);

            //数据宝企业四要素认证
            SJBEntFourRequest sJBEntFourRequest = new SJBEntFourRequest();
            sJBEntFourRequest.entname = "山东国盾网信息科技有限公司";
            sJBEntFourRequest.entmark = "91320112MA3F6JM111";
            sJBEntFourRequest.name = "测试";
            sJBEntFourRequest.idcard = "37081119900506061X";
            entFour(sJBEntFourRequest);

            //企业打款
            EnterprisePayRequest enterprisePayRequest = new EnterprisePayRequest();
            enterprisePayRequest.key_type = "1";
            enterprisePayRequest.key = "91320112MA3F6JM111";
            enterprisePayRequest.name = "山东国盾网信息科技有限公司";
            enterprisePayRequest.usr_name = "测试";
            enterprisePayRequest.account_no = "372926198908020031";
            enterprisePayRequest.account_bank = "中国工商银行";
            enterprisePayRequest.account_province = "山东";
            enterprisePayRequest.account_city = "济南";
            string order_id=enterprisePay(enterprisePayRequest);

            //企业打款查询
            EnterprisePayQueryRequest enterprisePayQueryRequest = new EnterprisePayQueryRequest();
            enterprisePayQueryRequest.order_id = order_id;
            enterprisePayQueryRequest.account_no = "372926198908020031";
            enterprisePayQuery(enterprisePayQueryRequest);

            //企业打款验证
            EnterprisePayValidRequest enterprisePayValidRequest = new EnterprisePayValidRequest();
            enterprisePayValidRequest.order_id = order_id;
            enterprisePayValidRequest.account_no = "372926198908020031";
            enterprisePayValidRequest.amount = 1;
            enterprisePayValid(enterprisePayValidRequest);

            //获取百度身份验证-语音验证数据
            string session_id=baiduSessionCode();

            //获取百度身份验证-语音验证数据
            BaiDuAiFaceVideoVerifyRequest baiDuAiFaceVideoVerifyRequest = new BaiDuAiFaceVideoVerifyRequest();
            FileUploadRequest fileUploadRequest=getFileUploadRequest("D:/demo.mp4", "demo.mp4");
            baiDuAiFaceVideoVerifyRequest.session_id = session_id;
            baiDuAiFaceVideoVerifyRequest.video_file = fileUploadRequest.fileData;
            baiduVideoVerify(baiDuAiFaceVideoVerifyRequest);

            //获取百度身份验证-身份验证
            BaiDuAiFaceCertifyVerifyRequest baiDuAiFaceCertifyVerifyRequest = new BaiDuAiFaceCertifyVerifyRequest();
            baiDuAiFaceCertifyVerifyRequest.name = "测试";
            baiDuAiFaceCertifyVerifyRequest.id_card_number = "37081119900506061X";
            baiDuAiFaceCertifyVerifyRequest.image = "iVBORw0KGgoAAAANSUhEUgAABwkAAAcJCAYAAAAMDS0dAAAACXBIWXMAAJxAAACcQAHJJQ4RAAAGAGlUWHRYTUw6Y29tLmFkb2JlL";
            baiduCertifyVerify(baiDuAiFaceCertifyVerifyRequest);

            Console.WriteLine("***********************************************************************");
            Console.WriteLine("************************检查认证流程 end ******************************");
        }

        /// <summary>
        /// 检查短信服务流程
        /// </summary>
        static void checkSms() {

            Console.WriteLine("***********************************************************************");
            Console.WriteLine("************************检查短信服务流程 start ************************");
            String custom_id = System.Guid.NewGuid().ToString("N");
            String phone = "";

            //发送短信验证码
            String uuid = smsAuthCode(custom_id, phone);
            if (uuid != null)
            {
                Console.WriteLine("**************************请输入验证码*****************************");
                String auth_code = Console.ReadLine();
                //验证-短信验证码
                smsValidAuthCode(uuid, auth_code, phone);
            }

            //待签署短信通知
            smsNotice("测试个人用户", "测试个人合同", phone, SmsType.LOADING_SIGN);

            //签署完成短信通知
            smsNotice("测试个人用户", "测试个人合同", phone, SmsType.SIGN_FINISH);
            Console.WriteLine("***********************************************************************");
            Console.WriteLine("************************检查短信服务流程 end **************************");
        }

        /// <summary>
        /// 个人聚合接口
        /// </summary>
        static void checkMergesPersonal()
        {
          

            //个人用户、证书注册
            string userId = personalCertRegister();

            //印章、文件添加
            string sealId = addSealFile("D:\\seal\\seal.png", "seal.png", userId);

            //合同、文件添加
            string contractId = addContractFile("D:\\contract\\G1box.pdf", "G1box.pdf", userId);

            //异步渲染合同
            renderContract(contractId);

            //模板、文件添加
            string templateId = addTemplateFile("D:\\tel\\tel.pdf", "tel.pdf", userId);

            //签章流程
            checkSign(userId, sealId, contractId, templateId, null);

        }

        /// <summary>
        /// 企业聚合接口
        /// </summary>
        static void checkMergesCompany()
        {
            //企业用户、证书注册
            string userId = companyCertRegister();

            //印章、文件添加
            string sealId = addSealFile("D:\\seal\\seal.png", "seal.png", userId);

            //合同、文件添加
            string contractId = addContractFile("D:\\contract\\G1box.pdf", "G1box.pdf", userId);

            //异步渲染合同
            renderContract(contractId);

            //模板、文件添加
            string templateId = addTemplateFile("D:\\tel\\tel.pdf", "tel.pdf", userId);

            //签章流程
            checkSign(userId, sealId, contractId, templateId, null);
        }


        /// <summary>
        /// 个人用户注册以及证书注册
        /// </summary>
        static string personalCertRegister()
        {
            string userId = "";
            // 初始话 客户端对象 
            SignClient client = new SignClient(baseUrl, new DictionaryTokenDataSource(), appId, appSecret);
            // 创建个人用户 begin
            PersonalRegisterRequest personalRegisterRequest = new PersonalRegisterRequest();
            personalRegisterRequest.area_code = "370000";
            personalRegisterRequest.description = "描述信息：该用户位示例用户";
            personalRegisterRequest.id_number = "370011123456712123";
            personalRegisterRequest.id_type = IdType.IDCARD;
            personalRegisterRequest.mail = "123456@sdgd.com";
            personalRegisterRequest.phone = "13711111121";
            personalRegisterRequest.user_name = "测试个人用户";
            try
            {
                PersonalRegisterResponse response = client.Personal.personalCertRegister(personalRegisterRequest);
                Console.WriteLine("个人用户以及证书注册完成：" + JSONUtil.getJsonStringFromObject(response));
                userId = response.user_id;
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
            // 创建个人用户 end
            return userId;
        }
        /// <summary>
        /// 企业用户注册以及证书注册
        /// </summary>
        static string companyCertRegister()
        {
            string userId = "";
            // 初始话 客户端对象
            SignClient client = new SignClient(baseUrl, new DictionaryTokenDataSource(), appId, appSecret);
            // 企业用户注册 begin
            try
            {
                CompanyRegisterRequest companyRegisterRequest = new CompanyRegisterRequest();
                companyRegisterRequest.user_name = "测试企业用户";
                companyRegisterRequest.area_code = "370000";
                companyRegisterRequest.unit_type = CompanyType.Company;
                companyRegisterRequest.credi_code = "11320111MA3F1JM121";
                companyRegisterRequest.legal_name = "李四";
                companyRegisterRequest.legal_id_number = "370000111111111112";
                companyRegisterRequest.legal_id_type = IdType.IDCARD;
                companyRegisterRequest.legal_phone = "13711111111";
                companyRegisterRequest.legal_email = "demo@sdgd.com";
                companyRegisterRequest.agent_name = "王五";
                companyRegisterRequest.agent_id_number = "370000111111111122";
                companyRegisterRequest.agent_id_type = IdType.IDCARD;
                companyRegisterRequest.agent_phone = "13711111111";
                companyRegisterRequest.agent_email = "demo@sdgd.com";
                companyRegisterRequest.description = "描述信息:demo code";


                CompanyRegisterResponse companyRegisterResponse = client.Company.companyCertRegister(companyRegisterRequest);
                Console.WriteLine("企业客户以及证书注册:" + JSONUtil.getJsonStringFromObject(companyRegisterResponse));
                userId = companyRegisterResponse.user_id;
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
            // 企业用户注册 end
            return userId;
        }

        static FileUploadRequest getFileUploadRequest(string filePath, string fileName, string fileType, string userId)
        {
            FileUploadRequest fileUploadRequest = new FileUploadRequest();
            FileStream fs = new FileStream(filePath, FileMode.Open);
            //获取文件大小 begin 
            long size = fs.Length;
            byte[] array = new byte[size];
            //将文件读到byte数组中
            fs.Read(array, 0, array.Length);
            fs.Close();
            //获取文件大小 end
            fileUploadRequest.fileData = array;
            fileUploadRequest.fileDataName = fs.Name;
            fileUploadRequest.fileType = fileType;
            fileUploadRequest.fileName = fileName;
            fileUploadRequest.userId = userId;
            return fileUploadRequest;
        }

        static FileUploadRequest getFileUploadRequest(string filePath, string fileName)
        {
            FileUploadRequest fileUploadRequest = new FileUploadRequest();
            FileStream fs = new FileStream(filePath, FileMode.Open);
            //获取文件大小 begin 
            long size = fs.Length;
            byte[] array = new byte[size];
            //将文件读到byte数组中
            fs.Read(array, 0, array.Length);
            fs.Close();
            //获取文件大小 end
            fileUploadRequest.fileData = array;
            fileUploadRequest.fileDataName = fs.Name;
            fileUploadRequest.fileName = fileName;
            return fileUploadRequest;
        }

        /// <summary>
        /// 添加印章以及印章文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="fileName"></param>
        /// <param name="userId"></param>
        static string addSealFile(string filePath, String fileName, string userId)
        {
            string sealId = "";
            // 初始话 客户端对象 
            SignClient client = new SignClient(baseUrl, new DictionaryTokenDataSource(), appId, appSecret);
            // 创建印章 begin
            SealFileAddRequest sealFileAddRequest = new SealFileAddRequest();
            //印章文件上传
            FileUploadRequest fileUploadRequest = getFileUploadRequest(filePath, fileName, FileType.impression, userId);
            sealFileAddRequest.fileUploadRequest = fileUploadRequest;
            // 印章请求数据 begin
            SealAddRequest sealAddRequest = new SealAddRequest();
            sealAddRequest.user_id = userId;
            sealAddRequest.seal_name = "测试印章D";
            sealAddRequest.seal_type = SealType.CORPORATE;
            sealAddRequest.size = "40*40";
            sealAddRequest.description = "备注法人章";
            sealFileAddRequest.sealAddRequest = sealAddRequest;
            // 印章请求数据 end
            try
            {
                SealAddResponse response = client.Seal.sealAdd(sealFileAddRequest);
                Console.WriteLine("印章以及文件添加完成：" + JSONUtil.getJsonStringFromObject(response));
                sealId = response.seal_id;
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
            // 创建印章 end
            return sealId;
        }
        /// <summary>
        /// 添加合同以及文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="fileName"></param>
        /// <param name="userId"></param>
        static string addContractFile(string filePath, String fileName, string userId)
        {
            string contractId = "";
            // 初始话 客户端对象 
            SignClient client = new SignClient(baseUrl, new DictionaryTokenDataSource(), appId, appSecret);
            // 创建合同以及文件 begin
            ContractFileAddRequest contractFileAddRequest = new ContractFileAddRequest();
            //合同文件上传
            FileUploadRequest fileUploadRequest = getFileUploadRequest(filePath, fileName, FileType.contract, userId);
            contractFileAddRequest.fileUploadRequest = fileUploadRequest;
            // 合同请求数据 begin
            ContractAddRequest contractAddRequest = new ContractAddRequest();
            contractAddRequest.name = "合同测试";
            contractAddRequest.user_id = userId;
            contractAddRequest.description = "这是个新加合同a";
            contractFileAddRequest.contractAddRequest = contractAddRequest;
            // 合同请求数据 end
            try
            {
                ContractAddResponse response = client.Contract.add(contractFileAddRequest);
                Console.WriteLine("合同以及文件添加完成：" + JSONUtil.getJsonStringFromObject(response));
                contractId = response.contract_id;
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
            // 创建合同以及文件 end
            return contractId;
        }
        /// <summary>
        /// 添加模板以及文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="fileName"></param>
        /// <param name="userId"></param>
        static string addTemplateFile(string filePath, String fileName, string userId)
        {
            string templateId = "";
            // 初始话 客户端对象 
            SignClient client = new SignClient(baseUrl, new DictionaryTokenDataSource(), appId, appSecret);
            // 创建模板以及文件 begin
            TemplateFileAddRequest templateFileAddRequest = new TemplateFileAddRequest();
            //模板文件上传
            FileUploadRequest fileUploadRequest = getFileUploadRequest(filePath, fileName, FileType.template, userId);
            templateFileAddRequest.fileUploadRequest = fileUploadRequest;
            // 模板请求数据 begin
            TemplateAddRequest templateAddRequest = new TemplateAddRequest();
            templateAddRequest.name = "我的模板";
            templateFileAddRequest.templateAddRequest = templateAddRequest;
            // 模板请求数据 end
            try
            {
                TemplateAddResponse response = client.Template.templateAdd(templateFileAddRequest);
                Console.WriteLine("模板以及文件添加完成：" + JSONUtil.getJsonStringFromObject(response));
                templateId = response.template_id;
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
            // 创建印章 end
            return templateId;
        }

        /// <summary>
        /// 检查个人注册以及签章流程
        /// </summary>
        static void checkPersonalSign()
        {

            //string userId = "00715155898913935360"; 
            string userId = personal();
            string certId = cert(userId);
            //添加印章文件
            string sealFileId = fileManager("D:\\seal\\seal.png", "seal.png", FileType.impression);
            //印章
            string sealId = seal(userId, sealFileId);
            //添加模板文件
            string telFileId = fileManager("D:\\tel\\tel.pdf", "tel.pdf", FileType.template);
            //模板
            string temlateId = template("测试模板", telFileId);
            //添加合同文件
            string cFileId = fileManager("D:\\contract\\G1box.pdf", "G1box.pdf", FileType.contract);
            //合同
            string contractId = contract(userId, cFileId);
            //签章流程
            checkSign(userId, sealId, contractId, temlateId, cFileId);
        }
        /// <summary>
        /// 企业用户签章流程
        /// </summary>
        static void checkCompanySign()
        {
            // string userId = "00715155898913935360";
            //企业用户注册
            string userId = company();
            //证书申请
            string certId = cert(userId);
            //添加印章文件
            string sealFileId = fileManager("D:\\seal\\seal.png", "seal.png", FileType.impression);
            //印章
            string sealId = seal(userId, sealFileId);
            //添加模板文件
            string telFileId = fileManager("D:\\tel\\tel.pdf", "tel.pdf", FileType.template);
            //模板
            string temlateId = template("测试模板", telFileId);
            //添加合同文件
            string cFileId = fileManager("D:\\contract\\G1box.pdf", "G1box.pdf", FileType.contract);
            //合同
            string contractId = contract(userId, cFileId);
            //签章流程
            checkSign(userId, sealId, contractId, temlateId, cFileId);
        }

        /// <summary>
        /// 签章所有流程
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="sealId"></param>
        /// <param name="contractId"></param>
        /// <param name="temlateId"></param>
        /// <param name="fileId"></param>
        static void checkSign(string userId, string sealId, string contractId, string temlateId, string fileId)
        {
            //单次模板签章
            singleTemplate(temlateId, userId, sealId);
            //批量模板签章
            batchTemplate(temlateId, "123456", userId, sealId);
            //合同坐标签章
            signCommon(contractId, userId, sealId);
            //关键字签章
            keywordSign(contractId, userId, sealId);
            //会签
            meet(contractId, userId, sealId);
            //扫码合同
            string scanId = scanContract(userId, contractId, sealId, "http://www.sss.com", "2021-08-20 10:22:22");
            //扫码签章
            scanSign(scanId);

            //事件证书-单次模板签章
            eventCertSingleTemplate(temlateId, userId, sealId);
            //事件证书-批量模板签章
            eventCertBatchTemplate(temlateId, "123456", userId, sealId);
            //事件证书-合同坐标签章
            eventCertSignCommon(contractId, userId, sealId);
            //事件证书-关键字签章
            eventCertKeywordSign(contractId, userId, sealId);
            //事件证书-会签
            eventCertMeet(contractId, userId, sealId);
            //事件证书-扫码合同
            string eventCertScanId = eventCertScanContract(userId, contractId, sealId, "http://www.sss.com", "2021-08-20 10:22:22");
            //事件证书-扫码签章
            eventScanSign(eventCertScanId);


            if (fileId == null)
            {
                return;
            }
            //文件Id验章
            checkSignCommon(fileId);
            //文件验章
            checkSignFile("D:\\check\\我的合同.pdf", "我的合同.pdf");
        }

        /// <summary>
        /// 根据文件Id验章
        /// </summary>
        /// <param name="fileId"></param>
        static void checkSignCommon(string fileId)
        {
            // 初始话 客户端对象
            SignClient client = new SignClient(baseUrl, new DictionaryTokenDataSource(), appId, appSecret);
            //单模板签章 start
            //try
            //{
            //    SignTemplateSingleRequest signTemplateSingleRequest = new SignTemplateSingleRequest();
            //    signTemplateSingleRequest.template_id = "ee22532202a9c177f654efea435f1af7";
            //    TextParams textParams = new TextParams();
            //    textParams.key = "fill_1";
            //    textParams.value = "测试李";
            //    //signTemplateSingleRequest.sign_field.text_params.Add();
            //    SignField signField = new SignField();
            //    List<TextParams> list = new List<TextParams>();
            //    list.Add(textParams);
            //    signField.text_params = list;
            //    SignParams signParms = new SignParams();
            //    signParms.height = 20;
            //    signParms.seal_id = "7f8b15ad1b58010a6007f27972deeb3d";
            //    signParms.sign_key = "signature1";
            //    signParms.user_id = "00719955282721656832";
            //    signParms.width = 20;
            //    List<SignParams> signList = new List<SignParams>();
            //    signList.Add(signParms);
            //    signField.sign_params = signList;
            //    signTemplateSingleRequest.sign_field = signField;
            //    SignTemplateSingleResponse signTemplateSingleResponse= client.SignOperate.signTemplateSingle(signTemplateSingleRequest);
            //    Console.WriteLine("单模板签章:" + JSONUtil.getJsonStringFromObject(signTemplateSingleResponse));

            //}
            //catch (SignApplicationException sae)
            //{
            //    // 捕获网关校验数据
            //    Console.WriteLine("网关异常状态码为：" + sae.return_code);
            //    Console.WriteLine("网关异常信息为：" + sae.return_message);
            //}
            //catch (SignServerException sse)
            //{
            //    // 捕获网关校验数据
            //    Console.WriteLine("业务异常状态码为：" + sse.result_code);
            //    Console.WriteLine("业务异常信息为：" + sse.result_message);
            //}
            // 单模板签章 end
            // 批量模板签章 start
            try
            {
                SignTemplateBatchRequest signTemplateBatchRequest = new SignTemplateBatchRequest();
                BatchTemplates batchTemplates = new BatchTemplates();
                signTemplateBatchRequest.template_id = "ee22532202a9c177f654efea435f1af7";
                TextParamsB textParams = new TextParamsB();
                textParams.key = "fill_1";
                textParams.value = "ceshi BB";
                List<TextParamsB> listTest = new List<TextParamsB>();
                listTest.Add(textParams);
                SignParamsB signParms = new SignParamsB();
                signParms.height = 13;
                signParms.seal_id = "ac3364266bd7cbd35de79e2018fa0e86";
                signParms.sign_key = "signature1";
                signParms.user_id = "00719956291565015040";
                signParms.width = 13;
                List<SignParamsB> list = new List<SignParamsB>();
                list.Add(signParms);
                batchTemplates.sign_params = list;
                batchTemplates.text_params = listTest;
                batchTemplates.custom_id = "5646546546";



                signTemplateBatchRequest.addBatchTempLate(batchTemplates);
                SignTemplateBatchResponse signTemplateBatchResponse = client.SignOperate.signTemplateBatch(signTemplateBatchRequest);
                Console.WriteLine("批量模板签章:" + JSONUtil.getJsonStringFromObject(signTemplateBatchResponse));

            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
            // 批量模板签章 end
            // 合同坐标签章 start
            //try
            //{
            //    SignCommonRequest signCommonRequest = new SignCommonRequest();
            //    signCommonRequest.contract_id = "";
            //    Fields fields = new Fields();
            //    fields.height = 00;
            //    fields.horizontal = 0;
            //    fields.page_number = 0;
            //    fields.seal_id = "";
            //    fields.vertical = 00;
            //    fields.width = 00;
            //    signCommonRequest.fields.Add(fields);
            //    signCommonRequest.remark = "";
            //    signCommonRequest.user_id = "";
            //    SignCommonResponse signCommonResponse = client.SignOperate.signCommon(signCommonRequest);
            //    Console.WriteLine("合同坐标签章:" + JSONUtil.getJsonStringFromObject(signCommonResponse));

            //}
            //catch (SignApplicationException sae)
            //{
            //    // 捕获网关校验数据
            //    Console.WriteLine("网关异常状态码为：" + sae.return_code);
            //    Console.WriteLine("网关异常信息为：" + sae.return_message);
            //}
            //catch (SignServerException sse)
            //{
            //    // 捕获网关校验数据
            //    Console.WriteLine("业务异常状态码为：" + sse.result_code);
            //    Console.WriteLine("业务异常信息为：" + sse.result_message);
            //}
            // 合同坐标签章 end
            // 关键字签章接口 start
            //try
            //{
            //    SignKeywordSignRequest signKeywordSignRequest = new SignKeywordSignRequest();
            //    signKeywordSignRequest.contract_id = "";
            //    signKeywordSignRequest.height = 00;
            //    signKeywordSignRequest.keyword = "";
            //    signKeywordSignRequest.seal_id = "";
            //    signKeywordSignRequest.sign_all = false;
            //    signKeywordSignRequest.user_id = "";
            //    SignKeywordSignResponse signKeywordSignResponse = client.SignOperate.keywordSign(signKeywordSignRequest);
            //    Console.WriteLine("关键字签章:" + JSONUtil.getJsonStringFromObject(signKeywordSignResponse));

            //}
            //catch (SignApplicationException sae)
            //{
            //    // 捕获网关校验数据
            //    Console.WriteLine("网关异常状态码为：" + sae.return_code);
            //    Console.WriteLine("网关异常信息为：" + sae.return_message);
            //}
            //catch (SignServerException sse)
            //{
            //    // 捕获网关校验数据
            //    Console.WriteLine("业务异常状态码为：" + sse.result_code);
            //    Console.WriteLine("业务异常信息为：" + sse.result_message);
            //}
            // 关键字签章接口 end
            // 会签接口 start
            //try
            //{
            //    SignMeetingSingleRequest signMeetingSingleRequest = new SignMeetingSingleRequest();
            //    signMeetingSingleRequest.contract_id = "";
            //    SignDetails signDetails = new SignDetails();
            //    signDetails.page_num = 0;
            //    signDetails.seal_id = "";
            //    signDetails.sign_height = 0;
            //    signDetails.sign_left = 0;
            //    signDetails.sign_top = 0;
            //    signDetails.sign_width = 00;
            //    signDetails.user_id = "";
            //    signMeetingSingleRequest.sign_details.Add(signDetails);
            //    SignMeetingSingleResponse signKeywordSignResponse = client.SignOperate.meetingSingle(signMeetingSingleRequest);
            //    Console.WriteLine("会签:" + JSONUtil.getJsonStringFromObject(signKeywordSignResponse));

            //}
            //catch (SignApplicationException sae)
            //{
            //    // 捕获网关校验数据
            //    Console.WriteLine("网关异常状态码为：" + sae.return_code);
            //    Console.WriteLine("网关异常信息为：" + sae.return_message);
            //}
            //catch (SignServerException sse)
            //{
            //    // 捕获网关校验数据
            //    Console.WriteLine("业务异常状态码为：" + sse.result_code);
            //    Console.WriteLine("业务异常信息为：" + sse.result_message);
            //}
            // 会签 end
            //根据文件Id验章 start
            try
            {
                SignCheckCommonResponse signCheckCommonResponse = client.SignCheck.CheckCommon(new SignCheckCommonRequest(fileId));
                Console.WriteLine("文件Id验章:" + JSONUtil.getJsonStringFromObject(signCheckCommonResponse));

            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
            //根据文件Id验章 end
        }
        /// <summary>
        /// 文件验章
        /// </summary>
        /// <param name="filePath"></param>
        static void checkSignFile(string filePath, string fileName)
        {
            SignClient client = new SignClient(baseUrl, new DictionaryTokenDataSource(), appId, appSecret);
            FileUploadRequest fileUploadRequest = getFileUploadRequest(filePath, fileName);
            SignCheckFileRequest signCheckFileRequest = new SignCheckFileRequest();
            signCheckFileRequest.fileData = fileUploadRequest.fileData;
            signCheckFileRequest.fileDataName = fileUploadRequest.fileDataName;
            //文件验章 start
            try
            {
                SignCheckFileResponse signCheckFileResponse = client.SignCheck.CheckFile(signCheckFileRequest);
                Console.WriteLine("文件验章:" + JSONUtil.getJsonStringFromObject(signCheckFileResponse));

            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
            //文件验章 end
        }

        /// <summary>
        /// 单模板签章
        /// </summary>
        /// <param name="templateId"></param>
        /// <param name="userId"></param>
        /// <param name="sealId"></param>
        static string singleTemplate(string templateId, string userId, string sealId)
        {
            string fileId = "";
            // 初始话 客户端对象
            SignClient client = new SignClient(baseUrl, new DictionaryTokenDataSource(), appId, appSecret);
            SignTemplateSingleRequest signTemplateSingleRequest = new SignTemplateSingleRequest();
            signTemplateSingleRequest.template_id = templateId;

            List<SignParams> signParams = new List<SignParams>();
            SignParams param = new SignParams();
            param.height = 50;
            param.width = 50;
            param.user_id = userId;
            param.seal_id = sealId;
            param.sign_key = "sign";
            signParams.Add(param);

            TextParams textParam = new TextParams();
            textParam.key = "name";
            textParam.value = "单测试";
            List<TextParams> textParams = new List<TextParams>();
            textParams.Add(textParam);

            SignField signField = new SignField();
            signField.sign_params = signParams;
            signField.text_params = textParams;
            signTemplateSingleRequest.sign_field = signField;
            //模板单 签章 start
            try
            {
                SignTemplateSingleResponse signTemplateSingleResponse = client.SignOperate.signTemplateSingle(signTemplateSingleRequest);
                Console.WriteLine("单次模板签章:" + JSONUtil.getJsonStringFromObject(signTemplateSingleResponse));
                fileId = signTemplateSingleResponse.file_id;
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
            //扫码合同添加 end
            return fileId;
        }

        /// <summary>
        /// 批量模板 签章
        /// </summary>
        /// <param name="templateId"></param>
        /// <param name="userId"></param>
        /// <param name="sealId"></param>
        static void batchTemplate(string templateId, string customId, string userId, string sealId)
        {
            // 初始话 客户端对象
            SignClient client = new SignClient(baseUrl, new DictionaryTokenDataSource(), appId, appSecret);
            SignTemplateBatchRequest signTemplateBatchRequest = new SignTemplateBatchRequest();
            signTemplateBatchRequest.template_id = templateId;
            BatchTemplates batchTemplates = new BatchTemplates();
            batchTemplates.custom_id = customId;

            List<SignParamsB> signParams = new List<SignParamsB>();
            SignParamsB param = new SignParamsB();
            param.height = 50;
            param.width = 50;
            param.user_id = userId;
            param.seal_id = sealId;
            param.sign_key = "sign";
            signParams.Add(param);

            TextParamsB textParam = new TextParamsB();
            textParam.key = "day2";
            textParam.value = "批量测试";
            List<TextParamsB> textParams = new List<TextParamsB>();
            textParams.Add(textParam);


            batchTemplates.sign_params = signParams;
            batchTemplates.text_params = textParams;

            List<BatchTemplates> templates = new List<BatchTemplates>();
            templates.Add(batchTemplates);
            signTemplateBatchRequest.batch_templates = templates;

            //批量签章 start
            try
            {
                SignTemplateBatchResponse signTemplateBatchResponse = client.SignOperate.signTemplateBatch(signTemplateBatchRequest);
                Console.WriteLine("批量签章:" + JSONUtil.getJsonStringFromObject(signTemplateBatchResponse));

            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
            //批量签章 end

        }
        /// <summary>
        /// 合同坐标签章接口
        /// </summary>
        /// <param name="contractId"></param>
        /// <param name="userId"></param>
        /// <param name="sealId"></param>
        static void signCommon(string contractId, string userId, String sealId)
        {
            // 初始话 客户端对象
            SignClient client = new SignClient(baseUrl, new DictionaryTokenDataSource(), appId, appSecret);
            SignCommonRequest signCommonRequest = new SignCommonRequest();
            signCommonRequest.contract_id = contractId;
            signCommonRequest.user_id = userId;
            signCommonRequest.remark = "坐标签章";
            List<sign_sdk_net.entity.request.sign.Fields> fields = new List<sign_sdk_net.entity.request.sign.Fields>();
            sign_sdk_net.entity.request.sign.Fields field = new sign_sdk_net.entity.request.sign.Fields();
            field.height = 40;
            field.width = 40;
            field.horizontal = 30;
            field.vertical = 30;
            field.page_number = 2;
            field.seal_id = sealId;
            fields.Add(field);
            signCommonRequest.fields = fields;
            //合同坐标签章接口 start
            try
            {
                SignCommonResponse signCommonResponse = client.SignOperate.signCommon(signCommonRequest);
                Console.WriteLine("合同坐标签章:" + JSONUtil.getJsonStringFromObject(signCommonResponse));
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
            //合同坐标签章接口 end
        }
        /// <summary>
        /// 关键字签章接口
        /// </summary>
        /// <param name="contractId"></param>
        /// <param name="userId"></param>
        /// <param name="sealId"></param>
        static void keywordSign(string contractId, string userId, String sealId)
        {
            // 初始话 客户端对象
            SignClient client = new SignClient(baseUrl, new DictionaryTokenDataSource(), appId, appSecret);
            SignKeywordSignRequest signKeywordSignRequest = new SignKeywordSignRequest();
            signKeywordSignRequest.contract_id = contractId;
            signKeywordSignRequest.keyword = "测试";
            signKeywordSignRequest.seal_id = sealId;
            signKeywordSignRequest.sign_all = false;
            signKeywordSignRequest.user_id = userId;
            signKeywordSignRequest.width = 50;
            signKeywordSignRequest.height = 50;
            //"关键字签章接口 start
            try
            {
                SignKeywordSignResponse signKeywordSignResponse = client.SignOperate.keywordSign(signKeywordSignRequest);
                Console.WriteLine("关键字签章:" + JSONUtil.getJsonStringFromObject(signKeywordSignResponse));
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
            //关键字签章接口 end
        }

        /// <summary>
        /// 会签接口
        /// </summary>
        /// <param name="contractId"></param>
        /// <param name="userId"></param>
        /// <param name="sealId"></param>
        static void meet(string contractId, string userId, String sealId)
        {
            // 初始话 客户端对象
            SignClient client = new SignClient(baseUrl, new DictionaryTokenDataSource(), appId, appSecret);
            SignMeetingSingleRequest signMeetingSingleRequest = new SignMeetingSingleRequest();
            signMeetingSingleRequest.contract_id = contractId;
            List<SignDetails> signDetails = new List<SignDetails>();
            SignDetails sign = new SignDetails();
            sign.page_num = 1;
            sign.seal_id = sealId;
            sign.user_id = userId;
            sign.sign_height = 40;
            sign.sign_width = 50;
            sign.sign_top = 10;
            sign.sign_left = 20;
            signDetails.Add(sign);
            signMeetingSingleRequest.sign_details = signDetails;
            //会签接口 start
            try
            {
                SignMeetingSingleResponse signMeetingSingleResponse = client.SignOperate.meetingSingle(signMeetingSingleRequest);
                Console.WriteLine("会签:" + JSONUtil.getJsonStringFromObject(signMeetingSingleResponse));
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
            //合同坐标签章接口 end
        }

        /// <summary>
        /// 扫码签章接口
        /// </summary>
        /// <param name="contractId"></param>
        /// <param name="userId"></param>
        /// <param name="sealId"></param>
        static void scanSign(string prepareId)
        {
            // 初始话 客户端对象
            SignClient client = new SignClient(baseUrl, new DictionaryTokenDataSource(), appId, appSecret);
            //扫码签章接口 start
            try
            {
                SignScanContractResponse signScanContractResponse = client.SignOperate.scanSign(new SignScanContractRequest(prepareId));
                Console.WriteLine("扫码签章:" + JSONUtil.getJsonStringFromObject(signScanContractResponse));
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
            //扫码签章接口 end
        }

        /// <summary>
        /// 事件证书-扫码签章接口
        /// </summary>
        /// <param name="contractId"></param>
        /// <param name="userId"></param>
        /// <param name="sealId"></param>
        static void eventScanSign(string prepareId)
        {
            // 初始话 客户端对象
            SignClient client = new SignClient(baseUrl, new DictionaryTokenDataSource(), appId, appSecret);
            //扫码签章接口 start
            try
            {
                EventCertSignScanContractResponse eventCertSignScanContractResponse = client.SignOperate.eventCertScanSign(new SignScanContractRequest(prepareId));
                Console.WriteLine("事件证书-扫码签章:" + JSONUtil.getJsonStringFromObject(eventCertSignScanContractResponse));
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
            //扫码签章接口 end
        }


        /// <summary>
        /// 事件证书-单模板签章
        /// </summary>
        /// <param name="templateId"></param>
        /// <param name="userId"></param>
        /// <param name="sealId"></param>
        static string eventCertSingleTemplate(string templateId, string userId, string sealId)
        {
            string fileId = "";
            // 初始话 客户端对象
            SignClient client = new SignClient(baseUrl, new DictionaryTokenDataSource(), appId, appSecret);
            EventCertSignTemplateSingleRequest signTemplateSingleRequest = new EventCertSignTemplateSingleRequest();
            signTemplateSingleRequest.template_id = templateId;

            List<EventCertSignParams> signParams = new List<EventCertSignParams>();
            EventCertSignParams param = new EventCertSignParams();
            param.height = 50;
            param.width = 50;
            param.user_id = userId;
            param.seal_id = sealId;
            param.sign_key = "sign";
            signParams.Add(param);

            EventCertTextParams textParam = new EventCertTextParams();
            textParam.key = "name";
            textParam.value = "单测试";
            List<EventCertTextParams> textParams = new List<EventCertTextParams>();
            textParams.Add(textParam);

            EventCertSignField signField = new EventCertSignField();
            signField.sign_params = signParams;
            signField.text_params = textParams;
            signTemplateSingleRequest.sign_field = signField;
            //模板单 签章 start
            try
            {
                EventCertSignTemplateSingleResponse signTemplateSingleResponse = client.SignOperate.eventCertSignTemplateSingle(signTemplateSingleRequest);
                Console.WriteLine("事件证书-单次模板签章:" + JSONUtil.getJsonStringFromObject(signTemplateSingleResponse));
                fileId = signTemplateSingleResponse.file_id;
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
            //扫码合同添加 end
            return fileId;
        }

        /// <summary>
        /// 事件证书-批量模板 签章
        /// </summary>
        /// <param name="templateId"></param>
        /// <param name="userId"></param>
        /// <param name="sealId"></param>
        static void eventCertBatchTemplate(string templateId, string customId, string userId, string sealId)
        {
            // 初始话 客户端对象
            SignClient client = new SignClient(baseUrl, new DictionaryTokenDataSource(), appId, appSecret);
            EventCertSignTemplateBatchRequest signTemplateBatchRequest = new EventCertSignTemplateBatchRequest();
            signTemplateBatchRequest.template_id = templateId;
            EventCertBatchTemplates batchTemplates = new EventCertBatchTemplates();
            batchTemplates.custom_id = customId;

            List<EventCertSignParams> signParams = new List<EventCertSignParams>();
            EventCertSignParams param = new EventCertSignParams();
            param.height = 50;
            param.width = 50;
            param.user_id = userId;
            param.seal_id = sealId;
            param.sign_key = "sign";
            signParams.Add(param);

            EventCertTextParams textParam = new EventCertTextParams();
            textParam.key = "day2";
            textParam.value = "批量测试";
            List<EventCertTextParams> textParams = new List<EventCertTextParams>();
            textParams.Add(textParam);


            batchTemplates.sign_params = signParams;
            batchTemplates.text_params = textParams;

            List<EventCertBatchTemplates> templates = new List<EventCertBatchTemplates>();
            templates.Add(batchTemplates);
            signTemplateBatchRequest.batch_templates = templates;

            //批量签章 start
            try
            {
                EventCertSignTemplateBatchResponse signTemplateBatchResponse = client.SignOperate.eventCertSignTemplateBatch(signTemplateBatchRequest);
                Console.WriteLine("事件证书-批量签章:" + JSONUtil.getJsonStringFromObject(signTemplateBatchResponse));

            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
            //批量签章 end

        }
        /// <summary>
        /// 事件证书-合同坐标签章接口
        /// </summary>
        /// <param name="contractId"></param>
        /// <param name="userId"></param>
        /// <param name="sealId"></param>
        static void eventCertSignCommon(string contractId, string userId, String sealId)
        {
            // 初始话 客户端对象
            SignClient client = new SignClient(baseUrl, new DictionaryTokenDataSource(), appId, appSecret);
            SignCommonRequest signCommonRequest = new SignCommonRequest();
            signCommonRequest.contract_id = contractId;
            signCommonRequest.user_id = userId;
            signCommonRequest.remark = "坐标签章";
            List<sign_sdk_net.entity.request.sign.Fields> fields = new List<sign_sdk_net.entity.request.sign.Fields>();
            sign_sdk_net.entity.request.sign.Fields field = new sign_sdk_net.entity.request.sign.Fields();
            field.height = 40;
            field.width = 40;
            field.horizontal = 30;
            field.vertical = 30;
            field.page_number = 2;
            field.seal_id = sealId;
            fields.Add(field);
            signCommonRequest.fields = fields;
            //合同坐标签章接口 start
            try
            {
                EventCertSignCommonResponse signCommonResponse = client.SignOperate.eventCertSignCommon(signCommonRequest);
                Console.WriteLine("合同坐标签章:" + JSONUtil.getJsonStringFromObject(signCommonResponse));
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
            //合同坐标签章接口 end
        }
        /// <summary>
        /// 事件证书-关键字签章接口
        /// </summary>
        /// <param name="contractId"></param>
        /// <param name="userId"></param>
        /// <param name="sealId"></param>
        static void eventCertKeywordSign(string contractId, string userId, String sealId)
        {
            // 初始话 客户端对象
            SignClient client = new SignClient(baseUrl, new DictionaryTokenDataSource(), appId, appSecret);
            SignKeywordSignRequest signKeywordSignRequest = new SignKeywordSignRequest();
            signKeywordSignRequest.contract_id = contractId;
            signKeywordSignRequest.keyword = "测试";
            signKeywordSignRequest.seal_id = sealId;
            signKeywordSignRequest.sign_all = false;
            signKeywordSignRequest.user_id = userId;
            signKeywordSignRequest.width = 50;
            signKeywordSignRequest.height = 50;
            //"关键字签章接口 start
            try
            {
                EventCertSignKeywordSignResponse signKeywordSignResponse = client.SignOperate.eventCertKeywordSign(signKeywordSignRequest);
                Console.WriteLine("事件证书-关键字签章:" + JSONUtil.getJsonStringFromObject(signKeywordSignResponse));
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
            //关键字签章接口 end
        }

        /// <summary>
        /// 事件证书-会签接口
        /// </summary>
        /// <param name="contractId"></param>
        /// <param name="userId"></param>
        /// <param name="sealId"></param>
        static void eventCertMeet(string contractId, string userId, String sealId)
        {
            // 初始话 客户端对象
            SignClient client = new SignClient(baseUrl, new DictionaryTokenDataSource(), appId, appSecret);
            SignMeetingSingleRequest signMeetingSingleRequest = new SignMeetingSingleRequest();
            signMeetingSingleRequest.contract_id = contractId;
            List<SignDetails> signDetails = new List<SignDetails>();
            SignDetails sign = new SignDetails();
            sign.page_num = 1;
            sign.seal_id = sealId;
            sign.user_id = userId;
            sign.sign_height = 40;
            sign.sign_width = 50;
            sign.sign_top = 10;
            sign.sign_left = 20;
            signDetails.Add(sign);
            signMeetingSingleRequest.sign_details = signDetails;
            //会签接口 start
            try
            {
                EventCertSignMeetingSingleResponse signMeetingSingleResponse = client.SignOperate.eventCertMeetingSingle(signMeetingSingleRequest);
                Console.WriteLine("事件证书-会签:" + JSONUtil.getJsonStringFromObject(signMeetingSingleResponse));
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
            //合同坐标签章接口 end
        }

        /// <summary>
        /// 事件证书-扫码签章接口
        /// </summary>
        /// <param name="contractId"></param>
        /// <param name="userId"></param>
        /// <param name="sealId"></param>
        static void eventCertScanSign(string prepareId)
        {
            // 初始话 客户端对象
            SignClient client = new SignClient(baseUrl, new DictionaryTokenDataSource(), appId, appSecret);
            //扫码签章接口 start
            try
            {
                EventCertSignScanContractResponse signScanContractResponse = client.SignOperate.eventCertScanSign(new SignScanContractRequest(prepareId));
                Console.WriteLine("事件证书-扫码签章:" + JSONUtil.getJsonStringFromObject(signScanContractResponse));
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
            //扫码签章接口 end
        }



        /// <summary>
        /// 扫码合同
        /// </summary>
        static string scanContract(string userId, string contractId, string sealId, string url, string expire_time)
        {
            string prepare_id = "";
            // 初始话 客户端对象
            SignClient client = new SignClient(baseUrl, new DictionaryTokenDataSource(), appId, appSecret);
            ScanContractAddRequest scanContractAddRequest = new ScanContractAddRequest();
            scanContractAddRequest.contract_id = contractId;
            scanContractAddRequest.user_id = userId;
            scanContractAddRequest.expire_time = expire_time;
            scanContractAddRequest.remark = "无数据";
            scanContractAddRequest.qr_code_width = 125;
            scanContractAddRequest.qr_code_height = 125;
            scanContractAddRequest.url = url;
            List<ScanContractAddRequest.Fields> fields = new List<ScanContractAddRequest.Fields>();
            ScanContractAddRequest.Fields field = new ScanContractAddRequest.Fields();
            field.height = 50;
            field.width = 50;
            field.horizontal = 40;
            field.page_number = 1;
            field.vertical = 40;
            field.seal_id = sealId;
            fields.Add(field);
            scanContractAddRequest.fields = fields;
            //扫码合同添加 start
            try
            {
                ScanContractAddResonse scanContractAddResonse = client.ScanContract.add(scanContractAddRequest);
                Console.WriteLine("扫码合同添加:" + JSONUtil.getJsonStringFromObject(scanContractAddResonse));
                prepare_id = scanContractAddResonse.prepare_id;
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
            //扫码合同添加 end

            //扫码合同查询 start
            try
            {
                ScanContractQueryResonse scanContractQueryResonse = client.ScanContract.query(new ScanContractQueryRequest(prepare_id));
                Console.WriteLine("扫码合同查询:" + JSONUtil.getJsonStringFromObject(scanContractQueryResonse));
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
            //扫码合同查询 end
            return prepare_id;
        }

        /// <summary>
        /// 事件证书-扫码合同
        /// </summary>
        static string eventCertScanContract(string userId, string contractId, string sealId, string url, string expire_time)
        {
            string prepare_id = "";
            // 初始话 客户端对象
            SignClient client = new SignClient(baseUrl, new DictionaryTokenDataSource(), appId, appSecret);
            ScanContractAddRequest scanContractAddRequest = new ScanContractAddRequest();
            scanContractAddRequest.contract_id = contractId;
            scanContractAddRequest.user_id = userId;
            scanContractAddRequest.expire_time = expire_time;
            scanContractAddRequest.remark = "无数据";
            scanContractAddRequest.qr_code_width = 125;
            scanContractAddRequest.qr_code_height = 125;
            scanContractAddRequest.url = url;
            List<ScanContractAddRequest.Fields> fields = new List<ScanContractAddRequest.Fields>();
            ScanContractAddRequest.Fields field = new ScanContractAddRequest.Fields();
            field.height = 50;
            field.width = 50;
            field.horizontal = 40;
            field.page_number = 1;
            field.vertical = 40;
            field.seal_id = sealId;
            fields.Add(field);
            scanContractAddRequest.fields = fields;
            //事件证书-扫码合同添加 start
            try
            {
                ScanContractAddResonse scanContractAddResonse = client.EventCertScanContract.add(scanContractAddRequest);
                Console.WriteLine("事件证书-扫码合同添加:" + JSONUtil.getJsonStringFromObject(scanContractAddResonse));
                prepare_id = scanContractAddResonse.prepare_id;
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
            //事件证书-扫码合同添加 end
            return prepare_id;
        }


        static void renderContract(string contractId)
        {
            SignClient client = new SignClient(baseUrl, new DictionaryTokenDataSource(), appId, appSecret);
            //异步合同渲染 start
            try
            {
                ContractRenderResponse contractRenderResponse = client.Contract.render(new ContractRenderRequest(contractId));
                Console.WriteLine("异步合同渲染:" + JSONUtil.getJsonStringFromObject(contractRenderResponse));
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
            //异步合同渲染end
        }

        /// <summary>
        /// 合同管理
        /// </summary>
        static string contract(string userId, string fileId)
        {
            string contractId = "";
            // 初始话 客户端对象
            SignClient client = new SignClient(baseUrl, new DictionaryTokenDataSource(), appId, appSecret);
            ContractAddResponse contractAddResponse = new ContractAddResponse();
            //合同添加 start
            try
            {
                ContractAddRequest contractAddRequest = new ContractAddRequest();
                contractAddRequest.file_id = fileId;
                contractAddRequest.name = "合同测试";
                contractAddRequest.user_id = userId;
                contractAddRequest.description = "这是个新加合同a";
                contractAddResponse = client.Contract.add(contractAddRequest);
                Console.WriteLine("模板添加:" + JSONUtil.getJsonStringFromObject(contractAddResponse));
                contractId = contractAddResponse.contract_id;
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
            //合同添加end
            //合同查询 start
            try
            {
                ContractQueryResponse contractQueryResponse = client.Contract.query(new ContractQueryRequest(contractId));
                Console.WriteLine("模板详情:" + JSONUtil.getJsonStringFromObject(contractQueryResponse));
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
            //合同查询end


            //异步合同渲染 start
            try
            {
                ContractRenderResponse contractRenderResponse = client.Contract.render(new ContractRenderRequest(contractId));
                Console.WriteLine("异步合同渲染:" + JSONUtil.getJsonStringFromObject(contractRenderResponse));
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
            //异步合同渲染end

            //合同删除 start
            try
            {
                ContractRemoveResponse contractRemoveResponse = client.Contract.remove(new ContractRemoveRequest("312321"));
                Console.WriteLine("模板删除:" + JSONUtil.getJsonStringFromObject(contractRemoveResponse));
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
            //合同删除end
            return contractId;
        }
        /// <summary>
        /// 作废合同
        /// </summary>
        /// <param name="sign_id"></param>
        /// <param name="user_id"></param>
        /// <returns></returns>
        static string abolishContract(string sign_id, string user_id)
        {
            String fileId = "";
            // 初始话 客户端对象
            SignClient client = new SignClient(baseUrl, new DictionaryTokenDataSource(), appId, appSecret);
            //合同作废 start
            ContractAbolishResponse contractAbolishResponse = new ContractAbolishResponse();
            try
            {
                ContractAbolishRequest contractAbolishRequest = new ContractAbolishRequest(sign_id, user_id);
                contractAbolishResponse = client.Contract.abolish(contractAbolishRequest);
                Console.WriteLine("合同作废:" + JSONUtil.getJsonStringFromObject(contractAbolishResponse));
                fileId = contractAbolishResponse.file_id;
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
            return fileId;
        }

        /// <summary>
        /// 模板管理
        /// </summary>
        static string template(string name, string fileId)
        {
            String templateId = "";
            // 初始话 客户端对象
            SignClient client = new SignClient(baseUrl, new DictionaryTokenDataSource(), appId, appSecret);
            //模板添加 start
            TemplateAddResponse templateAddResponse = new TemplateAddResponse();
            try
            {
                TemplateAddRequest templateAddRequest = new TemplateAddRequest();
                templateAddRequest.file_id = fileId;
                templateAddRequest.name = name;
                templateAddResponse = client.Template.templateAdd(templateAddRequest);
                Console.WriteLine("模板添加:" + JSONUtil.getJsonStringFromObject(templateAddResponse));
                templateId = templateAddResponse.template_id;
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
            //模板添加end

            //模板查询 start
            try
            {
                TemplateQueryResponse templateQueryResponse = client.Template.templateQuery(new TemplateQueryRequest(templateId));
                Console.WriteLine("模板查询:" + JSONUtil.getJsonStringFromObject(templateQueryResponse));

            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
            //模板查询 end

            //模板锁定 start
            try
            {
                TemplateLockResponse templateLockResponse = client.Template.templateLock(new TemplateLockRequest(templateId));
                Console.WriteLine("模板锁定:" + JSONUtil.getJsonStringFromObject(templateLockResponse));

            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
            //模板锁定 end

            //模板解锁 start
            try
            {
                TemplateUnlockResponse templateUnlResponse = client.Template.templateUnlock(new TemplateUnlockRequest(templateId));
                Console.WriteLine("模板解锁:" + JSONUtil.getJsonStringFromObject(templateUnlResponse));

            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
            //模板解锁 end

            //模板删除 start
            try
            {
                TemplateDelResponse templateDelResponse = client.Template.templateDelete(new TemplateDelRequest("312312"));
                Console.WriteLine("模板删除:" + JSONUtil.getJsonStringFromObject(templateDelResponse));

            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
            //模板删除 end
            return templateId;
        }

        /// <summary>
        /// 短信通知 操作
        /// </summary>
        /// <param name="user_name"></param>
        /// <param name="contract_name"></param>
        /// <param name="phone"></param>
        /// <param name="sms_type"></param>
        /// <returns></returns>
        static void smsNotice(string user_name, string contract_name, string phone, string sms_type)
        {
            // 初始话 客户端对象
            SignClient client = new SignClient(baseUrl, new DictionaryTokenDataSource(), appId, appSecret);
            //单次短信添加 start
            SmsSingleResponse smsSingleResponse = new SmsSingleResponse();
            try
            {
                SmsSingleRequest smsSingleRequest = new SmsSingleRequest();
                smsSingleRequest.contract_name = contract_name;
                smsSingleRequest.user_name = user_name;
                smsSingleRequest.phone = phone;
                smsSingleRequest.sms_type = sms_type;
                smsSingleResponse = client.Sms.smsSingle(smsSingleRequest);
                Console.WriteLine("单次短信通知:" + JSONUtil.getJsonStringFromObject(smsSingleResponse));
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
            //单次短信添加end

            //批量短信添加 start
            SmsBatchResponse smsBatchResponse = new SmsBatchResponse();
            try
            {
                SmsBatchRequest smsBatchRequest = new SmsBatchRequest();
                smsBatchRequest.sms_type = sms_type;
                Params @params = new Params();
                @params.contract_name = contract_name;
                @params.phone = phone;
                @params.user_name = user_name;
                List<Params> list = new List<Params>();
                list.Add(@params);
                smsBatchResponse = client.Sms.smsBatch(smsBatchRequest);
                Console.WriteLine("单次短信通知:" + JSONUtil.getJsonStringFromObject(smsSingleResponse));
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
            //批量短信添加 end
        }

        /// <summary>
        /// 短信验证码
        /// </summary>
        /// <param name="custom_id"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        static string smsAuthCode(string custom_id, string phone)
        {
            String uuid = "";
            // 初始话 客户端对象
            SignClient client = new SignClient(baseUrl, new DictionaryTokenDataSource(), appId, appSecret);
            //短信验证码添加 start
            SmsAuthCodeResponse smsAuthCodeResponse = new SmsAuthCodeResponse();
            try
            {
                SmsAuthCodeRequest smsAuthCodeRequest = new SmsAuthCodeRequest();
                PhoneParam phoneParam = new PhoneParam();
                phoneParam.custom_id = custom_id;
                phoneParam.phone = phone;
                List<PhoneParam> list = new List<PhoneParam>();
                list.Add(phoneParam);
                smsAuthCodeRequest.phones = list;
                smsAuthCodeResponse = client.Sms.smsAuthCode(smsAuthCodeRequest);
                Console.WriteLine("短信验证码:" + JSONUtil.getJsonStringFromObject(smsAuthCodeResponse));
                for (int i = 0; i < smsAuthCodeResponse.phones.Count; i++)
                {
                    uuid = smsAuthCodeResponse.phones[0].uuid;
                }
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
            //短信验证码end
            return uuid;
        }
        /// <summary>
        /// 验证-短信验证码
        /// </summary>
        /// <param name="uuid"></param>
        /// <param name="auth_code"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        static void smsValidAuthCode(string uuid, string auth_code, string phone)
        {
            // 初始话 客户端对象
            SignClient client = new SignClient(baseUrl, new DictionaryTokenDataSource(), appId, appSecret);
            //短信验证码添加 start
            SmsValidAuthCodeResponse smsValidAuthCodeResponse = new SmsValidAuthCodeResponse();
            try
            {
                SmsValidAuthCodeRequest smsValidAuthCodeRequest = new SmsValidAuthCodeRequest();
                smsValidAuthCodeRequest.auth_code = auth_code;
                smsValidAuthCodeRequest.uuid = uuid;
                smsValidAuthCodeRequest.phone = phone;
                smsValidAuthCodeResponse = client.Sms.smsValidAuthCode(smsValidAuthCodeRequest);
                Console.WriteLine("验证-短信验证码:" + JSONUtil.getJsonStringFromObject(smsValidAuthCodeResponse));
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
            //短信验证码end
        }

        /// <summary>
        /// 印章 操作 
        /// </summary>
        static String seal(string userId, string fileId)
        {
            String sealId = "";
            // 初始话 客户端对象
            SignClient client = new SignClient(baseUrl, new DictionaryTokenDataSource(), appId, appSecret);
            //印章添加 start
            try
            {
                SealAddRequest sealAddRequest = new SealAddRequest();
                sealAddRequest.user_id = userId;
                sealAddRequest.seal_name = "测试印章D";
                sealAddRequest.seal_type = SealType.CORPORATE;
                sealAddRequest.size = "40*40";
                sealAddRequest.file_id = fileId;
                sealAddRequest.description = "备注法人章";
                SealAddResponse sealAddResponse = client.Seal.sealAdd(sealAddRequest);
                Console.WriteLine("印章添加:" + JSONUtil.getJsonStringFromObject(sealAddResponse));
                sealId = sealAddResponse.seal_id;
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
            //印章添加end

            //印章查询 start
            try
            {
                SealQueryResponse sealQueryResponse = client.Seal.sealQuery(new SealQueryRequest(sealId));
                Console.WriteLine("印章查询:" + JSONUtil.getJsonStringFromObject(sealQueryResponse));

            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
            //印章查询 end

            //根据用户查询印章 start
            try
            {
                List<SealGetSealInfosResponse> getSealInfosResponse = client.Seal.sealGetSealInfos(new SealGetSealInfosRequest(userId));
                Console.WriteLine("根据用户查询印章:" + JSONUtil.getJsonStringFromObject(getSealInfosResponse));

            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
            //根据用户查询印章 end

            //注销印章 start
            try
            {
                SealRemoveResponse sealRemoveResponse = client.Seal.sealRemove(new SealRemoveRequest("e8726e65b89fed7222951d7e1f4ee106"));
                Console.WriteLine("注销印章:" + JSONUtil.getJsonStringFromObject(sealRemoveResponse));

            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
            //注销印章 end
            //锁定印章 start
            try
            {
                SealLockResponse sealRemoveResponse = client.Seal.sealLock(new SealLockRequest(sealId));
                Console.WriteLine("锁定印章:" + JSONUtil.getJsonStringFromObject(sealRemoveResponse));

            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
            //锁定印章 end
            //解锁印章 start
            try
            {
                SealUnlockResponse sealRemoveResponse = client.Seal.sealUnlock(new SealUnlockRequest(sealId));
                Console.WriteLine("解锁印章:" + JSONUtil.getJsonStringFromObject(sealRemoveResponse));

            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
            //解锁印章 end
            return sealId;
        }


        /// <summary>
        /// 企业客户 demo code
        /// </summary>
        static string company()
        {
            string userId = "";
            // 初始话 客户端对象
            SignClient client = new SignClient(baseUrl, new DictionaryTokenDataSource(), appId, appSecret);
            // 企业用户注册 begin
            try
            {
                CompanyRegisterRequest companyRegisterRequest = new CompanyRegisterRequest();
                companyRegisterRequest.user_name = "测试企业用户";
                companyRegisterRequest.area_code = "370000";
                companyRegisterRequest.unit_type = CompanyType.Company;
                companyRegisterRequest.credi_code = "91320112MA3F6JM322";
                companyRegisterRequest.legal_name = "李四";
                companyRegisterRequest.legal_id_number = "370000111111111112";
                companyRegisterRequest.legal_id_type = IdType.IDCARD;
                companyRegisterRequest.legal_phone = "13711111111";
                companyRegisterRequest.legal_email = "demo@sdgd.com";
                companyRegisterRequest.agent_name = "王五";
                companyRegisterRequest.agent_id_number = "370000111111111122";
                companyRegisterRequest.agent_id_type = IdType.IDCARD;
                companyRegisterRequest.agent_phone = "13711111111";
                companyRegisterRequest.agent_email = "demo@sdgd.com";
                companyRegisterRequest.description = "描述信息:demo code";


                CompanyRegisterResponse companyRegisterResponse = client.Company.companyRegister(companyRegisterRequest);
                Console.WriteLine("企业客户注册:" + JSONUtil.getJsonStringFromObject(companyRegisterResponse));
                userId = companyRegisterResponse.user_id;
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
            // 企业用户注册 end

            // 企业用户查询 begin
            try
            {
                CompanyUserinfoResponse companyUserinfoRequest = client.Company.companyUserinfo(new CompanyUserinfoRequest(userId));
                Console.WriteLine("企业客户信息:" + JSONUtil.getJsonStringFromObject(companyUserinfoRequest));
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
            // 企业用户查询 end

            //企业用户锁定 begin
            try
            {
                CompanyLockResponse companyLockResponse = client.Company.companylock(new CompanyLockRequest(userId));
                Console.WriteLine("企业用户信息锁定" + JSONUtil.getJsonStringFromObject(companyLockResponse));
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
            //企业用户锁定 end

            //企业用户解锁 begin
            try
            {
                CompanyUnlockResponse companyUnlockResponse = client.Company.companyUnlock(new CompanyUnlockRequest(userId));
                Console.WriteLine("企业用户信息解锁" + JSONUtil.getJsonStringFromObject(companyUnlockResponse));
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
            //企业用户解锁 end
            return userId;

        }
        /// <summary>
        /// 证书申请的
        /// </summary>
        static string cert(string userId)
        {
            string certId = "";
            //初始化 客户端对象
            SignClient client = new SignClient(baseUrl, new DictionaryTokenDataSource(), appId, appSecret);
            CertApplyResponse applyResponse = null;
            try
            {
                applyResponse = client.Cert.certApply(new CertApplyRequest(userId));
                Console.WriteLine("证书申请：" + JSONUtil.getJsonStringFromObject(applyResponse));
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为: " + sae.return_code);
                Console.WriteLine("网关异常信息为: " + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }

            try
            {
                CertCertinfoResponse response = client.Cert.certinfo(new CertCertinfoRequest(applyResponse.prepare_id));
                certId = response.cert_info.cert_id;
                Console.WriteLine("证书查询：" + JSONUtil.getJsonStringFromObject(response));
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为: " + sae.return_code);
                Console.WriteLine("网关异常信息为: " + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
            return certId;

        }


        /// <summary>
        /// 客户信息 示例代码
        /// </summary>
        static string personal()
        {
            String userId = "";
            // 初始话 客户端对象 
            SignClient client = new SignClient(baseUrl, new DictionaryTokenDataSource(), appId, appSecret);
            // 创建个人用户 begin
            PersonalRegisterRequest personalRegisterRequest = new PersonalRegisterRequest();
            personalRegisterRequest.area_code = "370000";
            personalRegisterRequest.description = "描述信息：该用户位示例用户";
            personalRegisterRequest.id_number = "370000123456782124";
            personalRegisterRequest.id_type = IdType.IDCARD;
            personalRegisterRequest.mail = "123456@sdgd.com";
            personalRegisterRequest.phone = "13711111121";
            personalRegisterRequest.user_name = "测试用户";
            try
            {
                PersonalRegisterResponse response = client.Personal.personalRegister(personalRegisterRequest);
                Console.WriteLine("用户注册完成：" + JSONUtil.getJsonStringFromObject(response));
                userId = response.user_id;
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
            // 创建个人用户 end



            // 获取客户信息 begin 
            try
            {

                PersonalUserinfoResponse personalUserinfoResponse = client.Personal.personalUserinfo(new PersonalUserinfoRequest(userId));
                userId = personalUserinfoResponse.personal_info.user_id;
                Console.WriteLine("查询个人用户信息:" + JSONUtil.getJsonStringFromObject(personalUserinfoResponse));
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
            // 获取客户信息 end


            // 锁定个人用户 begin
            try
            {
                PersonalLockResponse personalLockResponse = client.Personal.personalLock(new PersonalLockRequest("00709732031986814976"));
                Console.WriteLine("锁定个人用户:" + JSONUtil.getJsonStringFromObject(personalLockResponse));
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
            // 锁定个人用户 end

            // 锁定个人用户 begin
            try
            {
                PersonalUnlockResponse personalUnlockResponse = client.Personal.personalUnlock(new PersonalUnlockRequest("00709732031986814976"));
                Console.WriteLine("解锁个人用户:" + JSONUtil.getJsonStringFromObject(personalUnlockResponse));
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
            // 锁定个人用户 end
            return userId;
        }
        /// <summary>
        /// 文件 demo code
        /// </summary>
        static string fileManager(string filePath, string fileName, String fileType)
        {
            string fileId = "";
            // 初始话 客户端对象
            SignClient client = new SignClient(baseUrl, new DictionaryTokenDataSource(), appId, appSecret);
            // 获取文件信息
            FileStream fs = new FileStream(filePath, FileMode.Open);
            //获取文件大小 begin 
            long size = fs.Length;
            byte[] array = new byte[size];
            //将文件读到byte数组中
            fs.Read(array, 0, array.Length);
            fs.Close();
            //获取文件大小 end 

            FileUploadRequest fileUploadRequest = new FileUploadRequest();
            fileUploadRequest.fileData = array;
            fileUploadRequest.fileDataName = fs.Name;
            fileUploadRequest.fileType = fileType;
            fileUploadRequest.fileName = fileName;
            fileUploadRequest.userId = "";
            try
            {
                FileUploadResponse response = client.FileManager.fileUpload(fileUploadRequest);
                Console.WriteLine("文件上传 :" + JSONUtil.getJsonStringFromObject(response));
                fileId = response.file_id;
            }
            catch (Exception)
            {

                throw;
            }
            return fileId;
        }

        /// <summary>
        /// 加密请求下三网认证
        /// </summary>
        static void authEncryQuery(AuthEncryRequest request)
        {
            // 初始话 客户端对象 
            SignClient client = new SignClient(baseUrl, new DictionaryTokenDataSource(), appId, appSecret);
            try
            {
                AuthEncryResponse response = client.Auth.encryQuery(request);
                Console.WriteLine("三网认证:" + JSONUtil.getJsonStringFromObject(response));
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
        }

        /// <summary>
        /// 银行卡四要素认证
        /// </summary>
        static void blankFourEnCeryQuery(BlankCardCheckRequest request)
        {
            // 初始话 客户端对象 
            SignClient client = new SignClient(baseUrl, new DictionaryTokenDataSource(), appId, appSecret);
            try
            {
                BankCardEncryResponse response = client.Auth.blankFourEnCeryQuery(request);
                Console.WriteLine("银行卡四要素认证:" + JSONUtil.getJsonStringFromObject(response));
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
        }
        /// <summary>
        /// 企业三要素认证
        /// </summary>
        static void enterpriseThreeQuery(EnterpriseQueryRequest request)
        {
            // 初始话 客户端对象 
            SignClient client = new SignClient(baseUrl, new DictionaryTokenDataSource(), appId, appSecret);
            try
            {
                EnterpriseQueryResponse response = client.Auth.enterpriseThreeQuery(request);
                Console.WriteLine("企业三要素认证:" + JSONUtil.getJsonStringFromObject(response));
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
        }
        /// <summary>
        ///  支付宝认证-开始认证
        /// </summary>
        static string aliPayCertify(AliPayCertifyRequest request)
        {
            string certify_id = "";
            // 初始话 客户端对象 
            SignClient client = new SignClient(baseUrl, new DictionaryTokenDataSource(), appId, appSecret);
            try
            {
                AliPayCertifyResponse response = client.Auth.aliPayCertify(request);
                Console.WriteLine("支付宝认证-开始认证:" + JSONUtil.getJsonStringFromObject(response));
                certify_id = response.certify_id;
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
            return certify_id;
        }
        /// <summary>
        ///  支付宝认证-认证查询
        /// </summary>
        static void aliPayCertifyQuery(AliPayQueryRequest request)
        {
            // 初始话 客户端对象 
            SignClient client = new SignClient(baseUrl, new DictionaryTokenDataSource(), appId, appSecret);
            try
            {
                AliPayQueryResponse response = client.Auth.aliPayCertifyQuery(request);
                Console.WriteLine("支付宝认证-认证查询:" + JSONUtil.getJsonStringFromObject(response));
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
        }
        /// <summary>
        ///  数据宝企业四要素认证
        /// </summary>
        static void entFour(SJBEntFourRequest request)
        {
            // 初始话 客户端对象 
            SignClient client = new SignClient(baseUrl, new DictionaryTokenDataSource(), appId, appSecret);
            try
            {
                SJBEntFourResponse response = client.Auth.entFour(request);
                Console.WriteLine("数据宝企业四要素认证:" + JSONUtil.getJsonStringFromObject(response));
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
        }
        /// <summary>
        /// 企业打款
        /// </summary>
        static string enterprisePay(EnterprisePayRequest request)
        {
            string order_id = "";
            // 初始话 客户端对象 
            SignClient client = new SignClient(baseUrl, new DictionaryTokenDataSource(), appId, appSecret);
            try
            {
                EnterprisePayResponse response = client.Auth.enterprisePay(request);
                Console.WriteLine("企业打款:" + JSONUtil.getJsonStringFromObject(response));
                order_id = response.order_id;
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
            return order_id;
        }
        /// <summary>
        /// 企业打款查询
        /// </summary>
        static void enterprisePayQuery(EnterprisePayQueryRequest request)
        {
            // 初始话 客户端对象 
            SignClient client = new SignClient(baseUrl, new DictionaryTokenDataSource(), appId, appSecret);
            try
            {
                EnterprisePayQueryResponse response = client.Auth.enterprisePayQuery(request);
                Console.WriteLine("企业打款查询:" + JSONUtil.getJsonStringFromObject(response));
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
        }
        /// <summary>
        /// 企业打款验证
        /// </summary>
        static void enterprisePayValid(EnterprisePayValidRequest request)
        {
            // 初始话 客户端对象 
            SignClient client = new SignClient(baseUrl, new DictionaryTokenDataSource(), appId, appSecret);
            try
            {
                EnterprisePayValidResponse response = client.Auth.enterprisePayValid(request);
                Console.WriteLine("企业打款验证:" + JSONUtil.getJsonStringFromObject(response));
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
        }
        /// <summary>
        /// 获取百度身份验证-语音验证数据
        /// </summary>
        static string baiduSessionCode()
        {
            string session_id = "";
            // 初始话 客户端对象 
            SignClient client = new SignClient(baseUrl, new DictionaryTokenDataSource(), appId, appSecret);
            try
            {
                BaiduSessionCodeResponse response = client.Auth.baiduSessionCode();
                Console.WriteLine("语音验证数据:" + JSONUtil.getJsonStringFromObject(response));
                session_id = response.session_id;
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
            return session_id;
        }
        /// <summary>
        /// 获取百度身份验证-语音验证数据
        /// </summary>
        static void baiduVideoVerify(BaiDuAiFaceVideoVerifyRequest request)
        {
            // 初始话 客户端对象 
            SignClient client = new SignClient(baseUrl, new DictionaryTokenDataSource(), appId, appSecret);
            try
            {
                BaiDuAiFaceVideoVerifyResponse response = client.Auth.baiduVideoVerify(request);
                Console.WriteLine("企业打款验证:" + JSONUtil.getJsonStringFromObject(response));
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
        }
        /// <summary>
        /// 获取百度身份验证-身份验证
        /// </summary>
        static void baiduCertifyVerify(BaiDuAiFaceCertifyVerifyRequest request)
        {
            // 初始话 客户端对象 
            SignClient client = new SignClient(baseUrl, new DictionaryTokenDataSource(), appId, appSecret);
            try
            {
                BaiDuAiFaceCertifyVerifyResponse response = client.Auth.baiduCertifyVerify(request);
                Console.WriteLine("身份验证:" + JSONUtil.getJsonStringFromObject(response));
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("网关异常状态码为：" + sae.return_code);
                Console.WriteLine("网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("业务异常状态码为：" + sse.result_code);
                Console.WriteLine("业务异常信息为：" + sse.result_message);
            }
        }
    }  
}
