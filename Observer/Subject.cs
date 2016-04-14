using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public abstract class Subject
    {
        List<string> strList = new List<string>();
        public abstract void Test();
        public virtual void Inform()
        {
            Console.WriteLine("默认通知");
        }
        public void Test(string aa)
        {

        }
    }
}
