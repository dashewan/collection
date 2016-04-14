using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrogTMS.Domain.SysManagement;
using System.Web.Mvc;
using FrogTMS.Domain.MVCExtension;

namespace IDAL
{

    public interface IBaseDAL<T> where T : class
    {
        T Get(int id);
        T Get(String id);
        IQueryable<T> GetList();
        bool Save(T entity, out string errMsg);
        bool Delete(int id);
        bool Delete(String id);
    }

}
