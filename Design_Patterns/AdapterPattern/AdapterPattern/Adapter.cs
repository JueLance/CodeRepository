using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdapterPattern
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>通过在内部包装一个Adaptee对象，把源接口(Target)转换为目标接口</remarks>
    public class Adapter : Target
    {
        private Adaptee adaptee = new Adaptee();

        public override void Request()
        {
            //base.Request();
            adaptee.SpecificRequest();
        }
    }
}
