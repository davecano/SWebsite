using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Z;
namespace SysBase.Model
{
    [TableAttribute(TableName = "SysMenu", PrimaryKeys = "MenuID")]
    public class SysMenu
    {
        [ColumnAttribute(PrimaryKey = true)]
        public int MenuID { set; get; }
        public string MenuName { set; get; }
        public string MenuIco { set; get; }
        public string PageUrl { set; get; }
        public string ModuleCode { set; get; }
        public int? MenuSort { set; get; }
        public bool? IsLeaf { set; get; }
        public int? ParentMenuID { set; get; }
        public string MenuType { set; get; }
        public bool? IsVisiable { set; get; }




    }
    [TableAttribute(TableName = "SysOperate", PrimaryKeys = "OperateID")]
    public class SysOperate
    {
        [ColumnAttribute(PrimaryKey = true)]
        public int OperateID { set; get; }
        public int MenuID { set; get; }
        public string OperateName { set; get; }
    }
    [Serializable]
    public class UserOperate {
        public int OperateID { set; get; }
        public int MenuID { set; get; }
        public string OperateName { set; get; }
        public string ModuleCode { set; get; }
        public bool? SpecialType { set; get; }
        public string MenuName { set; get; }
        public int? MenuSort { set; get; }
        public string MenuType { set; get; }
        public int? ParentMenuID { set; get; }
    }
}
