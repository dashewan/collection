using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    public class SliverState : State
    {
        public SliverState(State state):this(state.balance,state.account)
        {
           
        }
        public SliverState(double balance,Account account)
        {
            this.account = account;
            this.balance = balance;

            upperLimit = 100;
            lowerLimit = 0;
        }
        public override void Deposit(double account)
        {
            balance += account;
            StackChange();
        }

        public override void PayInterest()
        {
            balance += balance*interest;
            StackChange();
        }

        public override void StackChange()
        {
            if (balance > upperLimit)
            {
                account.state = new GoldState(this);
            }
            if (balance < lowerLimit)
            {
                account.state = new RedState(this);
            }
        }

        public override void WithDraw(double account)
        {
            balance -= account;
            StackChange();
        }
    }
}
