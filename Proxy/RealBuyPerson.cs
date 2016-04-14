using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public class RealBuyPerson : Person
    {
        public override void BuyProduct()
        {
            Console.WriteLine("真实购买人");
        }
    }
}
