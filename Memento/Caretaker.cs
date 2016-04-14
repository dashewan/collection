using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    class Caretaker
    {
        public Dictionary<string, ContactMemento> contactMemento { set; get; }
        public Caretaker()
        {
            contactMemento = new Dictionary<string, ContactMemento>();
        }

    }
}
