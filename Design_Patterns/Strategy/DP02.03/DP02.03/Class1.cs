using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DP02._03.Core;

namespace DP02._03
{
    public class Class1
    {
        static void Main(string[] args)
        {
            Context context;
            context = new Context(new ConcreteStrategyA());
            context.ContextInterface();

            context = new Context(new ConcreteStrategyB());
            context.ContextInterface();

            context = new Context(new ConcreteStrategyC());
            context.ContextInterface();

            Console.Read();
        }
    }
}
