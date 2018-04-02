using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Z.Data
{
    /// <summary>
    /// 表缓存实体数据
    /// </summary>
    class TableInfo
    {
        /// <summary>
        /// 表名称
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 映射的类
        /// </summary>
        public Type ClassType { get; set; }

        /// <summary>
        /// 是否Identity表，如果是 系统返回时则会自动将当前插入值返回。
        /// </summary>
        public bool IdentityTable { get; set; }

    }
}
