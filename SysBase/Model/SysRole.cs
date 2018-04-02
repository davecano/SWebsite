using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Z;

namespace SysBase.Model
{
    [TableAttribute(TableName = "SysRole", PrimaryKeys = "RoleID")]
    public class SysRole
    {
        [ColumnAttribute(PrimaryKey = true)]
        public int RoleID { set; get; }
        public string RoleName { set; get; }
        public bool? IsUse { set; get; }

    }
    [TableAttribute(TableName = "SysRoleOperate", PrimaryKeys = "RoleID,OperateID")]
    public class SysRoleOperate
    {
        [ColumnAttribute(PrimaryKey = true)]
        public int RoleID { set; get; }
        [ColumnAttribute(PrimaryKey = true)]
        public int OperateID { set; get; }

    }
}
