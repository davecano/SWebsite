using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Z
{
    /// <summary>
    /// 分页分析基础类
    /// 
    /// 需要重载GetCountSql、GetSpecialPageSql2个方法
    /// </summary>
    internal abstract class PaginationBase
    {

        //缓存计算结果
        private static Dictionary<string, string> m_querycache = new Dictionary<string, string>();

        /// <summary>
        /// 缓存分析结果
        /// </summary>
        protected static Dictionary<string, string> QueryCache
        {
            get { return PaginationBase.m_querycache; }
            set { PaginationBase.m_querycache = value; }
        }
        /// <summary>
        /// 待执行的SQL语句
        /// </summary>
        public virtual string SqlString
        { get; set; }

        /// <summary>
        /// 获取执行数量的sql语句
        /// 默认实现：去除Order by后 直接select count(1)
        /// </summary>
        /// <returns></returns>
        public virtual string GetCountSql()
        {
            Regex replaceorderby = new Regex(@"order\s+by.+?$", RegexOptions.IgnoreCase | RegexOptions.RightToLeft);
            return string.Format("SELECT COUNT(1) count FROM ({0}) A", replaceorderby.Replace(SqlString, ""));
        }


        /// <summary>
        /// 获取指定页码数据的查询语句
        /// </summary>
        /// <param name="pageindex">要查询第几页</param>
        /// <param name="pagesize">每页数据数，不分页选择填写0</param>
        /// <returns></returns>
        public abstract string GetSpecialPageSql(int pageindex, int pagesize);


        /// <summary>
        /// 获取指定页码数据的查询语句，默认每页大小10
        /// </summary>
        /// <param name="pageindex">要查询第几页</param>
        /// <returns></returns>
        public string GetSpecialPageSql(int pageindex)
        {
            return GetSpecialPageSql(pageindex, 10);
        }
    }
}
