using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    public interface IDepartment
    {
        void Insert(Department department);
        IDepartment GetSingle(int id);
    }
}
