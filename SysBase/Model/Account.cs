using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Z;

namespace SysBase.Model
{
    [Serializable]
    public class Account
    {
        public SysUser User { set; get; }
        public IList<UserOperate> OperateList { set; get; }
        public ArrayList UserRoleNames { set; get; }
        public ArrayList UserRoleIds { set; get; }
    }

    public class MyUserInfo : EntityBase
    {
        public string UserLoginName { set; get; }
        public string Sex { set; get; }
        public string UserName { set; get; }
        public string IsMain { set; get; }
        public string OrgName { set; get; }
        public string StartDate { set; get; }
        public string EndDate { set; get; }
        public string IsPayUser { set; get; }
        public string RoleNames { set; get; }
        public string LimitAreas { set; get; }
        public bool IsAlertNotice { set; get; }
        public bool IsAlertRss { set; get; }
        public bool IsAlertEvent { set; get; }
    }
}
