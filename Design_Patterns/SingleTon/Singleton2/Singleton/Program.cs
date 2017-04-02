using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(People.GetInstance());
        }
    }

    class People
    {
        static People people;

        static readonly Object syncRoot = new object();

        public static People GetInstance()
        {
            if (people == null)
            {
                lock (syncRoot)
                {
                    if (people == null)
                    {
                        people = new People();
                    }
                }
            }

            return people;
        }
    }
}
