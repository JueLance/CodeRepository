using System;
using System.Collections.Generic;
using System.Text;

namespace SingleTonDemo
{
    //饿汉式单例类： 这种静态初始化是在自己被加载时就将自己实例化， 所以被形象地称之为单例类
    public sealed class Singleton2
    {
        private static readonly Singleton2 instance = new Singleton2();

        private Singleton2()
        {

        }

        public static Singleton2 GetInstance()
        {
            return instance;
        }
    }

    class Singleton
    {
        private static Singleton instance;

        //进程辅助对象
        private static readonly object syncRoot = new object();

        private Singleton()
        {

        }

        //懒汉式单例类： 需要在第一次被引用时， 才会将自己实例化
        public static Singleton GetInstance()
        {
            //lock是确保当一个线程位于代码的临界区时， 另一个线程不进入临界区。 如果其他线程试图进入
            //锁定的代码， 则它将一直等待(即被阻止)， 直到该对象被释放。 这样就确加了lock的代码段， 
            //在同一个时刻， 只有一个线程可以进入。
            lock (syncRoot)
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
            }

            return instance;
        }

        //双重锁定技术
        //public static Singleton GetInstance()
        //{
        //    if (instance == null)
        //    {

        //        lock (syncRoot)
        //        {
        //            if (instance == null)
        //            {
        //                instance = new Singleton();
        //            }
        //        }
        //    }
        //    return instance;
        //}

    }

}