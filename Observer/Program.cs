using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    
    class Program
    {
        public delegate void NotifyEventHandler(object send);
        public class TenXun
        {
            NotifyEventHandler notify;
            public TenXun(string Symbol, string Name)
            {
                this.Symbol = Symbol;
                this.Name = Name;
            }
            public string Symbol { set; get; }
            public string Name { set; get; }
            public void Add(NotifyEventHandler o)
            {
                notify += o;
            }
            public void Remove(NotifyEventHandler o)
            {
                notify -= o;
            }
            public void update()
            {
                if (notify != null)
                {
                    notify(this);
                }

            }
        }
        public class TenXunGame: TenXun
        {
           public TenXunGame(string Symbol, string Name):base(Symbol, Name)
            {
                
            }
        }
        public class Subscriber
        {
            public void Receive(object o)
            {
                TenXun tx = (TenXun)o;
                Console.WriteLine("{0}----{1}",tx.Name,tx.Symbol);
            }
        }
        static void Main(string[] args)
        {
            TenXun tx = new TenXunGame("aaaaa","bbbbb");
            Subscriber ss = new Subscriber();
            Subscriber ss1 = new Subscriber();
            Subscriber ss2 = new Subscriber();
            tx.Add(new NotifyEventHandler(ss.Receive));
            tx.Add(new NotifyEventHandler(ss1.Receive));
            tx.Add(new NotifyEventHandler(ss2.Receive));
            tx.update();
            //Subject sub =new Subject1();
            //Subject sub1 = new Subject2();
            //Observer ob = new Observer();
            //ob.Add(sub);
            //ob.Add(sub1);
            //ob.Notify();
        }
    }
}
