using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            PurchaseRequest request = new PurchaseRequest(200, "aaaaa");
            Approver a = new Manager("A");
            a.NextApprover = new VicePresident("B");
            a.ProcessRequest(request);
            PurchaseRequest request2 = new PurchaseRequest(20000, "aaaaa");
            a.ProcessRequest(request2);
        }
    }
}
