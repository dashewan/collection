using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vistor
{
    public class ConcrectVistor : IVistor
    {
        public void Vistor(ElementB b)
        {
            b.Print();
        }

        public void Vistor(ElementA a)
        {
            a.Print();
        }
    }
}
