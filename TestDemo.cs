
using System;
using System.Collections.Generic;
using sign_sdk_net.client;
using sign_sdk_net.entity;
using sign_sdk_net.test;
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
            //文件相关client端
            FileManagerClient fileManagerClient = new FileManagerClient(baseUrl, new DictionaryTokenDataSource(), appId, appSecret);
        
            //上传文件相关API
            checkUploadFile(fileManagerClient);
            //下载文件相关API
            checkDownloadFile(fileManagerClient);

            //签章相关client端
            SignClient client = new SignClient(baseUrl, new DictionaryTokenDataSource(), appId, appSecret);

            //个人用户相关API
            checkPersonal(client);
            //企业用户相关API
            checkCompany(client);
            //证书相关API
            checkCert(client);
            //印章相关API
            checkSeal(client);
            //合同相关API
            checkContract(client);
            //模板相关API
            checkTemplate(client);
            //事件证书-扫码合同相关API
            checkEventCertScanContract(client);
            //扫码合同相关API
            checkScanContract(client);
            //短信相关API
            checkSms(client);
            //签章相关API
            checkSign(client);
            //事件证书-签章相关API
            checkEventCertSign(client);
            //验签相关API
            checkSignCheck(client);
            //认证相关API
            checkAuth(client);

            //初始化paas客户端
            PaasClient paasClient = new PaasClient(baseUrl, new DictionaryTokenDataSource(), appId, appSecret);
            //原始调用Paas Api接口,除文件上传以及文件下载API
            checkPaasApi(paasClient);

            Console.ReadKey();
        }

     


        /// <summary>
        /// 个人用户相关API
        /// </summary>
        /// <param name="client"></param>
        static void checkPersonal(SignClient client)
        {
            PersonalTest test = new PersonalTest(client);
            test.runAllTest();
        }
        /// <summary>
        /// 企业用户相关API
        /// </summary>
        /// <param name="client"></param>
        static void checkCompany(SignClient client)
        {
            CompanyTest test = new CompanyTest(client);
            test.runAllTest();
        }
        /// <summary>
        /// 证书相关API
        /// </summary>
        /// <param name="client"></param>
        static void checkCert(SignClient client)
        {
            CertTest test = new CertTest(client);
            test.runAllTest();
        }
        /// <summary>
        /// 印章相关API
        /// </summary>
        /// <param name="client"></param>
        static void checkSeal(SignClient client)
        {
            SealTest test = new SealTest(client);
            test.runAllTest();
        }
        /// <summary>
        /// 合同相关API
        /// </summary>
        /// <param name="client"></param>
        static void checkContract(SignClient client)
        {
            ContractTest test = new ContractTest(client);
            test.runAllTest();
        }
        /// <summary>
        /// 模板相关API
        /// </summary>
        /// <param name="client"></param>
        static void checkTemplate(SignClient client)
        {
            TemplateTest test = new TemplateTest(client);
            test.runAllTest();
        }
        /// <summary>
        /// 事件证书-扫码合同相关API
        /// </summary>
        /// <param name="client"></param>
        static void checkEventCertScanContract(SignClient client)
        {
            EventCertScanContractTest test = new EventCertScanContractTest(client);
            test.runAllTest();
        }
        /// <summary>
        /// 扫码合同相关API
        /// </summary>
        /// <param name="client"></param>
        static void checkScanContract(SignClient client)
        {
            ScanContractTest test = new ScanContractTest(client);
            test.runAllTest();
        }
        /// <summary>
        /// 短信相关API
        /// </summary>
        /// <param name="client"></param>
        static void checkSms(SignClient client)
        {
            SmsTest test = new SmsTest(client);
            test.runAllTest();
        }
        /// <summary>
        /// 签章相关API
        /// </summary>
        /// <param name="client"></param>
        static void checkSign(SignClient client)
        {
            SignTest test = new SignTest(client);
            test.runAllTest();
        }
        /// <summary>
        /// 事件证书-签章相关API
        /// </summary>
        /// <param name="client"></param>
        static void checkEventCertSign(SignClient client)
        {
            EventCertSignTest test = new EventCertSignTest(client);
            test.runAllTest();
        }
        /// <summary>
        /// 验签相关API
        /// </summary>
        /// <param name="client"></param>
        static void checkSignCheck(SignClient client)
        {
            SignCheckTest test = new SignCheckTest(client);
            test.runAllTest();
        }
        /// <summary>
        /// 认证相关API
        /// </summary>
        /// <param name="client"></param>
        static void checkAuth(SignClient client)
        {
            AuthTest test = new AuthTest(client);
            test.runAllTest();
        }
        /// <summary>
        /// 文件上传
        /// </summary>
        /// <param name="fileManagerClient"></param>
        static void checkUploadFile(FileManagerClient fileManagerClient) 
        {
            FileUploadTest test = new FileUploadTest(fileManagerClient);
            test.runAllTest();
        }
        /// <summary>
        /// 文件下载
        /// </summary>
        /// <param name="fileManagerClient"></param>
        static void checkDownloadFile(FileManagerClient fileManagerClient)
        {
            FileDownloadTest test = new FileDownloadTest(fileManagerClient);
            test.runAllTest();
        }
        /// <summary>
        /// 原始调用Paas Api接口
        /// </summary>
        static void checkPaasApi(PaasClient paasClient)
        {
            PaasTest test = new PaasTest(paasClient);
            test.runAllTest();
        }
    }
}