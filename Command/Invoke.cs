using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class Invoke
    {
        Command command;
        public Invoke(Command command)
        {
            this.command = command;
        }
        public void Run()
        {
            command.Action();
        }
    }
}
