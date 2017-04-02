/**
 * 
 * 适配器模式
 * 
 * 将一类的接口转换成客户希望的另外一个接口，Adapter模式使得原本由于接口不兼容而不能一起工作那些类可以一起工作。 
 * 
 * ***/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdapterPattern.Demo;

namespace AdapterPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //Adapter adapter = new Adapter();
            //adapter.Request();

            Player b = new Forwards("巴蒂尔");
            b.Attack();

            Player m = new Guards("麦克格雷迪");
            m.Attack();

            //Player ym=new Center("姚明");//
            //ym.Attack();
            //ym.Defense();

            //
            Player ym = new Translator("姚明");
            ym.Attack();
            ym.Defense();
        }
    }
}
