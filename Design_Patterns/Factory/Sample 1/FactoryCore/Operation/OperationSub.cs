using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryCore
{
    public class OperationSub : Operation
    {
        public override double GetResult()
        {
            return NumberA - NumberB;
        }
    }
}
