using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z;

namespace KBsiteframe.Model
{    /// <summary>
     /// mycms_class:实体类(属性说明自动提取数据库字段的描述信息)
     /// </summary>

    [Table(TableName = "Dynamic", PrimaryKeys = "DynamicID")]
    public class Dynamic
    {
        [ColumnAttribute(PrimaryKey = true)]
        public int DynamicID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
        public int? DynamicViews { get; set; }
        public string DynamicType { get; set; }



    }
}
