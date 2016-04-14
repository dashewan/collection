using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace IDAL.SystemManagement
{
    public interface ISysUser<T> : IBaseDAL<T> where T : class
    {
        T Login(string userCode, string userPassword);
        T GetUserByCode(string userCode);
        T GetUserByCodeForCA(string userCode);
    }
}
