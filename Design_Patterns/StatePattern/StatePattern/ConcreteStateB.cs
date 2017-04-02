using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatePattern
{
    public class ConcreteStateB : State
    {
        public override void Handle(Context context)
        {
            Console.WriteLine("B的事情处理完成");

            context.State = new ConcreteStateC();
        }
    }
}
