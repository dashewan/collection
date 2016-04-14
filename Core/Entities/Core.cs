using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Entities
{
    public abstract class DBBase : IDisposable
    //where TEntity : class
    {
        #region Fields and Constructors
        private DbContext _dbc;

        /// <summary>
        /// RyanDing.
        /// 
        /// Pass an existing datacontext and reuse it.
        /// </summary>
        protected DBBase(DbContext dbc)
        {
            _dbc = dbc;
        }

        /// <summary>
        /// RyanDing.
        /// 
        /// Default use a new context.
        /// </summary>
        protected DBBase()
            : this(CreateDataContext())
        {
        }



        #endregion

        #region Private Methods
        private static DbContext CreateDataContext()
        {
            var dbc = new DbContext();
            return dbc;
        }
        #endregion

        #region Public Properties
        public DbContext DataContext
        {
            get { return _dbc; }
            protected set { _dbc = value; }
        }
        #endregion

        #region Public Methods
        public void Dispose()
        {
            if (DataContext != null)
            {
                DataContext.Dispose();
                DataContext = null;
            }
        }

        /// <summary>
        /// 公用分页类
        /// </summary>
        /// <typeparam name="T">数据分页</typeparam>
        /// <param name="DataSource">分页的数据源</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">每一页的起始值</param>
        /// <param name="pageCount">分页后的页数</param>  
        /// <returns>分页后的结果集</returns>
        public static IQueryable<T> Paging<T>(IQueryable<T> DataSource, int pageSize, int pageIndex, out int pageCount)
        {
            int totalRecordCount = DataSource.Count();
            int totalPageCount = 0;

            pageSize = pageSize == 0 ? totalRecordCount : pageSize;

            totalPageCount = totalRecordCount % pageSize == 0 ? totalRecordCount / pageSize : totalRecordCount / pageSize + 1;
            pageCount = totalPageCount;

            IQueryable<T> result = DataSource.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            return result;

        }
        /// <summary>
        /// 公用分页类
        /// </summary>
        /// <typeparam name="T">数据分页</typeparam>
        /// <param name="DataSource">分页的数据源</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">每一页的起始值</param>
        /// <param name="pageCount">分页后的页数</param>  
        /// <returns>分页后的结果集</returns>
        public static IQueryable<T> Paging<T>(IQueryable<T> DataSource, int pageSize, int pageIndex, out int pageCount, out int totalRecordCount)
        {
            totalRecordCount = DataSource.Count();
            int totalPageCount = 0;

            pageSize = pageSize == 0 ? totalRecordCount : pageSize;

            totalPageCount = totalRecordCount % pageSize == 0 ? totalRecordCount / pageSize : totalRecordCount / pageSize + 1;
            pageCount = totalPageCount;

            IQueryable<T> result = DataSource.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            return result;

        }

        /// <summary>
        /// 获取总页数
        /// </summary>
        /// <param name="pageSize">每页行数</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="totalRecordCount">总记录行数</param>
        /// <returns></returns>
        public static int GetPageCount(int pageSize, int pageIndex, int totalRecordCount)
        {
            int totalPageCount = 0;
            pageSize = pageSize == 0 ? totalRecordCount : pageSize;
            totalPageCount = totalRecordCount % pageSize == 0 ? totalRecordCount / pageSize : totalRecordCount / pageSize + 1;
            return totalPageCount;
        }


        #endregion

        #region Public abstract Methods
        //public abstract TEntity GetEntity(int id);
        #endregion
    }
}
