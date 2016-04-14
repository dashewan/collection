using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    public abstract class State
    {
        public Account account;
        public double upperLimit ;
        public double lowerLimit ;
        public double interest;
        public double balance { set; get; }
        public abstract void Deposit(double account);
        public abstract void WithDraw(double account);
        public abstract void PayInterest();
        public abstract void StackChange();
    }
}
