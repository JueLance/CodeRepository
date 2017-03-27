using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Remoting;

namespace AccessObjectDataCrossAppDomain
{
    class Program
    {
        static void Main(string[] args)
        {
            //Marshalling_Demo1();

            Marshalling_Demo2();

            //Marshalling_Demo3();
        }

        private static void Marshalling_Demo1()
        {
            AppDomain adCallingThreadDomain = Thread.GetDomain();
            String callingDomainName = adCallingThreadDomain.FriendlyName;
            Console.WriteLine("Default AppDomain's friendly name={0}", callingDomainName);

            string exeAssembly = Assembly.GetEntryAssembly().FullName;
            Console.WriteLine("Main assembly={0}", exeAssembly);

            AppDomain ad2 = null;

            //DEMO 1：使用Marshal-By-Reference进行跨AppDomain通信
            Console.WriteLine("{0}Demo #1", Environment.NewLine);

            //新建一个AppDomain(安全和配置匹配与当前AppDomain)
            ad2 = AppDomain.CreateDomain("AD #2", null, null);

            MarshalByRefType mbrt = null;

            //将我们的程序集加载到新AppDomain中，构造一个对象，把它封送回我们的AppDomain(实际得到对一个代理的引用)
            mbrt = (MarshalByRefType)ad2.CreateInstanceAndUnwrap(exeAssembly, "AccessObjectDataCrossAppDomain.MarshalByRefType");

            Console.WriteLine("Type={0}", mbrt.GetType());

            //证明得到的是一个代理对象的引用
            Console.WriteLine("Is proxy={0}", RemotingServices.IsTransparentProxy(mbrt));

            //看起来像是在MarshalByRefType上调用一个方法，实则不然
            //我们是在代理类型上调用一个方法，代理使线程转至拥有对象的那个AppDomain，并在真实的对象上调用这个方法
            mbrt.SomeMethod();

            AppDomain.Unload(ad2);

            //卸载新的AppDomain后，mbrt引用一个有效的代理对象；代理对象引用一个无效的AppDomain

            try
            {
                //在代理类型上调用一个方法。AppDomain无效，造成抛出一个异常。
                mbrt.SomeMethod();
                Console.WriteLine("Successfull call.");
            }
            catch (AppDomainUnloadedException ex)
            {
                Console.WriteLine("Failed call. " + ex.Message);

            }

        }
        private static void Marshalling_Demo2()
        {
            AppDomain adCallingThreadDomain = Thread.GetDomain();
            String callingDomainName = adCallingThreadDomain.FriendlyName;
            Console.WriteLine("Default AppDomain's friendly name={0}", callingDomainName);

            string exeAssembly = Assembly.GetEntryAssembly().FullName;
            Console.WriteLine("Main assembly={0}", exeAssembly);

            AppDomain ad2 = null;
            MarshalByRefType mbrt = null;

            //DEMO 2：使用Marshal-by-value进行跨AppDomain通信
            Console.WriteLine("{0}Demo #2", Environment.NewLine);


            //新建一个AppDomain(安全和配置匹配与当前AppDomain)
            ad2 = AppDomain.CreateDomain("AD #2", null, null);


            mbrt = (MarshalByRefType)ad2.CreateInstanceAndUnwrap(exeAssembly, "AccessObjectDataCrossAppDomain.MarshalByRefType");

            //对象的方法所返回对象的一个副本；对象按值(而非按引用)封送
            MarshalByValType mbvt = mbrt.MethodWithReturn();

            //证明我们得到的不是对一个代理对象的引用
            Console.WriteLine("Is proxy={0}", RemotingServices.IsTransparentProxy(mbvt));

            //看起来是在MarshalByValType上调用一个方法，实际也是如此
            Console.WriteLine("Returned object created " + mbvt.ToString());

            AppDomain.Unload(ad2);

            try
            {
                Console.WriteLine("Returned object created " + mbvt.ToString());
                Console.WriteLine("Successful call. ");
            }
            catch (AppDomainUnloadedException ex)
            {
                Console.WriteLine("Failed call. " + ex.Message);
            }
        }

        private static void Marshalling_Demo3()
        {
            AppDomain adCallingThreadDomain = Thread.GetDomain();
            String callingDomainName = adCallingThreadDomain.FriendlyName;
            Console.WriteLine("Default AppDomain's friendly name={0}", callingDomainName);

            string exeAssembly = Assembly.GetEntryAssembly().FullName;
            Console.WriteLine("Main assembly={0}", exeAssembly);

            AppDomain ad2 = null;
            MarshalByRefType mbrt = null;

            //DEMO 3:使用不可封送的类型进行跨AppDomain通信
            Console.WriteLine("{0}Demo #3", Environment.NewLine);

            ad2 = AppDomain.CreateDomain("AD #2", null, null);

            //将我们的程序集加载到新AppDomain中，构造一个对象，把它封送回我们的AppDomain(实际得到一个代理的引用)
            mbrt = (MarshalByRefType)ad2.CreateInstanceAndUnwrap(exeAssembly, "AccessObjectDataCrossAppDomain.MarshalByRefType");

            //对象的方法返回一个不可封送的对象，抛出异常
            NonMarshalableType rmt = mbrt.MethodArgAndReturn(callingDomainName);

        }
    }
}
