using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    class MobileOwner
    {
        public List<ContactPerson> ContactPerson { set; get; }
        public MobileOwner(List<ContactPerson> cpList)
        {
            this.ContactPerson = cpList;
        }
        public ContactMemento CreateMemento()
        {
            return new ContactMemento(new List<Memento.ContactPerson>(this.ContactPerson));
        }
        public void RestoreMemento(ContactMemento cm)
        {
            this.ContactPerson = cm.contactPersonBack;
        }
        public void Show()
        {
            foreach(ContactPerson cp in ContactPerson)
            {
                Console.WriteLine("=================");
                Console.WriteLine("姓名：{0}",cp.Name);
                Console.WriteLine("电话号码：{0}", cp.MobileNum);
                Console.WriteLine("=================");
            }
        }
    }
}
