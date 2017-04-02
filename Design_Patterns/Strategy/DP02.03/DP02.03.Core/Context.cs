
using System;

namespace DP02._03.Core
{
    public class Context
    {
        private Strategy strategy;

        public Context(Strategy strategy)
        {
            this.strategy = strategy;
        }

        public void ContextInterface()
        {
            strategy.Algorithmlnterface();
        }
    }
}