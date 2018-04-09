using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Z;
namespace SysBase.Model
{
    [Serializable]
    [TableAttribute(TableName = "SysUser", PrimaryKeys = "UserID")]
    public class SysUser
    {
        [ColumnAttribute(PrimaryKey = true)]
        public string UserID { set; get; }
        public string UserLoginName { set; get; }
        public string UserName { set; get; }
        public string UserPassword { set; get; }
        public bool? IsMain { set; get; }
        public int? OrgID { set; get; }
        public string OrgName { set; get; }
        public DateTime? LastTime { set; get; }
        public string LastIP { set; get; }
        public bool? IsUse { set; get; }
        public string Sex { set; get; }
        public string Tel { set; get; }
        public string Phone { set; get; }
        public string Email { set; get; }
        public DateTime? RegDate { set; get; }
        
        public string UserStatus { set; get; }
        public string UserType { set; get; }
        public int? LoginTimes { set; get; }
        [Ignore]
        public string RoleIDs { set; get; }
        [Ignore]
        public string RoleNames { set; get; }
    }

    [TableAttribute(TableName = "SysUserRole", PrimaryKeys = "UserID,RoleID")]
    public class SysUserRole
    {
        [ColumnAttribute(PrimaryKey = true)]
        public string UserID { set; get; }
        [ColumnAttribute(PrimaryKey = true)]
        public int RoleID { set; get; }
        [Ignore]
        public string RoleName { set; get; }
    }

    [TableAttribute(TableName = "SysUserOperate", PrimaryKeys = "UserID,OperateID")]
    public class SysUserOperate
    {
        [ColumnAttribute(PrimaryKey = true)]
        public string UserID { set; get; }
        [ColumnAttribute(PrimaryKey = true)]
        public int OperateID { set; get; }
        public bool? SpecialType { set; get; }

    }
}
