using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.constant
{
    /// <summary>
    /// 认证模式
    /// </summary>
    public class CertifyType
    {
        /// <summary>
        /// 活体人脸认证
        /// </summary>
        public const string FACE = "FACE";
        /// <summary>
        /// 身份证照片认证
        /// </summary>
        public const string CERT_PHOTO = "CERT_PHOTO";
        /// <summary>
        /// 活体人脸认证 + 身份证照片认证 
        /// </summary>
        public const string CERT_PHOTO_FACE = "CERT_PHOTO_FACE";
        /// <summary>
        /// 快捷认证
        /// </summary>
        public const string SMART_FACE = "SMART_FACE";
    }
}
