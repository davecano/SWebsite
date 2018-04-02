using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Z;

namespace SysBase.Model
{
    [TableAttribute(TableName = "SysCode", PrimaryKeys = "CodeID")]
    public class SysCode
    {
        /// <summary>
        /// 字典编号
        /// </summary>
        [ColumnAttribute(PrimaryKey = true)]
        public int CodeID { set; get; }

        /// <summary>
        /// 字典名称
        /// </summary>
        public string CodeName { set; get; }

        /// <summary>
        /// 字典文本
        /// </summary>
        public string CodeText { set; get; }

        /// <summary>
        /// 字典值
        /// </summary>
        public string CodeValue { set; get; }

        /// <summary>
        /// 排序号
        /// </summary>
        public int? SortNo { set; get; }
    }
}
