using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadApplication
{
    public class ThreadPoolDemo
    {
        public static void Run()
        {
            //将工作项加入到线程池队列中，这里可以传递一个线程参数
            //由于线程的创建和销毁需要耗费一定的开销，过多的使用线程会造成内存资源的浪费，出于对性能的考虑，
            //于是引入了线程池的概念。线程池维护一个请求队列，线程池的代码从队列提取任务，然后委派给线程池的一个线程执行，
            //线程执行完不会被立即销毁，这样既可以在后台执行任务，又可以减少线程创建和销毁所带来的开销。
            //线程池线程默认为后台线程（IsBackground）。
            ThreadPool.QueueUserWorkItem(TestMethod, "Hello");
        }

        private static void TestMethod(object data)
        {
            string datastr = data as string;
            Console.WriteLine(datastr);
        }
    }
}
