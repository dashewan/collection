using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vistor
{
    class Program
    {
        static void Main(string[] args)
        {
            ObjectStructure os = new ObjectStructure();
            foreach(Element el in os.Elements)
            {
                el.Accept(new ConcrectVistor());
            }
        }
    }
}
