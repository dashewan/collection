using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vistor
{
    public class ElementB : Element
    {
        public override void Accept(IVistor vistor)
        {
            vistor.Vistor(this);
        }

        public override void Print()
        {
            Console.WriteLine("ElementB");
        }
    }
}
