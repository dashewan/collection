using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    public class Account
    {
        public State state;
        public string owns;
        public double balance;
        public Account()
        {
            state = new SliverState(0,this);

        }
        public double Balance { get {return state.balance; } }
        public void Deposit(double account)
        {
            state.Deposit(account);
        }
        public void WithDraw(double account)
        {
            state.WithDraw(account);
        }
        public void PayInterest()
        {
            state.PayInterest();
        }
        public string AccountState()
        {
            return state.GetType().Name;
        } 
    }
}
