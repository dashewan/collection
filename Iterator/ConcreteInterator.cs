using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    public class ConcreteInterator : Interator
    {
        int[] collection;

        int i ;
        public ConcreteInterator(ConcreteAggregate aggregate)
        {
            
        }
        public override int CurrentItem()
        {
            return collection[i];
        }

        public override int First()
        {
            return collection[0];
        }

        public override void IsDone()
        {
            i = 0;
        }

        public override void Next()
        {
            i++;
        }
    }
}
