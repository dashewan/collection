using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remote
{
    public class SanXing : TV
    {
        public override void Channel()
        {
            Console.WriteLine("SanXing换频道");
        }

        public override void Off()
        {
            Console.WriteLine("SanXing关机");
        }

        public override void On()
        {
            Console.WriteLine("SanXing开机");
        }
    }
}
