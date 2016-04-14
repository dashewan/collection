using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vistor
{
    public class ElementA : Element
    {
        public override void Accept(IVistor vistor)
        {
            vistor.Vistor(this);
        }

        public override void Print()
        {
            Console.WriteLine("ElementA");
        }
    }
}
