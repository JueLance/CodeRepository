using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            Resume a = new Resume("大鸟");
            a.SetPersonInfo("男", "24");
            a.SetWorkExperience("2011到2012", "xx公司");
            a.Display();

            Resume b = (Resume)a.Clone();
            Resume c = (Resume)a.Clone();

            b.Display();
            c.Display();

        }
    }
}
