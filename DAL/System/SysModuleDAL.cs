using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.FrogEntities;
using Model.SysManagement;
using Interface.MasterData.SysManagement;
using Core.ModelValidation;
using System.Web.Mvc;
using Model.MVCExtension;
using Core.DBTransaction;
using Core.Utility;

//namespace FrogTMS
namespace DAL
{
    public class SysModuleDAL : DBBase, ISysModule<SysModule>
    {

        #region ISysModule<SysModule> Members

        public void YourMethod()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IBaseService<SysModule> Members

        public SysModule Get(string id)
        {
            return null;
        }


        public SysModule Get(int id)
        {
            return DataContext.SysModule.FirstOrDefault(m => m.SysModuleId == id);
        }

        public IQueryable<SysModule> GetList()
        {
            return DataContext.SysModule.OrderByDescending(m => m.SysModuleId);
        }


        public IQueryable<SysModule> GetList(GridParam gp, Dictionary<string, string> dicCondtion,
                                                 out int pageCount, out int totalCount)
        {

            IQueryable<SysModule> originalSource = DataContext.SysModule;

            string actionName = dicCondtion["actionName"];
            if (!string.IsNullOrEmpty(actionName))
                originalSource = originalSource.Where(o => o.ActionName.Contains(actionName));

            string moduleName = dicCondtion["moduleName"];
            if (!string.IsNullOrEmpty(moduleName))
                originalSource = originalSource.Where(o => o.ModuleName.Contains(moduleName));

            pageCount = 0;
            totalCount = originalSource.Count();

            originalSource = originalSource.OrderBy(gp.sidx, gp.sord);
            var dataSouce = Paging<SysModule>(originalSource, gp.rows, gp.page, out pageCount);

            return dataSouce;
        }

        private void transaction(SysModule sysModule)
        {
            if (sysModule.SysModuleId == 0)
                DataContext.SysModule.Add(sysModule);
            DataContext.SaveChanges();

            int id = sysModule.SysModuleId;

            var entity = DataContext.SysModule.FirstOrDefault(c => c.SysModuleId == sysModule.SysModuleId);

            var id2 = entity.SysModuleId;
        }

        public bool Save(SysModule sysModule, out string errMsg)
        {
            errMsg = "";
            try
            {
                string errorMsg;

                DBTransactionExtension.Excute(out errorMsg, () => transaction(sysModule));

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int moduleId)
        {
            try
            {
                var module = DataContext.SysModule.FirstOrDefault(f => f.SysModuleId == moduleId);
                DataContext.SysModule.Remove(module);
                DataContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(string moduleId)
        {
            return true;
        }

        #endregion
    }
}
