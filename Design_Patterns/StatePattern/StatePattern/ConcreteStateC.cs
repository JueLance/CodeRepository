using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatePattern
{
    class ConcreteStateC : State
    {
        public override void Handle(Context context)
        {
            Console.WriteLine("C的事情处理完成");
            context.State = null;
            //context.State = new ConcreteStateC();
        }
    }
}
