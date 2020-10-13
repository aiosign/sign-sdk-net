using sign_sdk_net.entity.request.bases;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace sign_sdk_net.entity.request
{
    /// <summary>
    /// 文件上传对象
    /// </summary>
    public class FileUploadRequest : BaseSignRequest
    {

        public FileUploadRequest()
        { }

        public FileUploadRequest(string filePath, string fileName)
        {
            FileStream fs = new FileStream(filePath, FileMode.Open);
            //获取文件大小 begin 
            long size = fs.Length;
            byte[] array = new byte[size];
            //将文件读到byte数组中
            fs.Read(array, 0, array.Length);
            fs.Close();
            //获取文件大小 end
            this.fileData = array;
            this.fileDataName = fs.Name;
            this.fileName = fileName;
        }

        public FileUploadRequest(string filePath, string fileName, string fileType, string userId)
        {
            FileStream fs = new FileStream(filePath, FileMode.Open);
            //获取文件大小 begin 
            long size = fs.Length;
            byte[] array = new byte[size];
            //将文件读到byte数组中
            fs.Read(array, 0, array.Length);
            fs.Close();
            //获取文件大小 end
            this.fileData = array;
            this.fileDataName = fs.Name;
            this.fileType = fileType;
            this.fileName = fileName;
            this.userId = userId;
        }
        /// <summary>
        /// 文件名称
        /// </summary>
        public string fileDataName { get; set; }
        /// <summary>
        /// 文件数据
        /// </summary>
        public byte[] fileData { get; set; }
        /// <summary>
        /// 文件类型
        /// </summary>
        public string fileType { get; set; }
        /// <summary>
        /// 文件名称
        /// </summary>
        public string fileName { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public string userId { get; set; }
    }
}
