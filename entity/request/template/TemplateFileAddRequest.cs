using System;
using System.Collections.Generic;
using System.Text;

namespace sign_sdk_net.entity.request.template
{
    /// <summary>
    /// 新增模板文件、模板信息 请求参数
    /// </summary>
    class TemplateFileAddRequest
    {
        /// <summary>
        /// 新增模板信息
        /// </summary>
        public TemplateAddRequest templateAddRequest { set; get; }
        /// <summary>
        /// 合同文件
        /// </summary>
        public FileUploadRequest fileUploadRequest { set; get; }
    }
}
