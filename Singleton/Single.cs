using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
   public class Single
    {
        private static Single single;
        private Single()
        {
           
        }
        private static object obj=new object();
        public static Single getInstance()
        {
            lock (obj) {
                if (single == null)
                {
                    lock (obj) {
                        single = new Single();
                    }
                }
            }
            return single;
        }
    }
}
