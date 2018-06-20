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

    [Table(TableName = "Article", PrimaryKeys = "ArticleID")]
    public class Article
    {
        [ColumnAttribute(PrimaryKey = true)]
        public int ArticleID { get; set; }


        public string ArticleTitle { get; set; }

        public DateTime? SubmitTime { get; set; }
        public string Keyword { get; set; }
        public string Summary { get; set; }
        public string ArticlePath { get; set; }
        public string ArticlePicPath { get; set; }
        public string LanguageType { get; set; }

        public int? Downloads { get; set; }
        public int? Views { get; set; }
        public string Publication { get; set; }
        public string ArticleType { get; set; }
        public string Author { get; set; }
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
        /// <summary>
        /// 项目编号 此文章是否属于某个项目
        /// </summary>
        public int? ProjectID { get; set; }

        [Ignore]
        public string EName { get; set; }
        [Ignore]
        public string ProjectName { get; set; }
        [Ignore]
        public string LmMemberName { get; set; }
        [Ignore]
        public string TdMemberName { get; set; }

    }
}
