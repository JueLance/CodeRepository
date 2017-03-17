using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicPrimitiveType
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 2; i++)
            {
                dynamic arg = (i == 0) ? (dynamic)5 : (dynamic)"A";

                dynamic result = Plus(arg);

                M(result);
            }
        }

        private static dynamic Plus(dynamic arg)
        {
            return arg + arg;
        }

        private static void M(Int32 n)
        {
            Console.WriteLine("M(Int32):" + n);
        }

        private static void M(String s)
        {
            Console.WriteLine("M(String): " + s);
        }
    }
}
