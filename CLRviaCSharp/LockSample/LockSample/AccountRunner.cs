﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LockSample
{
    public class AccountRunner
    {
        public static void Run()
        {
            Thread[] threads = new Thread[10];
            Account acc = new Account(1000);
            for (int i = 0; i < 10; i++)
            {
                Thread t = new Thread(new ThreadStart(acc.DoTransactions));
                threads[i] = t;
            }

            for (int i = 0; i < 10; i++)
            {
                threads[i].Start();
            }
        }
    }
}
