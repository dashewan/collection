using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace IDAL.SystemManagement
{
    public interface ISysUserRole<T> : IBaseDAL<T> where T : class
    {
        IQueryable<T> GetList(Dictionary<string, string> condition);
        bool Delete(string id, out string errMsg);
    }
}
