using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Z
{
    /// <summary>
    /// 分页结果返回
    /// </summary>
    public class Page<T>
    {
        /// <summary>
        /// 返回的结果集
        /// </summary>
        public List<T> Result { get; set; }
        /// <summary>
        /// 返回的记录总数，如果系统没有返回记录总数，则为null。
        /// </summary>
        public int? TotalCount { get; set; }
    }


    /// <summary>
    /// 分页结果返回
    /// </summary>
    public class Page
    {
        /// <summary>
        /// 返回的结果集
        /// </summary>
        public DataTable Result { get; set; }
        /// <summary>
        /// 返回的记录总数
        /// </summary>
        public int? TotalCount { get; set; }
    }
}
