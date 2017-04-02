using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuilderPattern
{
    public class BuildDirector
    {
        PersonBuilder _builder;
        public BuildDirector(PersonBuilder builder)
        {
            _builder = builder;
        }

        public void DrawPerson()
        {
            _builder.BuildHead();
            _builder.BuildBody();
            _builder.BuildArmLeft();
            _builder.BuildArmRight();
            _builder.BuildFootLeft();
            _builder.BuildFootRight();
        }

    }
}
