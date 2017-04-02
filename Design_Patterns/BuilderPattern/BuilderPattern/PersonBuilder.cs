using System;
using System.Drawing;

namespace BuilderPattern
{
    public abstract class PersonBuilder
    {
        //Graphics grafx;
        //Pen pen;

        public PersonBuilder(Graphics g, Pen p)
        {
            //this.pen = p;
            //this.grafx = g;
        }

        public abstract void BuildHead();
        public abstract void BuildBody();
        public abstract void BuildArmLeft();
        public abstract void BuildArmRight();
        public abstract void BuildFootLeft();
        public abstract void BuildFootRight();

    }
}