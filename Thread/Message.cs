using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadAsync
{
    public class Message
    {
        public void ShowMessage(object person)
        {
            try {
                if (person != null)
                {
                    Person p = (Person)person;
                    //string message = string.Format("名字：{0}，年龄：{1}，当前线程：{2}，当前上下文：{3}", p.Name, p.Age, Thread.CurrentThread.ManagedThreadId, Thread.CurrentContext.ContextID);
                    //Console.WriteLine(message);
                }
                for (int n = 0; n < 10; n++)
                {
                    if (n > 4)
                    {
                        Thread.CurrentThread.Abort(n);
                    }
                    Thread.Sleep(300);
                    Console.WriteLine("The number is:" + n.ToString());
                }
            }catch(ThreadAbortException e)
            {

                Console.WriteLine(e.Message);
                //Thread.ResetAbort();
            }
        }
    }
    public class Person
    {
        public string Name { set; get; }
        public int Age { set; get; }
    }
}
