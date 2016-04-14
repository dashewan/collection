using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace IDAL.SystemManagement
{
    public interface ISysRoleFunction<T> : IBaseDAL<T> where T : class
    {
        string GetRoleFunc(string sFunctionId, string sRoleId);
        bool Save(List<T> roleFunc, string MenuId, bool deleteAllFlag, out string errMsg);
    }
}
