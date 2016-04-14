using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {

            ContextStrategy s = new ContextStrategy(new PersonalStrategy());
            double d=s.CalculateTax(4000);
            Console.WriteLine(d);
        }
    }
}
