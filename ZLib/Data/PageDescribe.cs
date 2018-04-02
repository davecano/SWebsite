using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Z.Data
{
    class PageDescribe
    {


        /// <summary>
        /// 待执行的SQL语句
        /// </summary>
        private string SqlString { get; set; }

        /// <summary>
        /// 获取当前数据库
        /// </summary>
        public Z.IDbHelper IDbHelper { get; set; }


        #region 字段和属性

        /// <summary>
        /// 是否使用缓存记录机制(预留)
        /// </summary>
        public bool EnableCache { get; set; }



        /// <summary>
        /// 每页数据数目
        /// </summary>
        public int PageSize { get; set; }


        /// <summary>
        /// 获取记录总数
        /// </summary>
        public virtual int RecordCount
        {
            get { return TotalCount; }
        }

        private int? _totalcount;

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public virtual int TotalCount
        {
            get
            {
                if (_totalcount == null)
                {
                    LoadCount();
                }
                return _totalcount.Value;
            }
        }
        private int m_currentpage;

        /// <summary>
        /// 设置或获取当前页码
        /// </summary>
        public int PageIndex
        {
            get { return m_currentpage; }
            set
            {
                m_currentpage = value;
                if (m_currentpage <= 0)
                {
                    m_currentpage = 1;
                }
            }
        }

        /// <summary>
        /// 根据PageSize获取总页数
        /// </summary>
        public int MaxPage
        {
            get
            {
                int maxpage = _totalcount.Value / PageSize;
                if (_totalcount % PageSize == 0)
                {
                    maxpage++;
                }
                return maxpage;
            }
        }

        #endregion

        #region 根据数据库类型不同选择执行处理方式

        /// <summary>
        /// 分类处理接口
        /// </summary>
        IPagination GetIPagination()
        {
            var dbtype = GetIDbHelper().DBType;
            switch (dbtype)
            {

                case DataBaseType.Oracle:
                    return (IPagination)new OraclePagination();
                case DataBaseType.SQLite:
                case DataBaseType.Mysql:
                    return (IPagination)new MysqlPagination();
                case DataBaseType.SQLCe:
                    throw new NotSupportedException("不支持SqlCompact数据库分页功能");
                case DataBaseType.IBMDB2:
                    return (IPagination)new DB2Pagination();
                default:
                    return (IPagination)new SqlPagination();

            }


        }

        /// <summary>
        /// 获取连接操作
        /// </summary>
        /// <returns></returns>
        IDbHelper GetIDbHelper()
        {

            if (IDbHelper != null)
            {
                return IDbHelper;
            }
            else
            {
                return new DbHelper();
            }
        }


        #endregion
        /// <summary>
        /// 获取当前页(CurrentPage)的数据
        /// </summary>
        /// <returns>当前页的结果</returns>
        public virtual DataTable GetSpecailPage()
        {

            // 获取分析语句分析函数
            var pagination = GetIPagination();
            // 赋值SQL
            pagination.SqlString = SqlString;



            if (PageIndex <= 0)
            {
                PageIndex = 1;
            }



            // DataTable tb = null; // 过期
            var sql = pagination.GetSpecialPageSql(PageIndex, PageSize);

            return GetIDbHelper().ExecuteTable(sql);

        }

        /// <summary>
        /// 分页处理构造函数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pagesize"></param>
        /// <param name="enablecache"></param>
        public PageDescribe(string sql, int pagesize)
        {
            // EnableCache = enablecache;
            // pagination = new Pagination(sql);
            SqlString = sql;
            PageSize = pagesize;


        }

        /// <summary>
        /// 读取记录总数
        /// </summary>
        private void LoadCount()
        {

            IPagination pagination = GetIPagination();
            pagination.SqlString = SqlString;



            var countsql = pagination.GetCountSql();



            object count = GetIDbHelper().ExecuteScalar(pagination.GetCountSql());
            if (count.GetType() == typeof(int))
            {
                _totalcount = (int)count;

            }
            else if (count.GetType() == typeof(decimal))
            {
                _totalcount = int.Parse(count.ToString());
            }
            else if (count.GetType() == typeof(long))
            {
                _totalcount = int.Parse(count.ToString());
            }


        }

        /// <summary>
        /// 是否最后页
        /// </summary>
        /// <param name="page">页码</param>
        /// <returns>若为最后页返回true，否则返回false</returns>
        public virtual bool IsLastPage(int page)
        {
            return page == MaxPage;
        }
        /// <summary>
        /// 关闭连接，已不需要执行。
        /// </summary>
        [Obsolete("该方法已过期，无需执行。")]
        public void Close()
        {

            // helper.Close();
        }


    }
}
