using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProxyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            SchoolGirl jiaojiao = new SchoolGirl();
            jiaojiao.Name = "李娇娇";

            Proxy proxy = new Proxy(jiaojiao);

            proxy.GiveChocolate();
            proxy.GiveDolls();
            proxy.GiveFlowers();
        }
    }
}
