using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    class Program
    {
        static void Main(string[] args)
        {
            Receiver receiver = new Receiver();

            Command command = new ConcreteCommand(receiver);
            Invoke invoke = new Invoke(command);
            invoke.Run();
        }
    }
}
