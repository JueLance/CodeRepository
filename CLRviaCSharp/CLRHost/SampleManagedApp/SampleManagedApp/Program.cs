using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleManagedApp
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static int Test(string s)
        {
            Console.WriteLine(s + " - " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " from C# Console Application.");
            return DateTime.Now.Second;
        }
    }

}
