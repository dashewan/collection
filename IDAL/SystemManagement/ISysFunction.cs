using Model.SysManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace IDAL.SystemManagement
{
    public interface ISysFunction<T> : IBaseDAL<T> where T : class
    {

        List<int> GetMenuGroup(string sysRoleId);
        List<SysFunction> GetMenuFromGroup(string sysRoleId, int intGroupType);
        List<SysFunction> GetUserFunction(string sysRoleId);
        List<SysFunction> GetUserPermission(string sysRoleId);
        List<string> GetOrganizationIds(string sysRoleId);

        bool funcHasChild(string id);
        IQueryable<T> GetList(Dictionary<string, string> condition);
        List<string> GetForwarderCodes(string sysRoleId);

        /// <summary>
        /// 返回方法是否启用的状态
        /// </summary>
        /// <param name="actionName"></param>
        /// <param name="ControllerName"></param>
        /// <returns>true:启用;false:未启用</returns>
        bool GetFunctionInfo(string actionName, string ControllerName);
    }
}
