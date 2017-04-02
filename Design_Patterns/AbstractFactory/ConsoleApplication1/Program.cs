using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //模拟普通的操作方式向数据库插入数据
            User user = new User();
            user.Id = 10;
            user.Name = "JueLance";

            SqlServerUser sqlUser = new SqlServerUser();
            sqlUser.Insert(user);

            sqlUser.GetList(10);

        }
    }
}
