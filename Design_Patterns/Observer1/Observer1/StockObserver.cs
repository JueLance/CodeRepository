using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Observer1
{
    public class StockObserver
    {
        private string _name;
        private Secretary _secretary;
        public StockObserver(string name, Secretary secratary)
        {
            _name = name;
            _secretary = secratary;
        }

        public void Update()
        {
            Console.WriteLine("{0},关闭股票软件,继续工作", _name, _secretary.SecretaryAction);
        }
    }
}
