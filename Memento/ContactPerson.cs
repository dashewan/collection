using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    class ContactPerson
    {
        public ContactPerson( )
        {
            
        }
        public ContactPerson(string name,string mobileNum)
        {
            this.Name = name;
            this.MobileNum = mobileNum;
        }
        public string Name { set; get; }
        public string MobileNum { set; get; }
    }
}
