using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    class ContactMemento
    {
        public List<ContactPerson> contactPersonBack { set; get; }
        public ContactMemento(List<ContactPerson> contactPersonList)
        {
            this.contactPersonBack = contactPersonList;
        }
    }
}
