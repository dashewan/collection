using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    public class GoldState : State
    {
        public GoldState(State state)
        {
            this.account = state.account;
            this.balance = state.balance;
            
            upperLimit = 1000;
            lowerLimit = 100;
        }
        public override void Deposit(double account)
        {
            balance += account;
            StackChange();
        }

        public override void PayInterest()
        {
            balance += balance* interest;
            StackChange();
        }

        public override void StackChange()
        {
            if (balance < lowerLimit)
            {
                account.state = new SliverState(this);
            }
        }

        public override void WithDraw(double account)
        {
            balance -= account;
            StackChange();
        }
    }
}
