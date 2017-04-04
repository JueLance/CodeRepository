/*
 * https://m.baidu.com/from=1000953b/bd_page_type=1/ssid=0/uid=0/pu=usm%401%2Csz%40224_220%2Cta%40iphone___3_537/baiduid=BEDBDAEE8E9FEBF42293AE6003A1CCD3/w=0_10_c%23%E5%A4%9A%E7%BA%BF%E7%A8%8B%E7%BC%96%E7%A8%8B/t=iphone/l=3/tc?ref=www_iphone&lid=14495073551731828145&order=6&fm=alop&tj=www_normal_6_0_10_title&vit=osres&m=8&srd=1&cltj=cloud_title&asres=1&title=C%E5%A4%9A%E7%BA%BF%E7%A8%8B%E7%BC%96%E7%A8%8B-%E9%98%BF%E5%87%A1%E5%8D%A2-%E5%8D%9A%E5%AE%A2%E5%9B%AD&dict=30&sec=14534&di=818ef07f3ef8df18&bdenc=1&nsrc=IlPT2AEptyoA_yixCFOxXnANedT62v3IEQGG_ytK1DK6mlrte4viZQRAXiLnKXaNC6D8gTCccQoDlnOd27Yn8RRZhOgtfq
 * http://blog.jobbole.com/89261/
 * 
 * 
 * 
 * 一、使用线程的理由
1、可以使用线程将代码同其他代码隔离，提高应用程序的可靠性。
2、可以使用线程来简化编码。
3、可以使用线程来实现并发执行。
二、基本知识
1、进程与线程：进程作为操作系统执行程序的基本单位，拥有应用程序的资源，进程包含线程，进程的资源被线程共享，线程不拥有资源。
2、前台线程和后台线程：通过Thread类新建线程默认为前台线程。当所有前台线程关闭时，所有的后台线程也会被直接终止，不会抛出异常。
3、挂起（Suspend）和唤醒（Resume）：由于线程的执行顺序和程序的执行情况不可预知，所以使用挂起和唤醒容易发生死锁的情况，在实际应用中应该尽量少用。
4、阻塞线程：Join，阻塞调用线程，直到该线程终止。
5、终止线程：Abort：抛出 ThreadAbortException 异常让线程终止，终止后的线程不可唤醒。Interrupt：抛出 ThreadInterruptException 异常让线程终止，通过捕获异常可以继续执行。
6、线程优先级：AboveNormal BelowNormal Highest Lowest Normal，默认为Normal。
 
     线程同步
　　1）原子操作（Interlocked）：所有方法都是执行一次原子读取或一次写入操作。
　　2）lock()语句：避免锁定public类型，否则实例将超出代码控制的范围，定义private对象来锁定。
　　3）Monitor实现线程同步
　　　　通过Monitor.Enter() 和 Monitor.Exit()实现排它锁的获取和释放，获取之后独占资源，不允许其他线程访问。
　　　　还有一个TryEnter方法，请求不到资源时不会阻塞等待，可以设置超时时间，获取不到直接返回false。
　　4）ReaderWriterLock
　　　　当对资源操作读多写少的时候，为了提高资源的利用率，让读操作锁为共享锁，多个线程可以并发读取资源，而写操作为独占锁，只允许一个线程操作。
　　5）事件（Event）类实现同步
　　　　事件类有两种状态，终止状态和非终止状态，终止状态时调用WaitOne可以请求成功，通过Set将时间状态设置为终止状态。
　　　　1）AutoResetEvent（自动重置事件）
　　　　2）ManualResetEvent（手动重置事件）
　　6）信号量（Semaphore）
　　　　　　信号量是由内核对象维护的int变量，为0时，线程阻塞，大于0时解除阻塞，当一个信号量上的等待线程解除阻塞后，信号量计数+1。
　　　　　　线程通过WaitOne将信号量减1，通过Release将信号量加1，使用很简单。
　　7）互斥体（Mutex）
　　　　　　独占资源，用法与Semaphore相似。
 　 8）跨进程间的同步
　　　　　　通过设置同步对象的名称就可以实现系统级的同步，不同应用程序通过同步对象的名称识别不同同步对象。
     
 * 
 * 
 * **/

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //ThreadDemo.Run();
            //ThreadPoolDemo.Run();
            //TaskDemo.Run();
            DelegateDemo.Run();

            Parallel.For(0, 100, i =>
            {
                Console.Write(i + "\t");
            });
        }

        public static void Run1()
        {
            Thread.Sleep(2000);
            Console.WriteLine("Task 1 is cost 2 sec");
        }

        public static void Run2()
        {
            Thread.Sleep(3000);
            Console.WriteLine("Task 2 is cost 3 sec");
        }

        public static void Run3()
        {
            //Parallel.Invoke
            //Stopwatch stopWatch = new Stopwatch();
            //stopWatch.Start();
            //Parallel.Invoke(Run1, Run2);
            //stopWatch.Stop();
            //Console.WriteLine("Parallel run " + stopWatch.ElapsedMilliseconds + " ms.");

            //stopWatch.Reset();
            //stopWatch.Start();
            //Run1();
            //Run2();
            //stopWatch.Stop();
            //Console.WriteLine("Indivual run " + stopWatch.ElapsedMilliseconds + " ms.");

        }

        public static void Run4()
        {
            //Parallel.For
            //stopWatch.Start();
            //for (int i = 0; i < 10000; i++)
            //{
            //    for (int j = 0; j < 60000; j++)
            //    {
            //        int sum = 0;
            //        sum += i;
            //    }
            //}
            //stopWatch.Stop();
            //Console.WriteLine("NormalFor run " + stopWatch.ElapsedMilliseconds + " ms.");

            //stopWatch.Reset();
            //stopWatch.Start();
            //Parallel.For(0, 10000, item =>
            //{
            //    for (int j = 0; j < 60000; j++)
            //    {
            //        int sum = 0;
            //        sum += item;
            //    }
            //});
            //stopWatch.Stop();
            //Console.WriteLine("ParallelFor run " + stopWatch.ElapsedMilliseconds + " ms.");

        }

        public static void Run5()
        {
            //for和Parallel.For的比较
            //var obj = new Object();
            //long num = 0;
            //ConcurrentBag<long> bag = new ConcurrentBag<long>();

            //stopWatch.Start();
            //for (int i = 0; i < 10000; i++)
            //{
            //    for (int j = 0; j < 60000; j++)
            //    {
            //        //int sum = 0;
            //        //sum += item;
            //        num++;
            //    }
            //}
            //stopWatch.Stop();
            //Console.WriteLine("NormalFor run " + stopWatch.ElapsedMilliseconds + " ms.");

            //stopWatch.Reset();
            //stopWatch.Start();
            //Parallel.For(0, 10000, item =>
            //{
            //    for (int j = 0; j < 60000; j++)
            //    {
            //        //int sum = 0;
            //        //sum += item;
            //        lock (obj)
            //        {
            //            num++;
            //        }
            //    }
            //});
            //stopWatch.Stop();
            //Console.WriteLine("ParallelFor run " + stopWatch.ElapsedMilliseconds + " ms.");
        }
    }
}