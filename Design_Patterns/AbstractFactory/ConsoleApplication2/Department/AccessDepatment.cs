using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    public class AccessDepatment : IDepartment
    {
        public void Insert(Department department)
        {
            Console.WriteLine("在Access中插入一条Department记录");
        }

        public IDepartment GetSingle(int id)
        {
            Console.WriteLine("在Access数据库中查找Department");
            return null;

        }
    }
}
