using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //for (int i = 0; i < 1000; i++)
            //{
            //    new GCBeep();
            //    Console.WriteLine(i);
            //    Byte[] b = new byte[100];
            //}

            ss ss = new ss();
            ss.Age = 20;
            Console.WriteLine(ss.Age);
        }
    }

    internal sealed class GCBeep
    {
        ~GCBeep()
        {
            Console.Beep();

            if (!AppDomain.CurrentDomain.IsFinalizingForUnload() && !Environment.HasShutdownStarted)
            {
                new GCBeep();
            }
        }
    }


    public class ss
    {

        public ss()
        {
            throw new Exception("wwwwww");
        }

        public int Age { get; set; }
    }
}
