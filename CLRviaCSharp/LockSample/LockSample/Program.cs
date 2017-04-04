 ﻿/**
 * 
 * C#提供了一个关键字lock，它可以把一段代码定义为互斥段（critical section），
 * 互斥段在一个时刻内只允许一个线程进入执行，而其他线程必须等待。
 * 每个线程都有自己的资源，但是代码区是共享的，即每个线程都可以执行相同的函数。
 * 这可能带来的问题就是几个线程同时执行一个函数，导致数据的混乱，产生不可预料的结果，
 * 因此我们必须避免这种情况的发生。
 * 在C# lock关键字定义如下：
 * lock（expression） statement_block
 * expression代表你希望跟踪的对象，通常是对象引用。
 * 如果你想保护一个类的实例，一般地，你可以使用this；
 * 如果你想保护一个静态变量（如互斥代码段在一个静态方法内部），一般使用类名就可以了。
 * 而statement_block就是互斥段的代码，这段代码在一个时刻内只可能被一个线程执行。
 * 下面是一个使用C# lock关键字的典型例子，在注释里说明了C# lock关键字的用法和用途。
 * 
 * **/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LockSample
{
    class Test
    {
        //[STAThread]
        static void Main()
        {
            //AccountRunner.Run();
            Account2Runner.Run();
        }
    }
}
