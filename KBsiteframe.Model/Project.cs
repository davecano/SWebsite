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

    [Table(TableName = "Project", PrimaryKeys = "ProjectID")]
    public class Project
    {
        [ColumnAttribute(PrimaryKey = true)]
        public int ProjectID { get; set; }
      

        public string ProjectName { get; set; }

      
        public string ProjectContent { get; set; }
 
      
        /// <summary>
        /// 专家编号 用于成果列表
        /// </summary>
        public int? ExpertID { get; set; }
        /// <summary>
        /// 联盟成员编号 用于成果列表
        /// </summary>
        public int? LmMemberID { get; set; }
        /// <summary>
        /// 动态成员编号 用于成果列表
        /// </summary>
        public int? TdMemberID { get; set; }
       
        

    }
}
