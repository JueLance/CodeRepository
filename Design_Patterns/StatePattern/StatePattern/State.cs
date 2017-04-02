using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatePattern
{
    public abstract class State
    {
        public abstract void Handle(Context context);
    }
}
