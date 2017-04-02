using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProxyPattern
{
    public class Pursuit : GiveGift
    {
        SchoolGirl mm;
        public Pursuit(SchoolGirl girl)
        {
            mm = new SchoolGirl();
            mm.Name = girl.Name;
        }

        public void GiveChocolate()
        {
            Console.WriteLine(mm.Name + " 送你巧克力");
        }

        public void GiveDolls()
        {
            Console.WriteLine(mm.Name + " 送你洋娃娃");
        }

        public void GiveFlowers()
        {
            Console.WriteLine(mm.Name + " 送你鲜花");
        }


    }
}
