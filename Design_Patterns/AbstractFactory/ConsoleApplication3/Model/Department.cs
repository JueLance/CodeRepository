﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    public class Department
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _number;

        public int Number
        {
            get { return _number; }
            set { _number = value; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
