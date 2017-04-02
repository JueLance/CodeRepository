using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BuilderPattern
{
    public class FatPerson : PersonBuilder
    {
        Graphics gragx;
        Pen pen;

        public FatPerson(Graphics g, Pen p)
            : base(g, p)
        {
            gragx = g;
            pen = p;
        }

        public override void BuildHead()
        {
            gragx.DrawRectangle(pen, 100, 100, 200, 200);
        }

        public override void BuildBody()
        {
            gragx.DrawRectangle(pen, 100, 100, 200, 200);
        }

        public override void BuildArmLeft()
        {
            gragx.DrawRectangle(pen, 100, 100, 200, 200);
        }

        public override void BuildArmRight()
        {
            gragx.DrawRectangle(pen, 100, 100, 200, 200);
        }

        public override void BuildFootLeft()
        {
            gragx.DrawRectangle(pen, 100, 100, 200, 200);
        }

        public override void BuildFootRight()
        {
            gragx.DrawRectangle(pen, 100, 100, 200, 200);
        }
    }
}
