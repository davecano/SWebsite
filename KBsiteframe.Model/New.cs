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

    [Table(TableName = "New", PrimaryKeys = "NewsID")]
    public class New
    {
        [ColumnAttribute(PrimaryKey = true)]
        public int NewsID { get; set; }

        public string Title { get; set; }
        public string Uploader { get; set; }
        public DateTime? SubmitTime { get; set; }

        public string NewsContent { get; set; }
        public int? Views { get; set; }
        public bool? IsTop { get; set; }
        public bool? IsHot { get; set; }
        public string NewsPicPath { get; set; }
        public string NewsType { get; set; }
        
        public string summary { get; set; }
        public string StaticType { get; set; }

    }
}
