using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Phone phone = new ApplePhone();
            Decorete decorete = new Sticker(phone);
            Decorete d1 = new Accessories(decorete);

            d1.Print();
        }
    }
}
