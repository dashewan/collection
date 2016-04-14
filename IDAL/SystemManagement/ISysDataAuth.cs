using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace IDAL.SystemManagement
{
    public interface ISysDataAuth<T> : IBaseDAL<T> where T : class
    {
        IQueryable<T> GetList(Dictionary<string, string> condition);
        bool Save(List<T> lstdataAuth, out string errMsg);
    }
}
