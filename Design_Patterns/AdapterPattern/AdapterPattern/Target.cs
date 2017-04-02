using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdapterPattern
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>这个是客户所期待的接口(可以是具体的类也可以使接口，这里是类)。</remarks>
    public class Target
    {
        public virtual void Request()
        {
            Console.WriteLine("普通请求！");
        }
    }
}
