using System;
using System.Collections.Generic;
using System.Text;
using sign_sdk_net.client;
using sign_sdk_net.entity.request.file;

namespace sign_sdk_net.test
{
    /// <summary>
    /// 文件下载
    /// </summary>
    class FileDownloadTest : BaseTest
    {
        private FileManagerClient client;

        public FileDownloadTest(FileManagerClient fileManagerClient)
        {
            this.testName = "文件下载";
            this.client = fileManagerClient;
        }

        /// <summary>
        /// 根据文件ID，下载到本地
        /// </summary>
        public void downloadFile()
        {
            FileDownloadRequest request = new FileDownloadRequest();
            request.file_id = "94b7ea6be791ca55cb21f76f5a9ebbc3";
            request.file_name = "D://contract//我的签署合同.pdf";
            try
            {
                bool isDownload=client.downloadFile(request);
                Console.WriteLine("文件下载保存本地是否成功：{0}", isDownload);
            }
            catch (Exception e)
            {
                Console.WriteLine("下载文件-异常：" + e.Message);
            }
        }
    }
}
