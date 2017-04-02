using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChainOfResponsibility
{
    public class ParameterValidator : AbsctractValidator
    {
        protected override bool ValidateSelfLogic(ParameterObject parameterObject)
        {
            Console.WriteLine("in validator1");

            if (parameterObject == null)
            {
                Console.WriteLine("parameterObject is null");
                return false;
            }

            if (parameterObject.getId() <= 0)
            {
                Console.WriteLine("parameterObject.getId()<=0");
                return false;
            }

            return true;
        }
    }
}
