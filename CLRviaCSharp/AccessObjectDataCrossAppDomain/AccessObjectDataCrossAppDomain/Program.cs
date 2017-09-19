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


            Marshalling_Demo1();

            //Marshalling_Demo2();

            //Marshalling_Demo3();
        }

        /// <summary>
        /// 
        /// <![CDATA[
        /// 
        /// 
        /// MarshalByRefType类型是从一个非常特殊的基类System.MarshalByRefObject派生的。当CreateInstanceAndUnwrap发现
        /// 它封送的一个对象的类型派生自MarshalByRefObject时，CLR就会跨AppDomain边界按引用封送对象。
        /// 封送一个对象从一个AppDomain到另一个AppDomain的具体含义：
        /// 源AppDomain想向目标AppDomain发送或返回一个对象引用时，CLR会在目标AppDomain的Loader堆中定义
        /// 一个代理类型。这个代理类型是用原始类型的元数据定义的。因此，它看起来和原始类型完全一样——有完全一样的实例成员
        /// (属性、事件和方法)。但是这个实例字段不会称为（代理）类型的一部分。在这个代理类型中，确实定义了几个（自己的）
        /// 实例字段，但这些字段和原始类型的不一致。相反，这些字段只是用于指出哪个AppDomain“拥有”真实的对象，以及如何在
        /// 拥有（对象的）AppDomain中找到真实的对象（在内部，代理对象用一个GCHandle实例引用真实的对象）。
        /// 
        /// 这个代理类型在目标AppDomain中定义好之后，CreateInstanceAndUnwrap方法就会创建这个代理类型的一个实例，初始化
        /// 它的字段来标识源AppDomain和真实对象，然后将对这个代理对象的引用返回目标AppDomain。
        /// 
        /// ]]>
        /// </summary>
        private static void Marshalling_Demo1()
        {
            AppDomain adCallingThreadDomain = Thread.GetDomain();//或者调用AppDomain.CurrentDomain
            String callingDomainName = adCallingThreadDomain.FriendlyName;//默认的名字就是程序集的名字
            Console.WriteLine("Default AppDomain's friendly name={0}", callingDomainName);

            string exeAssembly = Assembly.GetEntryAssembly().FullName;
            Console.WriteLine("Main assembly={0}", exeAssembly);

            AppDomain ad2 = null;

            //DEMO 1：使用Marshal-By-Reference进行跨AppDomain通信
            Console.WriteLine("{0}Demo #1", Environment.NewLine);

            //新建一个AppDomain(安全和配置匹配与当前AppDomain)
            //CreateDomain:在内部，此方法会在进程中创建一个新AppDomain，该AppDomain
            //将被赋予指定的友好名称、安全性和配置设置。新AppDomain有它自己的Loader堆，
            //这个堆目前是空的，因为此时还没有程序集加载到新AppDomain中。
            //创建AppDomain时，CLR不在这个AppDomain中创建任何线程；AppDomain中也没有代码运行，
            //除非你显式地让一个线程调用AppDomain中的代码。
            ad2 = AppDomain.CreateDomain("AD #2", null, null);

            MarshalByRefType mbrt = null;

            //为了在新AppDomain中创建一个类型的实例，首先必须将一个程序集加载到这个新AppDomain中，
            //然后构造这个程序集中定义的一个类型的实例。这就是CreateInstanceAndUnwrap方法所做的事情。

            //在这里，将我们将程序集加载到新AppDomain中，构造一个对象，把它封送回我们的AppDomain(实际得到对一个代理的引用)
            mbrt = (MarshalByRefType)ad2.CreateInstanceAndUnwrap(exeAssembly, "AccessObjectDataCrossAppDomain.MarshalByRefType");
            //其实在这里，ad2.CreateInstanceAndUnwrap()返回的对象实际并不是MarshalByRefType类型的一个实例。
            //CLR一般不允许将一个类型的对象转换成一个不兼容的类型。但在当前这种情况下，CLR允许进行转型，因为新类型具有和原始
            //类型一样的实例成员。因此造成下面的语句中，CLR在撒谎：

            Console.WriteLine("Type={0}", mbrt.GetType());
            //输出：Type=AccessObjectDataCrossAppDomain.MarshalByRefType
            //CLR一般不允许将一个类型的对象转换成一个不兼容的类型。但在当前的情况下CLR允许进行转型。因为
            //新类型具有和原始类型一样的实例成员。
            //在这里，CLR其实撒了一个谎，mbrt.GetType()说自己是AccessObjectDataCrossAppDomain.MarshalByRefType。
            //但下面的代码说明mbrt其实是一个代理类，并非是当前AppDomain中MarshalByRefType的实例

            //即使CLR撒谎，但是可以通过调用System.Runtime.Remoting.RemotingService的公共静态方法IsTransparentProxy()方法
            //并向其传递CreateInstanceAndUnwrap方法返回的引用来证明得到的是MarshalByRefType类型实例的一个代理对象。
            Console.WriteLine("Is proxy={0}", RemotingServices.IsTransparentProxy(mbrt));

            //看起来像是在MarshalByRefType上调用一个方法，实则不然
            //我们是在代理类型上调用一个方法，代理使当前线程转至拥有对象的那个AppDomain(此例为AD #2)，并在真实的对象上调用这个方法
            Console.WriteLine("Proxy class runs on which AppDmian：");
            mbrt.SomeMethod();//真实的SomeMethod方法返回后，会返回至代理的SomeMethod方法，后者(代理类)将线程切换至默认AppDomain
                              //接着线程继续执行默认的AppDomain中的代码。


            AppDomain.Unload(ad2);
            //调用Unload方法，会强制CLR卸载指定的AppDomain（包括加载到其中的所有程序集，所有的Loader堆），并
            //强制执行一次垃圾回收，以释放由卸载的AppDomain中的代码创建的所有对象。

            //卸载新的AppDomain后，mbrt依然引用一个有效的代理对象；但是代理对象却已不再引用一个有效的AppDomain。

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
