using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PLinqSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.LoadFrom(@"C:\Windows\Microsoft.NET\Framework64\v4.0.30319\System.Core.dll");

            ObsoleteMethods(assembly);
        }

        private static void ObsoleteMethods(Assembly assembly)
        {
            //1.并行且排序
            //var query = from type in assembly.GetExportedTypes().AsParallel().AsOrdered()
            //2.并行
            var query = from type in assembly.GetExportedTypes().AsParallel()
                        from method in type.GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance)
                        let obsoleteAttrType = typeof(ObsoleteAttribute)
                        where Attribute.IsDefined(method, obsoleteAttrType)
                        orderby type.FullName
                        let obsoleteAttrObj = (ObsoleteAttribute)Attribute.GetCustomAttribute(method, obsoleteAttrType)
                        select String.Format("Type={0}\nMethod={1}\nMessage={2}\n", type.FullName, method.ToString(), obsoleteAttrObj.Message);

            //3.同步输出
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }

            //4.并行方式显示结果(多个线程同时调用Console.WriteLine反而会损坏性能，因为Console类本身内部会对
            //线程进行同步，确保每次只有一个线程能访问控制台窗口，避免来自多个线程的文本在最后显示时乱成一团)
            //query.ForAll(x => Console.WriteLine(x));
        }
    }
}
