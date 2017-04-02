using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryCore
{
    public class AddFactory:IOperationFactory
    {
        public Operation CreateOpeartion()
        {
            return new OperationAdd();
        }
    }
}
