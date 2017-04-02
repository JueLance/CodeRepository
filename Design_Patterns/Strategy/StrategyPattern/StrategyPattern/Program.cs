using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //策略模式
            //CashContext context = new CashContext(new CashNormal());
            //Console.WriteLine(context.GetResult(100));

            //context = new CashContext(new CashRebate("0.7"));
            //Console.WriteLine(context.GetResult(100));

            //context = new CashContext(new CashReturn("50", "1"));
            //Console.WriteLine(context.GetResult(100));

            //策略模式结合简单工厂
            SimpleFactoryCashContext context = new SimpleFactoryCashContext("正常收费");
            Console.WriteLine(context.GetResult(100));

            context = new SimpleFactoryCashContext("打7折");
            Console.WriteLine(context.GetResult(100));

            context = new SimpleFactoryCashContext("满50返1块");
            Console.WriteLine(context.GetResult(100));

        }
    }
}
