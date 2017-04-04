using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadApplication
{
    public class TaskDemo
    {
        /***

      使用ThreadPool的QueueUserWorkItem()方法发起一次异步的线程执行很简单，
      但是该方法最大的问题是没有一个内建的机制让你知道操作什么时候完成，有没有一个内建
      的机制在操作完成后获得一个返回值。为此，可以使用System.Threading.Tasks中的Task类。
      构造一个Task<TResult>对象，并为泛型TResult参数传递一个操作的返回类型。

      */
        public static void Run()
        {
            Task<Int32> t = new Task<Int32>(n => Sum((Int32)n), 1000);
            t.Start();
            t.Wait();
            Console.WriteLine(t.Result);

            Console.ReadKey();
        }

        //一个任务完成时，自动启动一个新任务。
        //一个任务完成后，它可以启动另一个任务，下面重写了前面的代码，不阻塞任何线程。
        public static void Run2()
        {
            Task<Int32> t = new Task<Int32>(n => Sum((Int32)n), 1000);
            t.Start();
            //t.Wait();
            Task cwt = t.ContinueWith(task => Console.WriteLine("The result is {0}", t.Result));
            Console.ReadKey();
        }

        private static Int32 Sum(Int32 n)
        {
            Int32 sum = 0;
            for (; n > 0; --n)
                checked
                {
                    sum += n;
                } //结果太大，抛出异常
            return sum;
        }
    }
}
