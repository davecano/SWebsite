using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Z
{
    /// <summary>
    /// 分页语句分析接口
    /// </summary>
    public interface IPagination
    {
        /// <summary>
        /// 要执行的sql
        /// </summary>
        string SqlString { get; set; }
        /// <summary>
        /// 获取执行数量的sql语句
        /// </summary>
        /// <returns></returns>
        string GetCountSql();
        /// <summary>
        /// 获取指定页码数据的查询语句
        /// </summary>
        /// <param name="pageindex">要查询第几页</param>
        /// <param name="pagesize">每页数据数，不分页选择填写0</param>
        /// <returns></returns>
        string GetSpecialPageSql(int pageindex, int pagesize);
        /// <summary>
        /// 获取指定页码数据的查询语句
        /// </summary>
        /// <param name="pageindex">要查询第几页</param>
        /// <returns>返回获取指定页的语句</returns>
        string GetSpecialPageSql(int pageindex);
    }
}
