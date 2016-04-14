using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public class Computer
    {
        List<string> partList = new List<string>();
        public void Add(string part)
        {
            partList.Add(part);
        }
        public void Show()
        {
            foreach(string s in partList)
            {
                Console.WriteLine(s + "正在组装中");
            }
            Console.WriteLine("组装完成");
        }
    }
}
