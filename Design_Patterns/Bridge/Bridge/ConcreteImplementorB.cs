﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bridge
{
    public class ConcreteImplementorB : Implementor
    {

        public override void Operation()
        {
            Console.WriteLine("具体实现A的方法被执行");
        }
    }
}
