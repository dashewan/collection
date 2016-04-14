using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class Accessories:Decorete
    {
        public Accessories(Phone phone) : base(phone)
        {
            Console.WriteLine("Accessories");
        }
        public override void Print()
        {
            base.Print();
            AddAccessories();
        }
        private void AddAccessories()
        {
            Console.WriteLine("有饰品");

        }
    }
}
