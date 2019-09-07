using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Context c = new Context(new ConcreteStateA());
            c.Request();//A本身的事情处理完成以后，将State修改成B
            c.Request();//继续调用后，由B来处理事情。B处理完以后，将State修改成C
            c.Request();//继续调用后，由C来处理事情。C处理完以后，将State修改成null
            c.Request();//由于C将State修改成null，因此这里只是一个空调用
            c.Request();

            Console.Read();
        }
    }
}
