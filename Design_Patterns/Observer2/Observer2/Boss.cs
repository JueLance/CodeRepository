using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Observer2
{
    public class Boss : Subject
    {
        public event UpdateEventHandler Update;
        public string SubjectAction
        {
            get;
            set;
        }

        public void Notify()
        {
            if (Update != null)
            {
                Update();
            }
        }
    }
}
