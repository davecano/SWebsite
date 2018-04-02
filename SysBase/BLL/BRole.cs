using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SysBase.DAL;
using SysBase.Model;
using Z;

namespace SysBase.BLL
{
    public class BRole
    {
        DRole dr = new DRole();
        DRoleOperate dro = new DRoleOperate();
        DUserRole dur = new DUserRole();
        #region"增删改"
        public int Insert(SysRole m)
        {
            return dr.Insert(m);
        }
        public int Update(SysRole m)
        {
            return dr.Update(m);
        }
        public int Delete(SysRole m)
        {
            dur.DeleteByRoleID(m.RoleID.ToString());
            dro.DeleteByRoleID(m.RoleID);
            return dr.Delete(m);
        }
        public int GetMaxID()
        {
            return dr.GetMaxID();
        }
        #endregion

        public IList<SysRole> GetRoleList(Query q)
        {
            return dr.GetRoleList(q);
        }

        public IList<SysRole> GetRoleList(Query q, int pageindex, int pagesize, out int totalcount)
        {
            return dr.GetRoleList(q, pageindex, pagesize, out totalcount);
        }

        public SysRole GetRoleByID(int RoleID)
        {

            return dr.GetRoleByID(RoleID);
        }

        /// <summary>
        /// 获取用户可以选择的角色列表
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public IList<SysRole> GetSysRoleOutByUserID(string UserID)
        {
            Query qm = Query.Build(new { SortFields = "RoleID" });
            qm.Append("RoleID not in(select roleID from  SysUserRole where UserID='" + UserID + "')");
            return dr.GetRoleList(qm);
        }

        public IList<SysRole> GetSysRoleOutByProductCategoryID(string ProductCategoryID)
        {
            Query qm = Query.Build(new { SortFields = "RoleID" });
            qm.Append("RoleID not in(select RoleID from ProductCategoryRole where ProductCategoryID='" + ProductCategoryID + "')");
            return dr.GetRoleList(qm);
        }

        public IList<SysRole> GetSysRoleOutByQualityID(string QualityID)
        {
            Query qm = Query.Build(new { SortFields = "RoleID" });
            qm.Append("RoleID not in(select RoleID from QualificationsRole where QualificationsID='" + QualityID + "')");
            return dr.GetRoleList(qm);
        }
    }

    public class BRoleOperate
    {
        DRoleOperate dro = new DRoleOperate();

        #region"增删改"
        public int Insert(SysRoleOperate m)
        {
            return dro.Insert(m);
        }
        public int Update(SysRoleOperate m)
        {
            return dro.Update(m);
        }
        public int Delete(SysRoleOperate m)
        {
            return dro.Delete(m);
        }
        public int DeleteByRoleID(int roleid)
        {
            return dro.DeleteByRoleID(roleid);
        }
        #endregion

        public IList<SysOperate> GetOperateByRoleID(int roleid)
        {
            return dro.GetOperateByRoleID(roleid);
        }

    }
}
