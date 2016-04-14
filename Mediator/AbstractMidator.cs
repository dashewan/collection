using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    public abstract class AbstractMidator
    {
        public AbstractCardPartner cp;
        public AbstractCardPartner cp2;
        public AbstractMidator(AbstractCardPartner cp, AbstractCardPartner cp2)
        {
            this.cp = cp;
            this.cp2 = cp2;
        }
        public abstract void AWin(int count);
        public abstract void BWin(int count);
    }
}
