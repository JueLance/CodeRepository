using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    public class SqlServerDepartment : IDepartment
    {
        public void Insert(Department department)
        {
            Console.WriteLine("在SQL Server中插入一条Department记录");
        }

        public IDepartment GetSingle(int id)
        {
            Console.WriteLine("在SQL Server数据库中查找Department");
            return null;

        }
    }
}
