using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFConsole
{
    public class ClassMethod
    {
        public static int myMethod(int v1, int v2)
        {
            return v1 + v2;
        }
        public int myMethod1(int v1, int v2)
        {

            return v1 - v2;

        }
        public int myMethod2(int v1, out int v2)
        {
            v2 = 10;
            return v1+5;

        }
    }
}
