using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryCore
{
    public class Operation
    {
        private double _NumberA;

        public double NumberA
        {
            get { return _NumberA; }
            set { _NumberA = value; }
        }
        private double _NumberB;

        public double NumberB
        {
            get { return _NumberB; }
            set { _NumberB = value; }
        }

        public virtual double GetResult()
        {
            return 0;
        }

    }
}
