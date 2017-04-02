using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Class1.Str为常量，
            //在编译时就已经被编译到程序集中
            Console.WriteLine(Class1.Str);

        }
    }
}
