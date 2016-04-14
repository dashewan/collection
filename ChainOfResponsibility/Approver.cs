using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    public abstract class Approver
    {
        public Approver approver;
        public Approver NextApprover;
        public string Name;
        public Approver(string name)
        {
            this.Name = name;
        }
        public abstract void ProcessRequest(PurchaseRequest request);
       
    }
}
