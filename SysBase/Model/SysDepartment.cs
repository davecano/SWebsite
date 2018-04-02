using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Z;

namespace SysBase.Model
{
    [TableAttribute(TableName = "SysDepartment", PrimaryKeys = "DepartmentID")]
    public class SysDepartment
    {
        [ColumnAttribute(PrimaryKey = true)]
        public int DepartmentID { set; get; }

        public string DepartmentName { set; get; }

        public bool? IsUse { set; get; }
    }
}
