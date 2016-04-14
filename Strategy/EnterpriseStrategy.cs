using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    class EnterpriseStrategy : IStrategy
    {
        public double CalculateTax(double income)
        {
            return income * 0.12;
        }
    }
}
