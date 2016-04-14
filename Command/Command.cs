using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public abstract class Command
    {
        protected Receiver receiver;
        public Command(Receiver receiver)
        {
            this.receiver = new Receiver();
        }
        public abstract void Action();
    }
}
