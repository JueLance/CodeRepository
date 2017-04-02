using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            //抽象工厂方式
            //提供一个创建一系列相关或相互依赖对象的接口，而无须指定它们的具体类。实现多对多的依赖，当不同选择有不同的实现方式。
            User user = new User();
            user.Id = 10;
            user.Name = "JueLance";

            IFactory factory = new SqlServerFactory();
            IUser iu = factory.CreateUser();

            iu.Insert(user);
            iu.GetSingle(10);
        }
    }
}
