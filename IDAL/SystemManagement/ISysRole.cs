using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.SysManagement;

namespace IDAL.SystemManagement
{
    public interface ISysRole<T> : IBaseDAL<T> where T : class
    {
        List<CRoleFunctionExport> GetRoleFunctionExport();
        List<CRoleUserExport> GetRoleUserExport();
    }
}
