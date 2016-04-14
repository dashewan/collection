using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFConsole
{
    public class myException : System.Exception
    {
        public myException(string ms)

            : base(ms)
        {

        }
    }
}
