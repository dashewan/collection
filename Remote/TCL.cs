using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remote
{
    public class TCL : TV
    {
        public override void Channel()
        {
            Console.WriteLine("TCL换频道");
        }

        public override void Off()
        {
            Console.WriteLine("TCL关机");
        }

        public override void On()
        {
            Console.WriteLine("TCL开机");
        }
    }
}
