using sign_sdk_net.entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.constant
{
    /// <summary>
    /// api 接口URL 常量类
    /// </summary>
    static class ApiUrlConstant
    {



        /// <summary>
        /// token 类 常量
        /// </summary>
        public static class Token
        {
            /// <summary>
            /// 获取token 接口
            /// </summary>
            public const string GetToken = "/v1/oauth/token";
        }
        /// <summary>
        /// 个人用户 api
        /// </summary>
        public static class Personal
        {
            private const string Base = "/v1/user/personal";
            /// <summary>
            /// 用户信息
            /// </summary>
            public const string UserInfo = Base + "/userinfo";
            /// <summary>
            /// 用户注册
            /// </summary>
            public const string Register = Base + "/register";
            /// <summary>
            /// 锁定用户
            /// </summary>
            public const string Lock = Base + "/lock";
            /// <summary>
            /// 解锁用户
            /// </summary>
            public const string Unlock = Base + "/unlock";
        }
        /// <summary>
        /// 签章 api
        /// </summary>
        public static class Sign
        {
            private const string Base = "/v1";
            /// <summary>
            /// 模板签章_单
            /// </summary>
            public const string TemplateSingle = Base + "/sign/template/single";
            /// <summary>
            /// 模板签章_批
            /// </summary>
            public const string TemplateBatch = Base + "/sign/template/batch";
            /// <summary>
            /// 合同坐标签章接口
            /// </summary>
            public const string Common = Base + "/sign/common";
            /// <summary>
            /// 关键字签章接口
            /// </summary>
            public const string KeywordSign = Base + "/sign/keywordSign";
            /// <summary>
            /// 会签接口
            /// </summary>
            public const string MeetingSingle = Base + "/sign/meeting/single";
            /// <summary>
            /// 扫码签章接口
            /// </summary>
            public const string ScanSign = Base + "/sign/scanSign";
            /// <summary>
            /// 事件证书-模板签章_单
            /// </summary>
            public const string EventCertTemplateSingle = Base + "/event_cert_sign/template/single";
            /// <summary>
            /// 事件证书-模板签章_批
            /// </summary>
            public const string EventCertTemplateBatch = Base + "/event_cert_sign/template/batch";
            /// <summary>
            /// 事件证书-合同坐标签章接口
            /// </summary>
            public const string EventCertCommon = Base + "/event_cert_sign/common";
            /// <summary>
            /// 事件证书-关键字签章接口
            /// </summary>
            public const string EventCertKeywordSign = Base + "/event_cert_sign/keywordSign";
            /// <summary>
            /// 事件证书-会签接口
            /// </summary>
            public const string EventCertMeetingSingle = Base + "/event_cert_sign/meeting/single";
            /// <summary>
            /// 事件证书-扫码签章接口
            /// </summary>
            public const string EventCertScanSign = Base + "/event_cert_sign/scanSign";
            /// <summary>
            /// 一步签署接口
            /// </summary>
            public const string DirectSign = Base + "/event_cert_sign/directSign";
        }

        /// <summary>
        /// 印章 api 接口
        /// </summary>
        public static class Seal
        {
            private const string Base = "/v1/seal";
            /// <summary>
            /// 添加印章
            /// </summary>
            public const string Add = Base + "/add";
            /// <summary>
            /// 印章查询
            /// </summary>
            public const string Query = Base + "/query";
            /// <summary>
            /// 查询用户所有印章
            /// </summary>
            public const string GetSealInfos = Base + "/getSealInfos";
            /// <summary>
            /// 查询用户所有印章
            /// </summary>
            public const string GetSealInfosByUserOrType = Base + "/getSealInfosByUsersOrSealTypes";
            /// <summary>
            /// 注销印章
            /// </summary>
            public const string Remove = Base + "/remove";
            /// <summary>
            /// 锁定印章
            /// </summary>
            public const string Lock = Base + "/lock";
            /// <summary>
            /// 解锁印章
            /// </summary>
            public const string Unlock = Base + "/unlock";
        }
        /// <summary>
        /// 模板 api 接口
        /// </summary>
        public static class Template
        {
            private const string Base = "/v1/template";
            /// <summary>
            /// 添加模板
            /// </summary>
            public const string Add = Base + "/add";
            /// <summary>
            /// 模板查询
            /// </summary>
            public const string Query = Base + "/query";
            /// <summary>
            /// 删除模板
            /// </summary>
            public const string Delete = Base + "/delete";
            /// <summary>
            /// 锁定模板
            /// </summary>
            public const string Lock = Base + "/lock";
            /// <summary>
            /// 解锁模板
            /// </summary>
            public const string Unlock = Base + "/unlock";
            /// <summary>
            /// 模板填充
            /// </summary>
            public const string Fill = Base + "/fill";
        }
        /// <summary>
        /// 合同 api 接口
        /// </summary>
        public static class Contract
        {
            private const string Base = "/v1";
            /// <summary>
            /// 添加合同
            /// </summary>
            public const string Add = Base + "/contract/add";
            /// <summary>
            /// 合同查询
            /// </summary>
            public const string Query = Base + "/contract/query";
            /// <summary>
            /// 删除合同
            /// </summary>
            public const string Remove = Base + "/contract/remove";
            /// <summary>
            /// 异步渲染合同接口
            /// </summary>
            public const string Render = Base + "/contract/render";
            /// <summary>
            /// 作废合同接口
            /// </summary>
            public const string Abolish = Base + "/contract/abolish";
            /// <summary>
            /// 绑定合同接口
            /// </summary>
            public const string Bind = Base + "/bind_contract/bind_contract_phone";
            /// <summary>
            /// 查询绑定合同接口
            /// </summary>
            public const string QueryBindContract = Base + "/bind_contract/query_bind_contract";
        }
        /// <summary>
        /// 扫码合同 api 接口
        /// </summary>
        public static class ScanContract
        {
            private const string Base = "/v1/scan/contract";
            /// <summary>
            /// 添加合同
            /// </summary>
            public const string Add = Base + "/add";
            /// <summary>
            /// 合同查询
            /// </summary>
            public const string Query = Base + "/query";
        }

        /// <summary>
        /// 扫码事件证书合同 api 接口
        /// </summary>
        public static class EventCertScanContract
        {
            private const string Base = "/v1/scan/event_cert_contract";
            /// <summary>
            /// 添加合同
            /// </summary>
            public const string Add = Base + "/add";
        }


        /// <summary>
        /// 企业客户请求常量类
        /// </summary>
        public static class Company
        {
            private const string Base = "/v1/user/company";
            /// <summary>
            /// 注册
            /// </summary>
            public const string Register = Base + "/register";
            /// <summary>
            /// 客户信息
            /// </summary>
            public const string Userinfo = Base + "/userinfo";
            /// <summary>
            /// 锁定
            /// </summary>
            public const string Lock = Base + "/lock";
            /// <summary>
            /// 解锁
            /// </summary>
            public const string Unlock = Base + "/unlock";

        }
        /// <summary>
        /// 证书请求常量类
        /// </summary>
        public static class Cert
        {
            private const string Base = "/v1/cert";
            /// <summary>
            /// 证书申请
            /// </summary>
            public const string Apply = Base + "/apply";
            /// <summary>
            /// 证书续期
            /// </summary>
            public const string Renewal = Base + "/renewal";
            /// <summary>
            /// 证书查询
            /// </summary>
            public const string Certinfo = Base + "/certinfo";


        }
        /// <summary>
        ///文件 常量
        /// </summary>
        public static class FileManager
        {
            /// <summary>
            /// 文件上传
            /// </summary>
            public const string FileUpload = "/v1/file/upload";
            /// <summary>
            /// 文件下载
            /// </summary>
            public const string FileDownload = "/v1/file/download";
        }



        /// <summary>
        /// 签章验签
        /// </summary>
        public static class SignCheck
        {
            private const string Base = "/v1/sign";
            private const string BaseV2 = "/v2/sign";
            /// <summary>
            /// 合同验签-文件id验签 
            /// </summary>
            public const string CheckCommon = Base + "/check/common";
            /// <summary>
            /// 合同验签-文件验签
            /// </summary>
            public const string CheckFile = Base + "/check/file";
            /// <summary>
            /// 合同验签V2-文件验签
            /// </summary>
            public const string CheckFileV2 = BaseV2 + "/check/file";
        }
        /// <summary>
        /// 短信
        /// </summary>
        public static class Sms {
            private const string Base = "/v1/sms";
            /// <summary>
            /// 短信单次
            /// </summary>
            public const string signle = Base + "/single";
            /// <summary>
            /// 短信批量
            /// </summary>
            public const string batch = Base + "/batch";
            /// <summary>
            /// 短信验证码
            /// </summary>
            public const string authCode = Base + "/auth_code";
            /// <summary>
            /// 验证-短信验证码
            /// </summary>
            public const string validAuthCode = Base + "/valid_auth_code";
        }
        public static class Auth {
            private const string Base = "/v1/authentication";
            /// <summary>
            ///三网手机实名认证检测
            /// </summary>
            public const string encryQuery = Base+"/encryQuery";
            /// <summary>
            /// 银行卡四要素认证
            /// </summary>
            public const string blankFourEnCeryQuery = Base + "/blank-encry-query";
            /// <summary>
            /// OCR银行卡
            /// </summary>
            public const string ocrBankCard = Base + "/OCR-bank-card";
            /// <summary>
            /// OCR识别类型
            /// </summary>
            public const string ocrCardType = Base + "/OCR-type-list";
            /// <summary>
            /// 证件识别
            /// </summary>
            public const string ocrObject = Base + "/OCR-Object";
            /// <summary>
            /// 企业三要素认证
            /// </summary>
            public const string enterpriseThreeQuery = Base + "/enterprise-encry-query";
            /// <summary>
            /// 企业四要素认证
            /// </summary>
            public const string entFour = Base + "/entFour";
            /// <summary>
            /// 支付宝认证-开始认证
            /// </summary>
            public const string alipayCertify = Base + "/alipay-certify-start";
            /// <summary>
            /// 支付宝认证-认证查询
            /// </summary>
            public const string alipayCertifyQuery = Base + "/alipay-certify-query";
            /// <summary>
            /// 企业打款
            /// </summary>
            public const string enterprisePay = Base + "/enterprise-pay";
            /// <summary>
            /// 企业打款查询
            /// </summary>
            public const string enterprisePayQuery = Base + "/enterprise-pay-query";
            /// <summary>
            /// 企业打款认证
            /// </summary>
            public const string enterprisePayValid = Base + "/enterprise-pay-valid";
            /// <summary>
            ///获取百度身份验证-语音验证数据
            /// </summary>
            public const string baiduSessionCode = Base + "/baidu/session-code";
            /// <summary>
            ///获取百度身份验证-语音验证数据
            /// </summary>
            public const string baiduVideoVerify = Base + "/baidu/video-verify";
            /// <summary>
            ///获取百度身份验证-身份验证
            /// </summary>
            public const string baiduCertifyVerify = Base + "/baidu/certify-verify";
        }
    }
}
