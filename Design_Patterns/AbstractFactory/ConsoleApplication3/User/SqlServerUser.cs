using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    public class SqlServerUser : IUser
    {
        public void Insert(User user)
        {
            Console.WriteLine("在SQL Server 数据库中插入一条数据！");
        }

        public User GetSingle(int id)
        {
            Console.WriteLine("根据Id号在SQL Server数据库中查找记录");
            return null;
        }
    }
}
