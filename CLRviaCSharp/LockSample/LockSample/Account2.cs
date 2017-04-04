
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LockSample
{
    internal class Account2
    {
        int balance; //余额
        Random r = new Random();
        internal Account2(int initial)
        {
            balance = initial;
        }

        /// <summary>
        /// 取回、取款
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        internal int Withdraw(int amount)
        {
            if (balance < 0)
            {
                //如果balance小于0则抛出异常  
                throw new Exception("NegativeBalance");//负的 余额 
            }
            //下面的代码保证在当前线程修改balance的值完成之前 
            //不会有其他线程也执行这段代码来修改balance的值  
            //因此，balance的值是不可能小于0的
            //lock (this)
            //{

            //如果没有lock关键字的保护，那么可能在执行完if的条件判断(成立)之后  
            //另外一个线程却执行了balance=balance-amount修改了balance的值 
            //而这个修改对这个线程是不可见的，所以可能导致这时if的条件已经不成立了 
            //但是，这个线程却继续执行 balance=balance-amount，所以导致balance可能小于0 
            if (balance >= amount)
            {
                Thread.Sleep(150);
                Console.WriteLine(string.Format("CurrentThread: {0} ", Thread.CurrentThread.Name));
                Console.WriteLine(string.Format("balance: {0}", balance));
                Console.WriteLine(string.Format("amount: {0}", amount));
                balance = balance - amount;
                Console.WriteLine(string.Format("balance: {0}", balance));
                Console.WriteLine();

                return amount;
            }
            else
            {
                return 0;
                //transactionrejected 
            }
            //}
        }

        /// <summary>
        /// 取款事务
        /// </summary>
        internal void DoTransactions()
        {
            for (int i = 0; i < 100; i++)
            {
                Withdraw(r.Next(1, 100));
            }
        }
    }

    internal class Account2Runner
    {
        static internal Thread[] threads = new Thread[5];

        public static void Run()
        {
            Account2 acc = new Account2(1000);
            for (int i = 0; i < threads.Length; i++)
            {
                Thread t = new Thread(new ThreadStart(acc.DoTransactions));
                threads[i] = t;
                threads[i].Name = i.ToString();
            }

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Start();
                Console.ReadLine();
            }
        }
    }
}
