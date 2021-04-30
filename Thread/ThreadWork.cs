using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ThreadAsync
{
    public class ThreadWork
    {
        public ThreadWork()
        {
            ThreadPool.SetMaxThreads(8, 8);
            ThreadPool.SetMinThreads(4, 4);
        }
        public void AsyncWork(int i)
        {
            Thread thread = new Thread(() =>
              {
                  lock (this)
                  {
                      Console.WriteLine(i);
                  }
                 

              });
                thread.Start();
        }
        public void Thread(int i)
        {
            
            ThreadPool.QueueUserWorkItem(new WaitCallback(CallBack),i);
        }
        public void CallBack(object param)
        {
            Console.WriteLine(param);
        }
    }
}
