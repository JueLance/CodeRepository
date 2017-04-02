/**
 * 
 * 定义一个用于创建对象的接口，让子类决定实例化哪一个类，Factory Method使一个类的实例化延迟到了子类。
 * 
 * 
 * **/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FactoryCore;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //让子类类决定实例化哪一个类
            IOperationFactory factory = new AddFactory();
            Operation opera = factory.CreateOpeartion();
            opera.NumberA = 45;
            opera.NumberB = 90;
            Console.WriteLine(opera.GetResult());
        }
    }
}
