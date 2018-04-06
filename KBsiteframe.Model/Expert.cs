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

    [Table(TableName = "Expert", PrimaryKeys = "ExpertID")]
    public class Expert
    {
        [ColumnAttribute(PrimaryKey = true)]
        public int ExpertID { get; set; }

        public string EPicPath { get; set; }
        public string ESummary { get; set; }

        public string EName { get; set; }
        public string ECountry { get; set; }
        public bool? Istop { get; set; }
        public int? Sort { get; set; }
        public string EIdentification { get; set; }
        

    }
}
