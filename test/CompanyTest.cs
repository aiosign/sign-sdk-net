using System;
using sign_sdk_net.client;
using sign_sdk_net.constant;
using sign_sdk_net.entity.request.company;
using sign_sdk_net.entity.response.company;
using sign_sdk_net.exception;

namespace sign_sdk_net.test
{
    /// <summary>
    /// 企业测试
    /// </summary>
    class CompanyTest : BaseTest
    {
        private SignClient client;

        public CompanyTest(SignClient signClient)
        {
            this.testName = "企业用户";
            this.client = signClient;
        }

        /// <summary>
        /// 企业用户注册并申请证书
        /// </summary>
        public void companyCertRegister() {
            CompanyRegisterRequest companyRegisterRequest = new CompanyRegisterRequest();
            companyRegisterRequest.user_name = "测试某集团子公司用户";
            companyRegisterRequest.area_code = "370000";
            companyRegisterRequest.unit_type = CompanyType.Company;
            companyRegisterRequest.credi_code = "11320111MA3F1JM421";
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
            try {
                CompanyRegisterResponse companyRegisterResponse = client.Company.companyCertRegister(companyRegisterRequest);
                Console.WriteLine("企业客户以及证书注册-响应数据:" + JSONUtil.getJsonStringFromObject(companyRegisterResponse));
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("企业客户以及证书注册-网关异常状态码为：" + sae.return_code);
                Console.WriteLine("企业客户以及证书注册-网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("企业客户以及证书注册-业务异常状态码为：" + sse.result_code);
                Console.WriteLine("企业客户以及证书注册-业务异常信息为：" + sse.result_message);
            }
            catch (Exception e)
            {
                Console.WriteLine("企业客户以及证书注册-异常为：" + e.Message);
            }
        }

        /// <summary>
        /// 企业用户注册
        /// </summary>
        public void companyRegister()
        {
            CompanyRegisterRequest companyRegisterRequest = new CompanyRegisterRequest();
            companyRegisterRequest.user_name = "测试某集团用户";
            companyRegisterRequest.area_code = "370000";
            companyRegisterRequest.unit_type = CompanyType.Company;
            companyRegisterRequest.credi_code = "11320111MA3F1JM521";
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
            try
            {
                CompanyRegisterResponse companyRegisterResponse = client.Company.companyRegister(companyRegisterRequest);
                Console.WriteLine("企业客户注册-响应数据:" + JSONUtil.getJsonStringFromObject(companyRegisterResponse));
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("企业客户注册-网关异常状态码为：" + sae.return_code);
                Console.WriteLine("企业客户注册-网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("企业客户注册-业务异常状态码为：" + sse.result_code);
                Console.WriteLine("企业客户注册-业务异常信息为：" + sse.result_message);
            }
        }
        /// <summary>
        /// 查询企业信息
        /// </summary>
        public void companyUserinfo() 
        {
            try
            {
                CompanyUserinfoResponse companyUserinfoRequest = client.Company.companyUserinfo(new CompanyUserinfoRequest("10765245697771065344"));
                Console.WriteLine("查询企业信息-响应数据:" + JSONUtil.getJsonStringFromObject(companyUserinfoRequest));
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("查询企业信息-网关异常状态码为：" + sae.return_code);
                Console.WriteLine("查询企业信息-网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("查询企业信息-业务异常状态码为：" + sse.result_code);
                Console.WriteLine("查询企业信息-业务异常信息为：" + sse.result_message);
            }
        }
        /// <summary>
        /// 企业用户锁定
        /// </summary>
        public void companyLock()
        {
            try
            {
                CompanyLockResponse companyLockResponse = client.Company.companyLock(new CompanyLockRequest("10765245697771065344"));
                Console.WriteLine("企业用户锁定-响应数据：" + JSONUtil.getJsonStringFromObject(companyLockResponse));
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("企业用户锁定-网关异常状态码为：" + sae.return_code);
                Console.WriteLine("企业用户锁定-网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("企业用户锁定-业务异常状态码为：" + sse.result_code);
                Console.WriteLine("企业用户锁定-业务异常信息为：" + sse.result_message);
            }
        }
        /// <summary>
        /// 企业用户解锁
        /// </summary>
        public void companyUnlock()
        {
            try
            {
                CompanyUnlockResponse companyUnlockResponse = client.Company.companyUnlock(new CompanyUnlockRequest("10765245697771065344"));
                Console.WriteLine("企业用户解锁-响应数据：" + JSONUtil.getJsonStringFromObject(companyUnlockResponse));
            }
            catch (SignApplicationException sae)
            {
                // 捕获网关校验数据
                Console.WriteLine("企业用户解锁-网关异常状态码为：" + sae.return_code);
                Console.WriteLine("企业用户解锁-网关异常信息为：" + sae.return_message);
            }
            catch (SignServerException sse)
            {
                // 捕获网关校验数据
                Console.WriteLine("企业用户解锁-业务异常状态码为：" + sse.result_code);
                Console.WriteLine("企业用户解锁-业务异常信息为：" + sse.result_message);
            }
        }
    }
}
