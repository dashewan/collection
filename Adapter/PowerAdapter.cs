using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public class PowerAdapter : TwoHold, IThreeHold
    {
        public void Request()
        {
            this.SpecialHold();
        }
    }
}
