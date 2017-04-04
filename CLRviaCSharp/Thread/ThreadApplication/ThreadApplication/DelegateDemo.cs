using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadApplication
{
    public delegate string MyDelegate(object data);

    public class DelegateDemo
    {
        public static void Run()
        {
            MyDelegate mydelegate = new MyDelegate(TestMethod);
            IAsyncResult result = mydelegate.BeginInvoke("Thread Param", TestCallback, "Callback Param");

            //异步执行完成
            string resultstr = mydelegate.EndInvoke(result);
            Console.WriteLine(resultstr);
        }

        //线程函数
        static string TestMethod(object data)
        {
            string datastr = data as string;
            return datastr;
        }

        //异步回调函数
        static void TestCallback(IAsyncResult data)
        {
            Console.WriteLine(data.AsyncState);
        }
    }
}
