using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Class1
    {
        //每个Thread都有一个关于ApartmentState的属性，可以把它设置为：STA或者MTA，或者UNKNOWN。
        //当你想指定工程的启动窗口的时候，你需要在该窗口类中申明一个Main()方法，并为这个方法设置[STAThread] 属性。
        //[STAThread] 是Single Thread  Apartment单线程套间的意思，是一种线程模型，用在程序的入口方法上
        //（在C#和VB.NET里是Main()方法），来指定当前线程的ApartmentState 是STA。用在其他方法上不产生影响。
        //在aspx页面上可以使用AspCompat = "true" 来达到同样的效果。这个属性只在 Com  Interop 有用，
        //如果全部是 managed  code 则无用。简单的说法:[STAThread]指示应用程序的默认线程模型是单线程单元(STA)。
        //启动线程模型可设置为单线程单元或多线程单元。如果未对其进行设置，则该线程不被初始化。也就是说如果你用的.NET Framework，
        //并且没有使用COM Interop，一般不需要这个Attribute。其它的还有MTA（多线程套间）、Free Thread（自由线程）。
        //单线程套间，简单来说所有对于单线程套间中对象的访问都是通过消息来传递的，所以同一时间只有一个线程能够访问单线程套间中的对象。
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Main thread: start a dedicated thread...");

            Thread th = new Thread(Count);
            th.Start(5);

            Console.WriteLine("Main thread: doing other work here...");

            Thread.Sleep(1000);

            th.Join();
            Console.WriteLine("finished.");
            Console.ReadLine();
        }

        public static void Count(object obj)
        {
            Console.WriteLine("State: {0}", obj);
            Thread.Sleep(1000);
        }
    }
}
