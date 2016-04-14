using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class Decorete : Phone
    {
        private Phone phone;

        public Decorete(Phone phone)
        {
            this.phone = phone;
            Console.WriteLine("Decorete");
        }

        public Phone Phone
        {
            get
            {
                return phone;
            }

            set
            {
                phone = value;
            }
        }

        public override void Print()
        {
            if (phone != null)
            {
                phone.Print();
            }
        }
    }
}
