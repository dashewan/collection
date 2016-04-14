using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDAL.SystemManagement
{
    public interface ISysModule<T> : IBaseDAL<T> where T : class
    {
         void YourMethod();
    }
}
