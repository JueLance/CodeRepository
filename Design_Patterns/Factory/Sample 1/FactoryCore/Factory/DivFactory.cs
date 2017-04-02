using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryCore
{
    public class DivFactory:IOperationFactory
    {
        public Operation CreateOpeartion()
        {
            return new OperationDiv();
        }
    }
}
