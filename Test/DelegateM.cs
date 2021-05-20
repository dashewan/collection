using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class DelegateM
    {
        public  delegate string SetDataGridViewValue(string data);
        public void ActionTest()
        {
            Action<string, string> action1 = new Action<string, string>(ActionMethod);
            action1("aaa", "bbbbb");
        }
        public void ActionMethod(string param1,string param2)
        {
            Console.WriteLine(param1+"   "+param2);
        }
        public void FunTest()
        {
            Func<string,string,string> fun1 = new Func<string, string, string>(FunMethod);
            Console.WriteLine(fun1("cccc", "dddd"));
        }
        public string FunMethod(string param1,string param2)
        {
            return param1 + param2;
        }
        /// <summary>
        /// 5.0,core3不支持BeginInvoke
        /// </summary>
        [Obsolete]
        public void DelegateMethod()
        {
            SetDataGridViewValue sgv = new SetDataGridViewValue(Start);
            //sgv.EventHandler temp = MyEvent;
            //if (temp != null)
            //{
            //    temp();
            //} 
            IAsyncResult result= sgv.BeginInvoke("sss", End, "ddd");
            string r=sgv.EndInvoke(result);
        }
        public string Start(string data)
        {
            Console.WriteLine("Start:" + data);
            return "start";
        }
        public void End(IAsyncResult data)
        {
            Console.WriteLine("End:"+data.AsyncState);
        }
    }
}
