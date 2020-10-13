using System;
using System.Reflection;

namespace sign_sdk_net.test
{
    class BaseTest
    {
        protected string testName;

        /// <summary>
        /// 运行所有测试方法
        /// </summary>
        public void runAllTest()
        {
           
            Console.WriteLine("***************************  检查{0}流程 start ***************************", testName);
            System.Reflection.MethodInfo[] methods = this.GetType().GetMethods();
            for (int i = 0; i < methods.Length; i++)
            {
                MethodInfo methodInfo = methods[i];
                if (methodInfo.ReturnType == Type.GetType("System.Void")&&methodInfo.Name!= "runAllTest" )
                {
                    methodInfo.Invoke(this, null);
                }
            }
            this.Dispose();
        }

        /// <summary>
        /// 注销测试
        /// </summary>
        protected void Dispose()
        {
            Console.WriteLine("***************************  检查{0}流程 end ****************************", testName);
            Console.WriteLine("");
            Console.WriteLine("");
        }
    }
}
