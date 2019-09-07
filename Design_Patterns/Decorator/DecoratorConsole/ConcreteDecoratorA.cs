using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecoratorCore
{
    public class ConcreteDecoratorA : Decorator
    {
        private string addedState;//本类独有的功能，区别于ConcreteDecoratorB

        public override void Operation()
        {
            base.Operation();
            addedState = "New State";//执行本类独有的功能，相当于是对本类的修饰
            Console.WriteLine("具体装饰对象A的操作：" + addedState);
        }

    }
}
