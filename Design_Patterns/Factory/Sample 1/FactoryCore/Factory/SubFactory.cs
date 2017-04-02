using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryCore
{
    public class SubFactory : IOperationFactory
    {
        public Operation CreateOpeartion()
        {
            return new OperationSub();
        }
    }
}
