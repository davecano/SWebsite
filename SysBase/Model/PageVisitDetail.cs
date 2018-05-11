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

    [Table(TableName = "PageVisitDetail", PrimaryKeys = "VDetailID")]
    public class PageVisitDetail
    {
        [ColumnAttribute(PrimaryKey = true)]
        public int VDetailID { get; set; }
        public int VisitID { get; set; }
        public string IP { get; set; }
        public DateTime? VTime { get; set; }





        [Ignore]
        public int? Hits { get; set; }
        [Ignore]
         public string PageName { get; set; }



    }
}
