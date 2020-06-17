using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.response
{
    /// <summary>
    /// base 响应对象
    /// </summary>
    public sealed class BaseSignResponse
    {
        /// <summary>
        /// 返回响应值 -- 网关
        /// </summary>
        public string return_code { get; set; }
        /// <summary>
        /// 异常信息 -- 网关
        /// </summary>
        public string return_message { get; set; }
        /// <summary>
        /// 返回响应值 -- 业务层
        /// </summary>
        public string result_code { get; set; }
        /// <summary>
        /// 返回
        /// </summary>
        public string result_message { get; set; }
        /// <summary>
        /// 响应数据
        /// </summary>
        public Object data { get; set; }
        /// <summary>
        ///  响应数据 转换实体对象
        /// </summary>
        /// <typeparam name="T">转换之后的对象</typeparam>
        /// <returns></returns>
        public T GetData<T>() where T : class
        {
            return JSONUtil.getObjectFromJsonString<T>(JSONUtil.getJsonStringFromObject(data));
        }
    }
}
