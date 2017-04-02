using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    public interface IUser
    {
        void Insert(User user);
        User GetSingle(int id);
    }
}
