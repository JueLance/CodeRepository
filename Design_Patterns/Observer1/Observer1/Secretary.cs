using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Observer1
{
    public class Secretary
    {
        IList<StockObserver> list = new List<StockObserver>();
        public string SecretaryAction
        {
            get;
            set;
        }

        public void Notify()
        {
            foreach (var item in list)
            {
                item.Update();
            }
        }

        public void Attach(StockObserver observer)
        {
            list.Add(observer);
        }
    }
}
