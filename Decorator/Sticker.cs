using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class Sticker : Decorete
    {
        public Sticker(Phone phone):base(phone)
        {
            Console.WriteLine("Sticker");
        }
        public override void Print()
        {
            base.Print();
            AddSticker();
        }
        private void AddSticker()
        {
            Console.WriteLine("有贴膜了");
        }
    }
}
