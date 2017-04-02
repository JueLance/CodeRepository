using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecoratorCore
{
    public class ConcreteComponent : Component
    {
        public override void Operation()
        {
            Console.WriteLine("具体对象的操作");
        }
    }
}
