using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Observer1
{
    class Program
    {
        static void Main(string[] args)
        {
            //此方法的缺点就在下面的三句话中体现的：
            //Secretary类需要增加StockObserver，而StockObserver类又需要Secretary的SecretaryAction
            //相互耦合：StockObserver需要Secretary的状态，Secretary需要增加StockObserver
            Secretary secretary = new Secretary();
            StockObserver observer1 = new StockObserver("张三", secretary);
            StockObserver observer2 = new StockObserver("李四", secretary);
            
            secretary.Attach(observer1);
            secretary.Attach(observer2);

            secretary.SecretaryAction = "boss is come back !";
            secretary.Notify();

            //开放--封闭原则：修改原有的代码就说明设计不够好
            //其次，依赖倒转原则，让程序依赖抽象，而不是相互依赖

            //1、将StockObserver类抽象出来，作为抽象的观察者
            //其中的Update让子类去重写实现
            //2、将通知者抽象出来，(Secretary和Boss都可以作为通知者)

        }
    }
}
