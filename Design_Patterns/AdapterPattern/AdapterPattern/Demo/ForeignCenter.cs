using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdapterPattern.Demo
{
    public class ForeignCenter
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public void 进攻()
        {
            Console.WriteLine("外籍中锋{0}进攻", name);
        }

        public void 防守()
        {
            Console.WriteLine("外籍中锋{0}防守", name);
        }
    }
}
