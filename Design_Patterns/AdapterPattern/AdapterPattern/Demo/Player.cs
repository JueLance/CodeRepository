using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdapterPattern.Demo
{
    public abstract class Player
    {
        protected string name;

        public Player(string name)
        {
            this.name = name;
        }

        public abstract void Attack();
        public abstract void Defense();

    }
}
