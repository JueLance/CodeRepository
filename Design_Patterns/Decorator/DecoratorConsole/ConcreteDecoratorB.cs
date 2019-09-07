using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecoratorCore
{
    public class ConcreteDecoratorB : Decorator
    {
        //本类独有的功能，区别于ConcreteDecoratorA
        public void AddedBehavior()
        {

        }

        public override void Operation()
        {
            base.Operation();
            AddedBehavior();//执行本类独有的功能，相当于是对本类的修饰
            Console.WriteLine("具体装饰对象B的操作");
        }

    }
}
