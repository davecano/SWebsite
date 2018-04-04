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

    [Table(TableName = "Member", PrimaryKeys = "MemberID")]
    public class Member
    {
        [ColumnAttribute(PrimaryKey = true)]
        public int MemberID { get; set; }

        public string MemberType { get; set; }
        public string MenberName { get; set; }
 
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Qualification { get; set; }

        public string Organization { get; set; }

    }
}
