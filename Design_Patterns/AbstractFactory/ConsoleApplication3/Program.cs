using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            //用简单工厂来改进抽象工厂
            User user = new User();
            user.Id = 10;
            user.Name = "JueLance";

            //IFactory factory = new SqlServerFactory();
            //IUser iu = factory.CreateUser();
            DataAccess data = new DataAccess();
            IUser iu = data.CreaterUser();

            iu.Insert(user);
            iu.GetSingle(10);
        }
    }
}
