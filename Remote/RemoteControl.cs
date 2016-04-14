using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remote
{
    public class RemoteControl
    {
        private TV implement;

        public TV Implement
        {
            get
            {
                return implement;
            }

            set
            {
                implement = value;
            }
        }

        public virtual void Channel()
        {
            implement.Channel();
        }

        public virtual void Off()
        {
            implement.Off();
        }

        public virtual void On()
        {
            implement.On();
        }
    }
}
