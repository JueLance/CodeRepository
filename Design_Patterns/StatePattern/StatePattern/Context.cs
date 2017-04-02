using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatePattern
{
    public class Context
    {
        public Context(State state)
        {
            this._State = state;
        }

        private State _State;

        public State State
        {
            get { return _State; }
            set
            {
                _State = value;

                if (_State != null)
                {
                    Console.WriteLine("当前状态：" + _State.GetType().Name);
                }
            }
        }

        public void Request()
        {
            if (_State != null)
            {
                _State.Handle(this);
            }
        }
    }
}
