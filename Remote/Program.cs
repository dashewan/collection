using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remote
{
    class Program
    {
        static void Main(string[] args)
        {
            RemoteControl remote =new ConrectRemote();
            remote.Implement = new TCL();
            remote.On();
            remote.Channel();
            remote.Off();
            remote.Implement = new SanXing();
            remote.On();
            remote.Channel();
            remote.Off();
        }
    }
}
