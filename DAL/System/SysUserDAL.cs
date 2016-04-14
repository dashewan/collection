using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Reflection;
using System.Data;
using Core.Entities;
using IDAL.SystemManagement;
using Model.SysManagement;
using Core.DBTransaction;
using Core.Log4netHelper;
using log4net;

namespace DAL
{
    public class SysUserDAL : DBBase, ISysUser<SysUser>
    {
        #region ISysUser<SysUser> Members

        public SysUser Login(string userCode, string password)
        {
            DataContext.Configuration.ProxyCreationEnabled = false;
            return DataContext.SysUser.FirstOrDefault(u => u.UserCode == userCode);
            //return DataContext.SysUser.FirstOrDefault(u => u.UserCode == userCode && u.Pwd == password);
        }

        public SysUser GetUserByCode(string userCode)
        {
            return DataContext.SysUser.FirstOrDefault(u => u.UserCode == userCode && u.Active == true);
        }
        /// <summary>
        /// CA SiteMinder根据UserCode获取用户信息
        /// 1.没有启用，更新为启用
        /// 2.没有该用户创建用户
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        public SysUser GetUserByCodeForCA(string userCode)
        {
            SysUser sysUser = DataContext.SysUser.FirstOrDefault(u => u.UserCode == userCode);
            if (sysUser == null)
            {
                sysUser = new SysUser();
                sysUser.SysUserId = Guid.NewGuid().ToString();
                sysUser.UserCode = userCode;
                sysUser.UserName = userCode;
                sysUser.Pwd = "123@Abc#";
                sysUser.RoleId = "d2889917-bc1b-4c60-9ec3-3b3c655de8f2";
                sysUser.ValidDateFrom = DateTime.Now;
                sysUser.ValidDateTo = DateTime.Now.AddYears(99);
                DataContext.SysUser.Add(sysUser);
                SysUserRole userRole = new SysUserRole();
                userRole.SysUserRoleId = Guid.NewGuid().ToString();
                userRole.SysUserId = sysUser.SysUserId;
                userRole.SysRoleId = "d2889917-bc1b-4c60-9ec3-3b3c655de8f2";
                DataContext.SysUserRole.Add(userRole);
                DataContext.SaveChanges();
            }
            else
            {
                if (sysUser.Active == false)
                {
                    sysUser.Active = true;
                    DataContext.SaveChanges();
                }
            }
            return sysUser;
        }

        #endregion

        #region IBaseService<SysUser> Members

        public SysUser Get(int id)
        {
            return null;
        }

        public SysUser Get(string id)
        {
            return DataContext.SysUser.FirstOrDefault(m => m.SysUserId == id);
        }

        #region GetList
        public IQueryable<SysUser> GetList()
        {
            return DataContext.SysUser.OrderByDescending(r => r.UserCode);
        }

        public IQueryable<SysUser> GetList(GridParam gp, Dictionary<string, string> condition, out int pageCount, out int totalCount)
        {
            IQueryable<SysUser> originalSource = DataContext.SysUser.OrderByDescending(r => r.UserCode);
            string UserCode = condition["UserCode"];
            if (!UserCode.IsNullString())
                originalSource = originalSource.Where(o => o.UserCode.Contains(UserCode));

            string UserName = condition["UserName"];
            if (!UserName.IsNullString())
                originalSource = originalSource.Where(o => o.UserName.Contains(UserName));

            string Active = condition["Active"];
            if (!Active.IsNullString())
            {
                DateTime dt = DateTime.Today;
                if (Active == "0")
                {
                    originalSource = originalSource.Where(o => o.Active == false || o.ValidDateTo < dt || o.ValidDateFrom > dt);
                }
                if (Active == "1")
                {
                    originalSource = originalSource.Where(o => o.Active == true && o.ValidDateFrom <= dt && o.ValidDateTo >= dt);
                }
            }

            pageCount = 0;
            totalCount = originalSource.Count();
            originalSource = originalSource.OrderBy(gp.sidx, gp.sord);

            var dataSouce = Paging<SysUser>(originalSource, gp.rows, gp.page, out pageCount);
            return dataSouce;
        }
        #endregion

        #region Save
        private string Transaction(SysUser sysUser)
        {
            try
            {
                if (sysUser.ValidDateTo < sysUser.ValidDateFrom)
                {
                    return "<=ValidDateFromMoreThanValidDateTo>";
                }
                if (string.IsNullOrEmpty(sysUser.SysUserId))
                {
                    if (DataContext.SysUser.Any(c => c.UserCode == sysUser.UserCode))
                    {
                        return "<=UserCodeRepeat>";
                    }
                    sysUser.SysUserId = Guid.NewGuid().ToString();
                    DataContext.SysUser.Add(sysUser);
                }

                if (DataContext.SysUserRole.Count(m => m.SysUserId == sysUser.SysUserId) <= 0)
                {
                    SysUserRole userRole = new SysUserRole();
                    userRole.SysUserRoleId = Guid.NewGuid().ToString();
                    userRole.SysUserId = sysUser.SysUserId;
                    userRole.SysRoleId = sysUser.RoleId;
                    DataContext.SysUserRole.Add(userRole);
                }

                DataContext.SaveChanges();
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public bool Save(SysUser sysUser, out string errMsg)
        {

            errMsg = "";
            try
            {
                string strError = "";
                bool result = DBTransactionExtension.Excute(out errMsg, () =>
                {
                    strError = Transaction(sysUser);
                });
                if (strError != "")
                {
                    errMsg = strError;
                    result = false;
                }
                return result;
            }
            catch (Exception ex)
            {
                errMsg = "<=SaveError>";

                Log4netHelper.LoadADONetAppender();
                ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
                log.Info("Save方法出错。Author:huangyc ", ex);

                return false;
            }
        }
        #endregion

        #region Delete
        public bool Delete(int id)
        {
            return false;
        }

        public bool Delete(string id)
        {
            try
            {
                var user = DataContext.SysUser.FirstOrDefault(f => f.SysUserId == id);
                DataContext.SysUser.Remove(user);
                DataContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #endregion
    }
}
