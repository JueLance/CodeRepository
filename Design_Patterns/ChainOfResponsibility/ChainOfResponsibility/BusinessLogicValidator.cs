using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChainOfResponsibility
{
    public class BusinessLogicValidator : AbsctractValidator
    {
        protected override bool ValidateSelfLogic(ParameterObject parameterObject)
        {
            Console.WriteLine("in validator2");
            int code = this.getCodeById(parameterObject.getId());
            if (code > 0)
            {
                Console.WriteLine("code>0");
                return true;
            }
            return false;
        }

        private int getCodeById(int id)
        {
            return 0;
        }
    }
}
