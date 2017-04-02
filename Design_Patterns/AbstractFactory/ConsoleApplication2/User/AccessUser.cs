using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    public class AccessUser : IUser
    {
        public void Insert(User user)
        {
            Console.WriteLine("在Access数据库中插入一条数据");
        }

        public User GetSingle(int id)
        {
            Console.WriteLine("在SQL Server数据库中查找一条记录");
            return null;
        }
    }
}
