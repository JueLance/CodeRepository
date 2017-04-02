using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Observer2
{
    public interface Subject
    {
        string SubjectAction
        {
            get;
            set;
        }

        void Notify();
    }
}
