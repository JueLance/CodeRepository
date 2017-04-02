using System;
using System.Drawing;

namespace BuilderPattern
{
    /// <summary>
    /// Description of ThinPerson.
    /// </summary>
    public class ThinPerson : PersonBuilder
    {
        Graphics _g;
        Pen _p;
        public ThinPerson(Graphics g, Pen p)
            : base(g, p)
        {
            _g = g;
            _p = p;
        }

        public override void BuildHead()
        {
            _g.DrawEllipse(_p, 10, 10, 20, 20);
        }

        public override void BuildBody()
        {
            _g.DrawRectangle(_p, 10, 31, 20, 20);
        }

        public override void BuildArmLeft()
        {
            _g.DrawLine(_p, 10, 40, 0, 60);
        }

        public override void BuildArmRight()
        {
            _g.DrawLine(_p, 30, 40, 40, 60);
        }

        public override void BuildFootLeft()
        {
            _g.DrawLine(_p, 20, 50, 0, 70);
        }

        public override void BuildFootRight()
        {
            _g.DrawLine(_p, 20, 50, 40, 70);
        }
    }
}
