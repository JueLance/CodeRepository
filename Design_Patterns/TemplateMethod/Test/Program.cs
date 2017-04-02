using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            TestPaper examineea = new ExamineeA();
            TestPaper examineeb = new ExamineeB();

            Console.WriteLine("A学生的答案是：");
            examineea.Question1();
            examineea.Question2();
            examineea.Question3();

            Console.WriteLine();
            Console.WriteLine("B学生的答案是：");

            examineeb.Question1();
            examineeb.Question2();
            examineeb.Question3();
        }
    }
}
