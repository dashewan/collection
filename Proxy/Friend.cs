using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public class Friend : Person
    {
        RealBuyPerson person;
        public override void BuyProduct()
        {
            if (person == null)
            {
                person = new RealBuyPerson();
            }
            person.BuyProduct();
        }
    }
}
