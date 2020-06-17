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
            private const string Base = "/v1/sign";
            /// <summary>
            /// 模板签章_单
            /// </summary>
            public const string TemplateSingle = Base + "/template/single";
            /// <summary>
            /// 模板签章_批
            /// </summary>
            public const string TemplateBatch = Base + "/template/batch";
            /// <summary>
            /// 合同坐标签章接口
            /// </summary>
            public const string Common = Base + "/common";
            /// <summary>
            /// 关键字签章接口
            /// </summary>
            public const string KeywordSign = Base + "/keywordSign";
            /// <summary>
            /// 会签接口
            /// </summary>
            public const string MeetingSingle = Base + "/meeting/single";
            /// <summary>
            /// 扫码签章接口
            /// </summary>
            public const string ScanSign = Base + "/scanSign";

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
        }
        /// <summary>
        /// 合同 api 接口
        /// </summary>
        public static class Contract
        {
            private const string Base = "/v1/contract";
            /// <summary>
            /// 添加合同
            /// </summary>
            public const string Add = Base + "/add";
            /// <summary>
            /// 合同查询
            /// </summary>
            public const string Query = Base + "/query";
            /// <summary>
            /// 删除合同
            /// </summary>
            public const string Remove = Base + "/remove";
            /// <summary>
            /// 异步渲染合同接口
            /// </summary>
            public const string Render = Base + "/render";
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
        }



        /// <summary>
        /// 签章验签
        /// </summary>
        public static class SignCheck
        {
            private const string Base = "/v1/sign";
            /// <summary>
            /// 合同验签-文件id验签 
            /// </summary>
            public const string CheckCommon = Base + "/check/common";
            /// <summary>
            /// 合同验签-文件验签
            /// </summary>
            public const string CheckFile = Base + "/check/file";
        }
    }
}
