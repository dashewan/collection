using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    public abstract class Interator
    {
        public abstract void Next();
        public abstract int First();
        public abstract void IsDone();
        public abstract int CurrentItem();
    }
}
