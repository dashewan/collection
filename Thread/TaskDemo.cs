using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ThreadAsync
{
    public class TaskDemo
    {
        public void TaskTest()
        {
            Task<int> t = new Task<int>(n => Sum((Int32)n), 1000);
            t.Start();
           // t.Wait();
            Task cwt = t.ContinueWith(task => Console.WriteLine("The result is {0}",t.Result));
        }
        public int Sum(int n)
        {
            Int32 sum = 0;
            for (; n > 0; --n)
                checked { sum += n; } //结果溢出，抛出异常
            return sum;
        }

    }
}
