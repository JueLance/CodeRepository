using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskSample
{
    class Program
    {
        [STAThread]
        //[MTAThread]
        static void Main(string[] args)
        {
            //var t = new Task<int>(Compute);
            //t.Start();
            //Console.WriteLine(t.Result);

            //new Task(ComputeBoundOp, 5).Start();


            //Task<int> t2 = new Task<int>(n=>Sum((int)n), 1000000000);
            //t2.Start();
            //t2.Wait();
            //Console.WriteLine(t2.Result);

            Task<int> t2 = new Task<int>(n => Sum((int)n), 1000000000);
            t2.Start();
            var cwt = t2.ContinueWith(task => Console.WriteLine("result: {0}" + task.Result));

            //Console.ReadLine();
        }

        private static int Sum(int n)
        {
            int sum = 0;
            for (; n > 0; n--)
            {
                checked
                {
                    sum += n;
                }
            }

            return sum;
        }

        static int Compute()
        {
            int value = 0;

            for (int i = 0; i < 200; i++)
            {
                value += i;
            }

            return value;
        }

        private static void ComputeBoundOp(object state)
        {
            Console.WriteLine(state);
            Thread.Sleep(1000);
        }
    }
}
