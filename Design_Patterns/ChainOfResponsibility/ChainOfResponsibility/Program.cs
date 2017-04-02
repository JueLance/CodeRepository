/**
 * 
 * DesignPattern-利用职责链模式消除if
 * 
 * Reference: http://www.cnblogs.com/kmpp/p/design_pattern_eliminate_if_by_chain_of_responsibility.html
 * 
 * 使多个对象都有机会处理请求，从而避免请求的送发者和接收者之间的耦合关系 
 * 
 * ***/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChainOfResponsibility
{
    //原始逻辑：
    //public class ShitCode
    //{
    //    public void doSomething(ParameterObject parameterObject)
    //    {
    //        if (parameterObject != null)//判断输入参数是否为null
    //        {
    //            if (parameterObject.getId() > 0)//判断输入参数的ID是否大于0
    //            {
    //                int code = getCodeById(parameterObject.getId());//业务逻辑判断
    //                if (code > 0)
    //                {
    //                    //有可能还会有其他的判断
    //                    //do something vaild
    //                }
    //            }
    //        }
    //    }

    //    private int getCodeById(int id)
    //    {
    //        return 0;
    //    }
    //}
    
    //目的：代码演示（消除if）
    class Program
    {
        static void Main(string[] args)
        {
            ParameterObject obj = new ParameterObject();

            BusinessLogicValidator businessLogicValidator = new BusinessLogicValidator();

            ParameterValidator parameterValidator = new ParameterValidator();
            parameterValidator.NextValidator = businessLogicValidator;
            parameterValidator.Validate(obj);
        }
    }
}