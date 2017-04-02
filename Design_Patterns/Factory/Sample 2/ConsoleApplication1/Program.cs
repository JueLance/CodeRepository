using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //工厂模式(区别于简单工厂)
            //其实是将判断放到了客户端来判断
            ISaveModule module = new UserSaveModule();
            ModuleSavor savor = module.CreateSavor();
            Console.WriteLine(savor.Save());

            ISaveModule roleModule = new RoleSaveModule();
            ModuleSavor roleSavor = roleModule.CreateSavor();
            Console.WriteLine(roleSavor.Save());
        }
    }
}
