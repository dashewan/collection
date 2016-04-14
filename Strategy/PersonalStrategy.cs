using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    class PersonalStrategy : IStrategy
    {
        public double CalculateTax(double income)
        {
            return (income - 3500) > 0 ? (income - 3500) * 0.045 : 0.0;
        }
    }
}
