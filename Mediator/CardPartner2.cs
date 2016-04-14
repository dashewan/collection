using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    public class CardPartner2 : AbstractCardPartner
    {
        public override void ChangeCount(int count, AbstractMidator midator)
        {
            midator.BWin(count);
        }
    }
}
