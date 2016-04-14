using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyWeight
{
    public class ConcreteFlyWeight : FlyWeight
    {
        private string instance;

        public string Instance
        {
            get
            {
                return instance;
            }

            set
            {
                instance = value;
            }
        }
        public ConcreteFlyWeight(string instance)
        {
            this.instance = instance;
        }

        public override void Oparetor()
        {
            Console.WriteLine("{0}实例",instance);
        }
    }
}
