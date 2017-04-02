/**
 * 
 * 
 * 
 * 用原型实例指定创建对象的种类，并且通过拷贝这些原型来创建新的对象。 目的是为了隐藏对象创建的细节。分为浅复制和深复制两种。
 * 
 * **/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Resume a = new Resume("大鸟");
            a.SetPersonInfo("男", "24");
            a.SetWorkExperience("2011到2012", "xx公司");
            a.Display();

            //Resume b = new Resume("大鸟");
            //b.SetPersonInfo("男", "24");
            //b.SetWorkExperience("2011到2012", "xx公司");
            //b.Display();

            //Resume c = new Resume("大鸟");
            //c.SetPersonInfo("男", "24");
            //c.SetWorkExperience("2011到2012", "xx公司");
            //c.Display();

            Resume b = a;//传的是引用，而不是传值
            Resume c = a;

            b.Display();
            c.Display();


        }
    }
}
