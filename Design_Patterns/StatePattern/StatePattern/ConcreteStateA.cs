using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatePattern
{
    public class ConcreteStateA : State
    {
        public override void Handle(Context context)
        {
            Console.WriteLine("A的事情处理完成");

            context.State = new ConcreteStateB();   
        }
    }
}
