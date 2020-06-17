using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.exception
{
    /// <summary>
    /// 签章服务
    /// </summary>
    class SignClientInitException : Exception
    {
        public SignClientInitException(string message) : base(message)
        { }
    }
}
