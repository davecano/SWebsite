using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Z
{
    /// <summary>
    /// 数据库类型
    /// </summary>
    public enum DataBaseType
    {
        /// <summary>
        /// SQLServer数据库2005及以上
        /// </summary>
        SqlServer,
        /// <summary>
        /// Oracle8i 及以上
        /// </summary>
        Oracle,
        /// <summary>
        /// Mysql4 及以上
        /// </summary>
        Mysql,
        /// <summary>
        /// Sqlite文本数据库
        /// </summary>
        SQLite,
        /// <summary>
        /// SqlCompact
        /// </summary>
        SQLCe,
        /// <summary>
        /// IBMDB2的支持
        /// </summary>
        IBMDB2
    }
}
