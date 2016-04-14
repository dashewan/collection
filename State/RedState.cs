using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    public class RedState : State
    {
        public RedState(State state)
        {
            this.account = state.account;
            this.balance = state.balance;
          
            upperLimit = 0;
            lowerLimit = -100;
        }
        public override void Deposit(double account)
        {
            balance += account;
            StackChange();
        }

        public override void PayInterest()
        {
            balance += balance * interest;
            StackChange();
        }

        public override void StackChange()
        {
            if (balance > upperLimit)
            {
                account.state = new SliverState(this);
            }
            //if (balance < lowerLimit)
            //{
            //    account.state = new r();
            //}
        }

        public override void WithDraw(double account)
        {
            balance -= account;
            StackChange();
        }
    }
}
