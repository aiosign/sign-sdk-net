using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.entity.request.sign;

namespace sign_sdk_net.entity.response.scanContract
{
    /// <summary>
    /// 扫码合同查询接口 响应参数
    /// </summary>
    class ScanContractQueryResonse
    {
        /// <summary>
        /// 合同id
        /// </summary>
        public string contract_id { set; get; }
        /// <summary>
        /// 二维码是否过期
        /// </summary>
        public Boolean qr_code_state { set; get; }
        /// <summary>
        /// 签署状态
        /// </summary>
        public Boolean sign_state { set; get; }
        /// <summary>
        /// 文件id
        /// </summary>
        public string file_id { set; get; }
        /// <summary>
        /// 合同名字
        /// </summary>
        public string name { set; get; }
        /// <summary>
        /// 合同页数
        /// </summary>
        public string page_count { set; get; }
        /// <summary>
        /// 是否渲染完成:0渲染失败1渲染成功2渲染中
        /// </summary>
        public string render_complete { set; get; }
        /// <summary>
        /// 合同大小
        /// </summary>
        public string size { set; get; }
        /// <summary>
        /// 合同状态：1，正常；0，废除
        /// </summary>
        public string status { set; get; }
        /// <summary>
        /// 合同详细数据
        /// </summary>
        public List<ContractInfos> contract_infos { set; get; }
        /// <summary>
        /// 预处理签署信息
        /// </summary>
        public List<Fields> fields { set; get; }

    }
    /// <summary>
    /// 合同信息
    /// </summary>
    public class ContractInfos
    {
        /// <summary>
        /// 图片文件id
        /// </summary>
        public string image_file_id { set; get; }
        /// <summary>
        /// 第几页
        /// </summary>
        public string number { set; get; }
    }
    /// <summary>
    /// 预处理签署信息
    /// </summary>
    public class Fields
    {
        /// <summary>
        /// 印章高度
        /// </summary>
        public double height { set; get; }
        /// <summary>
        /// 水平横坐标
        /// </summary>
        public double horizontal { set; get; }
        /// <summary>
        /// 签章页数
        /// </summary>
        public int page_number { set; get; }
        /// <summary>
        /// 印章ID
        /// </summary>
        public string seal_id { set; get; }
        /// <summary>
        /// 印章文件ID
        /// </summary>
        public string file_id { set; get; }
        /// <summary>
        /// 垂直纵坐标
        /// </summary>
        public double vertical { set; get; }
        /// <summary>
        /// 印章宽度
        /// </summary>
        public double width { set; get; }

    }
}

