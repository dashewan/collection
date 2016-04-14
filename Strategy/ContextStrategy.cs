using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    class ContextStrategy
    {
        IStrategy strategy;
        public ContextStrategy(IStrategy strategy)
        {
            this.strategy = strategy;
        }
        public double CalculateTax(double income)
        {
           return strategy.CalculateTax(income);
        }
    }
}
