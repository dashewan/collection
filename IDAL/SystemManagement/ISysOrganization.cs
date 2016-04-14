using Model.SysManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace IDAL.SystemManagement
{
    public interface ISysOrganization<T> : IBaseDAL<T> where T : class
    {
        bool HasChild(string id);
        bool Delete(String id, out string errMsg);
        IQueryable<MyClass> TestMethod();
    }
}
