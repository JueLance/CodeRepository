using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class SqlServerUser
    {
        public void Insert(User user)
        {
            Console.WriteLine("向数据库中添加一条记录");
        }

        public User GetList(int id)
        {
            Console.WriteLine("从数据库中获取记录");
            return null;
        }
    }
}
