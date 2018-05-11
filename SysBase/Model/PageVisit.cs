using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z;

namespace SysBase.Model
{    /// <summary>
     /// mycms_class:实体类(属性说明自动提取数据库字段的描述信息)
     /// </summary>

    [Table(TableName = "PageVisit", PrimaryKeys = "VisitID")]
    public class PageVisit
    {
        [ColumnAttribute(PrimaryKey = true)]
        public int VisitID { get; set; }

        public int? Hits { get; set; }
        public string PageName { get; set; }
      




    }
}
