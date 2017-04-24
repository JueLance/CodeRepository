using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TimerSample
{
    class Program
    {
        private static Timer m_Timer;

        static void Main(string[] args)
        {
            Console.WriteLine("Maint thread: starting a time");

            //演示：线程池立即开始调用一个回调方法，以后每隔2秒调用一次
            //0:立即调用
            //period：指定以后每次调用回调方法之前要等待多少毫秒。如果为这个参数传递
            //Timeout.Infinite(-1)，线程池只调用回调方法一次。
            using (m_Timer = new Timer(ComputeBoundOp, 10, 0, Timeout.Infinite))
            {
                Console.WriteLine("Main thread: Doing other work here...");
                Thread.Sleep(10000);
            }

            //Console.ReadLine();

            /*
             
            在内部，线程池为所有Timer对象只使用了一个线程。这个线程知道下一个Timer对象在什么时候到期(计时器还有多久触发)
            下一个Timer对象到期时，线程就会唤醒，在内部，调用ThreadPool.QueueUserWorkItem，将一个工作项添加到线程池的队列中
            使你的回调方法得到调用。

            如果回调方法的执行时间很长，计时器可能（在上个回调还没有完成的时候）再次触发。这可能造成多个线程池线程同时执行你的回调方法。
            为了解决这个问题，作者的建议：构造Timer时，为period参数指定Timeout.Infinite。这样计时器就只出发一次。然后在你的回调方法中，
            调用change方法来指定一个新的dueTime，并再次为period参数指定Timeout.Infinite。
             
             
             */
        }

        private static void ComputeBoundOp(Object state)
        {
            Console.WriteLine("In ComputeBoundOp: state={0}", state);

            Thread.Sleep(2000);

            m_Timer.Change(1000, Timeout.Infinite);

        }
    }
}
