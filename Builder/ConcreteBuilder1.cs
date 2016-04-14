using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public class ConcreteBuilder1:Builder
    {
        Computer computer = new Computer();

        public override void BuildCPU()
        {
            computer.Add("CPU");
        }

        public override void BuildMinBoard()
        {
            computer.Add("MinBoard");
        }

        public override Computer GetComputer()
        {
            return computer;
        }


    }
}
