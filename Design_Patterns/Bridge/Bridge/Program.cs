/***
 * 
 * 桥接模式
 * 
 * 将抽象部分与它的实现部分相分离，使他们可以独立的变化。 
 * 
 * 
 * ****/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            Abstraction ab = new RefinedAbstraction();

            ab.SetImplementor(new ConcreteImplementorA());
            ab.Operation();

            ab.SetImplementor(new ConcreteImplementorB());
            ab.Operation();

            Console.WriteLine();
        }
    }
}
