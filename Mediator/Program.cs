using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            AbstractCardPartner cp = new CardPartner();
            AbstractCardPartner cp2 = new CardPartner2();
            AbstractMidator am = new Midator(cp,cp2);
            am.AWin(10);
            Console.WriteLine("1==="+cp.count);
            Console.WriteLine("2===" + cp2.count);
            am.BWin(50);
            Console.WriteLine("1===" + cp.count);
            Console.WriteLine("2===" + cp2.count);
        }
    }
}
