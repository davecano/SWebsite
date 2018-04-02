using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Z;

namespace SysBase.Model
{
    [TableAttribute(TableName = "OperateLog", PrimaryKeys = "LogID")]
    public class OperateLog
    {
        /// <summary>
        /// 日志编号
        /// </summary>
        [ColumnAttribute(PrimaryKey = true)]
        public string LogID { set; get; }

        /// <summary>
        /// 操作人
        /// </summary>
        public string OperateUser { set; get; }

        /// <summary>
        /// 操作页面
        /// </summary>
        public string OpreatorForm { set; get; }

        /// <summary>
        /// 操作内容
        /// </summary>
        public string OpreatorControl { set; get; }

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime? OperateDate { set; get; }
    }
}
