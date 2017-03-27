using System;
using System.Threading;

namespace AccessObjectDataCrossAppDomain
{
    /// <summary>
    /// 该类的实例可跨越AppDomain的边界“按引用封送”
    /// </summary>
    public sealed class MarshalByRefType : MarshalByRefObject
    {
        public MarshalByRefType()
        {
            Console.WriteLine("{0} ctor running in {1}", this.GetType().ToString(), Thread.GetDomain().FriendlyName);
        }

        public void SomeMethod()
        {
            Console.WriteLine("Executing in " + Thread.GetDomain().FriendlyName);
        }

        public MarshalByValType MethodWithReturn()
        {
            Console.WriteLine("Executing in " + Thread.GetDomain().FriendlyName);
            MarshalByValType t = new MarshalByValType();
            return t;
        }

        public NonMarshalableType MethodArgAndReturn(String callingDomainName)
        {
            Console.WriteLine("Calling from '{0}' to '{1}'.", callingDomainName, Thread.GetDomain().FriendlyName);

            NonMarshalableType t = new NonMarshalableType();
            return t;

        }

    }
}
