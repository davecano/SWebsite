using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Z;

namespace SysBase.Model     
{
    
    [TableAttribute(TableName = "SysOperateLog", PrimaryKeys = "LogID")]
    public class SysOperateLog
    {
        [ColumnAttribute(PrimaryKey = true)]
        public string LogID { set; get; }
        public string LogType { set; get; }
        public string LogObjectID { set; get; }
        public string LogObjectName { set; get; }
        public string OperateUser { set; get; }
        public DateTime? OperateDate { set; get; }
        public string LogOperateType { set; get; }
        public string LogBeforeObject { set; get; }
        public string LogAfterObject { set; get; }
        public string LogRemark { set; get; }
       




    }
    
}
