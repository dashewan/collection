using System;

namespace RedisOperate
{
    class Program
    {
        static void Main(string[] args)
        {
            BasicUsage usage = new BasicUsage();
            bool b = usage.SetString("test", "aabc");
           
            Console.WriteLine(usage.GetString("test"));
        }
    }
}
