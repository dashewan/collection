using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            Builder builder1 = new ConcreteBuilder1();
            Builder builder2 = new ConcreteBuilder2();
            Director director = new Director();
            director.Construct(builder1);
            Computer computer1 = builder1.GetComputer();
            computer1.Show();
            director.Construct(builder2);
            Computer computer2 = builder2.GetComputer();
            computer2.Show();
        }
    }
}
