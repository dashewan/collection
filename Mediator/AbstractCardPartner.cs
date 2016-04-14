using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    public abstract class AbstractCardPartner
    {
        public int count;
        public AbstractCardPartner()
        {
            count = 0;
        }
        public abstract void ChangeCount(int count,AbstractMidator midator);
    }
}
