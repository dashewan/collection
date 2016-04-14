using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account();
            account.Deposit(20);
            Console.WriteLine("余额"+account.Balance + ",用户类型:"+account.AccountState());
            account.Deposit(50);
            Console.WriteLine("余额" + account.Balance + ",用户类型:" + account.AccountState());
            account.Deposit(50);
            Console.WriteLine("余额" + account.Balance + ",用户类型:" + account.AccountState());
            account.WithDraw(200);
            Console.WriteLine("余额" + account.Balance + ",用户类型:" + account.AccountState());

        }
    }
}
