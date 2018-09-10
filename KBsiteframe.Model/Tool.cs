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

    [Table(TableName = "Tool", PrimaryKeys = "ToolID")]
    public class Tool
    {
        [ColumnAttribute(PrimaryKey = true)]
        public int ToolID { get; set; }


        public string ToolName { get; set; }


        public string ToolType { get; set; }
        public string ToolPath { get; set; }
        public DateTime? UploadTime { get; set; }

    
        public string Uploader { get; set; }
        public string ToolSuffix { get; set; }

        public string PathType { get; set; }


    }
}
