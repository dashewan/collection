using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    public class Midator : AbstractMidator
    {
        public Midator(AbstractCardPartner cp,AbstractCardPartner cp2) : base(cp,cp2)
        {

        }
        public override void AWin(int count)
        {
            cp.count += count;
            cp2.count -= count;
        }

        public override void BWin(int count)
        {
            cp2.count += count;
            cp.count -= count;
        }
    }
}
