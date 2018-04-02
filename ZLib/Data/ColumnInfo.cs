using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Z.Data
{
    /// <summary>
    /// 列实体数据缓存
    /// </summary>
    class ColumnInfo
    {
        /// <summary>
        /// 列名称
        /// </summary>
        public string ColumnName { get; set; }

        /// <summary>
        /// Oracle序列名称
        /// </summary>
        public string SeqenceName { get; set; }

        /// <summary>
        /// 是否主键
        /// </summary>
        public bool PrimaryKey { get; set; }

        /// <summary>
        /// 属性名称
        /// </summary>
        public string PropertyName { get; set; }
    }
}
