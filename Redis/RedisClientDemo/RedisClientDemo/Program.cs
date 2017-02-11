using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisClientDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            RedisClient client = new RedisClient("127.0.0.1", 6379);
            int expireTime = 5000;// 5S 
            //var result = client.Add<string>("StringKey", "JueLance", DateTime.Now.AddMilliseconds(expireTime));
            var result = client.Add<string>("StringKey", "JueLance");

            Console.WriteLine($"saved?{result}");

            //if (result)
            //{
            var data = client.Get<string>("StringKey");

            Console.WriteLine(data);
            //}


        }
    }
}
