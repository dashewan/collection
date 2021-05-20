using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadAsync
{
    class Program
    {
        delegate string MyDelegate(string name);
        static void Main(string[] args)
        {
            //Console.WriteLine("我是主线程，线程ID：{0}", Thread.CurrentThread.ManagedThreadId);
            //TestAsync();
            //ThreadPool.SetMaxThreads(8, 8);
            //ThreadPool.SetMinThreads(4, 4);
            //for(int i=0;i<100; i++){
            //    ThreadPool.QueueUserWorkItem(new WaitCallback(Program.callback), i);
            //}
            //ThreadWork work = new ThreadWork();
            //for (int i = 0; i < 100; i++)
            //{
            //    //work.Thread(i);
            //    work.AsyncWork(i);
            //}
            TaskDemo taskDemo = new TaskDemo();
            taskDemo.TaskTest();
            Console.ReadLine();
        }
        public static void callback(object threadContext)
        {
            int threadIndex = (int)threadContext;
            Console.WriteLine($"Thread {threadIndex} started...");
            Console.WriteLine($"Thread {threadIndex} result calculated...");
        }
        static async Task TestAsync()
        {
            Console.WriteLine("调用GetReturnResult()之前，线程ID：{0}。当前时间：{1}", Thread.CurrentThread.ManagedThreadId, DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss"));
            var name = GetReturnResult();
            Console.WriteLine("调用GetReturnResult()之后，线程ID：{0}。当前时间：{1}", Thread.CurrentThread.ManagedThreadId, DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss"));
            Console.WriteLine("得到GetReturnResult()方法的结果：{0}。当前时间：{1}", await name, DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss"));
        }

        static async Task<string> GetReturnResult()
        {
            Console.WriteLine("执行Task.Run之前, 线程ID：{0}", Thread.CurrentThread.ManagedThreadId);
            return await Task.Run(() =>
            {
                Thread.Sleep(3000);
                Console.WriteLine("GetReturnResult()方法里面线程ID: {0}", Thread.CurrentThread.ManagedThreadId);
                return "我是返回值";
            });
        }
        //static void Main(string[] args)
        //{

        //Console.WriteLine(DateTime.Now);
        //var personList=GetPersonList().AsParallel().Where(e => e.Age > 35);
        //Console.WriteLine(DateTime.Now);
        //Console.WriteLine(DateTime.Now);
        //var personList1 = GetPersonList().Where(e => e.Age > 35);
        //Console.WriteLine(DateTime.Now);
        //Console.ReadKey();
        //}
        //static void Completed(IAsyncResult result)
        //{
        //    AsyncResult _result = (AsyncResult)result;
        //    MyDelegate myDelegate = (MyDelegate)_result.AsyncDelegate;
        //    Person person = (Person)_result.AsyncState;
        //    Console.WriteLine(person.Name + "'s age is " + person.Age.ToString());
        //    string data = myDelegate.EndInvoke(_result);
        //    Console.WriteLine(data);
        //}
        static List<Person> GetPersonList()
        {
            var personList = new List<Person>();

            var person1 = new Person();
            person1.Name = "Leslie";
            person1.Age = 31;
            personList.Add(person1);
            var person2 = new Person();
            person2.Name = "Leslie2";
            person2.Age = 32;
            personList.Add(person2);
            var person3 = new Person();
            person3.Name = "Leslie3";
            person3.Age = 33;
            personList.Add(person3);
            var person4 = new Person();
            person4.Name = "Leslie4";
            person4.Age = 34;
            personList.Add(person4);
            var person5 = new Person();
            person5.Name = "Leslie";
            person5.Age = 35;
            personList.Add(person5);
            var person6 = new Person();
            person6.Name = "Leslie6";
            person6.Age = 36;
            personList.Add(person6);
            var person7 = new Person();
            person7.Name = "Leslie7";
            person7.Age = 37;
            personList.Add(person7);
            var person8 = new Person();
            person8.Name = "Leslie8";
            person8.Age = 38;
            personList.Add(person8);
            var person9 = new Person();
            person9.Name = "Leslie";
            person9.Age = 39;
            personList.Add(person9);
            return personList;
        }

        static string Hello(string name)
        {
            ThreadMessage("Async Thread");
            Thread.Sleep(2000);            //虚拟异步工作
            return "Hello " + name;
        }

        //显示当前线程
        static void ThreadMessage(string data)
        {
            string message = string.Format("{0}\n  ThreadId is:{1}",
                   data, Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine(message);
        }
    }
    }
