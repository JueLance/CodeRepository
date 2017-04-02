using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrategyPattern
{
    public class CashContext
    {
        CashSuper m_Cash;
        public CashContext(CashSuper cash)
        {
            m_Cash = cash;
        }

        public double GetResult(double money)
        {
            return m_Cash.AcceptCash(money);
        }
    }

    /// <summary>
    /// 策略模式结合简单工厂
    /// </summary>
    /// <remarks>如果客户端增加新的收费种类，switch中还需要修改，可以通过反射来避免这种修改</remarks>
    public class SimpleFactoryCashContext
    {
        CashSuper m_Cash = null;

        public SimpleFactoryCashContext(string payType)
        {
            switch (payType)
            {
                case "正常收费":
                    m_Cash = new CashNormal();
                    break;
                case "打7折":
                    m_Cash = new CashRebate("0.7");
                    break;
                case "满50返1块":
                    m_Cash = new CashReturn("50", "1");
                    break;

                default:

                    break;
            }
        }

        public double GetResult(double money)
        {
            return m_Cash.AcceptCash(money);
        }
    }
}
