/**
 * 
 * 
 * 装饰模式(Decorator)
 * 
 * 动态地为对象增加额外的职责，就增加的功能来说，Decorator模式相比生成子类更加灵活。 
 * 
 * 
 * **/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DecoratorCore;

namespace DecoratorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcreteComponent c = new ConcreteComponent();
            ConcreteDecoratorA a = new ConcreteDecoratorA();
            ConcreteDecoratorB b = new ConcreteDecoratorB();

            //装饰的方法：首先用ConcreteComponent的实例化对象c，
            //然后用ConcreteDecoratorA的实例化对象a来包装c，
            //再用ConcreteComponentB的对象b包装a，
            //最终执行b的Operation();
            a.SetComponent(c);//用a对c进行包装(多了一个私有字段的赋值)
            b.SetComponent(a);//再用b对a进行包装(多了一个私有方法AddedBehavior())
            b.Operation();//最后执行b的Operation()方法

            Console.Read();
        }
    }
}
