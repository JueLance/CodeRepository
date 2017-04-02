using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChainOfResponsibility
{
    public abstract class AbsctractValidator
    {
        private AbsctractValidator m_NextValidator;

        //这个和经典的职责链模式一样，用于设置下一个
        public AbsctractValidator NextValidator { get; set; }

        public bool Validate(ParameterObject parameterObject)
        {
            bool result = this.ValidateSelfLogic(parameterObject);//验证当前逻辑

            if (result && this.m_NextValidator != null)//当前逻辑满足&&有下一个验证器
            {
                return this.m_NextValidator.Validate(parameterObject);//继续验证
            }

            return result;//返回最终结果
        }

        protected abstract bool ValidateSelfLogic(ParameterObject parameterObject);
    }
}
