using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator
{
    public class OperationFactory
    {
        public static Operation CreateOperation(string opeartion)
        {
            Operation operat = null;
            switch (opeartion)
            {
                case "+":
                    operat = new OperationAdd();
                    break;
                case "-":
                    operat = new OperationSub();
                    break;

                case "*":
                    operat = new OperationMul();
                    break;
                case "/":
                    operat = new OperationDiv();
                    break;
            }
            return operat;
        }
    }
}
