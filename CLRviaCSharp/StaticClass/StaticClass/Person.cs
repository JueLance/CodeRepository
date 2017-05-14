using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Person
    {
        public Person()
        {
            Console.WriteLine("ins ctor"); ;
        }
        static Person()
        {
            Console.WriteLine("Type ctor");
        }
    }
}
