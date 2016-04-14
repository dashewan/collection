using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vistor
{
    public abstract class Element
    {
        public abstract void Accept(IVistor vistor);
        public abstract void Print();
    }
}
