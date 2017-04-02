using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    public interface IUser
    {
        void Insert(User user);
        User GetSingle(int id);
    }
}
