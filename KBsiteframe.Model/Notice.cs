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

    [Table(TableName = "Notice", PrimaryKeys = "NoticeID")]
    public class Notice
    {
        [ColumnAttribute(PrimaryKey = true)]
        public int NoticeID { get; set; }

        public string NoticeTitle { get; set; }
        public string NoticeContent { get; set; }
        public string NoticeStatus { get; set; }
        public string CreateUser { get; set; }
        
        public DateTime? CreateDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }

     

    }
}
