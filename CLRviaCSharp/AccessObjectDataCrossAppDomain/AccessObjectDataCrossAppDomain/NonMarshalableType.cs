using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AccessObjectDataCrossAppDomain
{
    /// <summary>
    /// 该类的实例不能跨AppDomain边界进行封送
    /// </summary>
    //[Serializable]
    public sealed class NonMarshalableType : Object
    {
        public NonMarshalableType()
        {
            Console.WriteLine("Executing in " + Thread.GetDomain().FriendlyName);
        }
    }
}
