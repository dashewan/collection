using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    public class CardPartner : AbstractCardPartner
    {
        public override void ChangeCount(int count, AbstractMidator midator)
        {
            midator.AWin(count);
        }
    }
}
