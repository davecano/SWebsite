using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SysBase.Model;
using SysBase.DAL;
using Z;
using System.Data;

namespace SysBase.BLL
{
    public class BUser
    {
        DUser du = new DUser();
        DUserRole dur = new DUserRole();
        #region"增删改"
        public int Insert(SysUser m)
        {
           
            m.IsUse = true;
            return du.Insert(m);
        }

        public int Update(SysUser m)
        {
            return du.Update(m);
        }
        public int Delete(string userid)
        {
            SysUser su = du.GetUserByUserID(userid);
            if (su.IsMain == true && su.OrgID != null && su.OrgID.ToString() != "")
            {
                Query qm = new Query();
                qm.OrderBy("userid");
                qm.Add("OrgID", (int)su.OrgID);
                IList<SysUser> ls = du.GetUserList(qm);
                foreach (SysUser s in ls)
                {
                    du.Delete(s.UserID);
                }
            }

            du.Delete(userid);

            return 1;
        }
        #endregion

        #region"用户操作权限操作"
        public int DeleteByRoleIDAndUserID(int roleid, string Userid)
        {
            return du.DeleteByRoleIDAndUserID(roleid, Userid);
        }
        /// <summary>
        /// 重置角色下的所有用户权限
        /// </summary>
        /// <param name="RoleID"></param>
        public void ReSetUserRoleOperate(int RoleID)
        {            
            //var qm = Query.Build(new { SortFields = "UserID" });
            //qm.Add("RoleID",RoleID);
            //IList<SysUserRole> lsur = dur.GetUserRoleList(qm, 1, 10000);
            //foreach(SysUserRole sur in lsur)
            //{
            //    //CoyeRoleOperateToUserOperate(sur.RoleID, sur.UserID); 
            //}
        }
        //public int CoyeRoleOperateToUserOperate(int roleid, string userid)
        //{
        //    du.DeleteOperateByUserID(userid);
        //    return du.CoyeRoleOperateToUserOperate(roleid, userid);
        //}

        /// <summary>
        /// 删除用户特殊权限
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public int DeleteOperateByUserID(string UserID)
        {
            return du.DeleteOperateByUserID(UserID);
        }

        /// <summary>
        /// 获取用户角色的操作权限
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public IList<UserOperate> GetUserRoleOperateByUserID(string UserID)
        {

            return du.GetOperateByUserID(UserID);
        
        }

        /// <summary>
        /// 获取用户权限操作列表
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public IList<UserOperate> GetOperateByUserID(string UserID)
        {
            IList<UserOperate> o_r = du.GetOperateByUserID(UserID);
            IList<UserOperate> o_s = du.GetSpecialOperateByUserID(UserID);
            foreach (UserOperate o in o_s)
            {
                if (o.SpecialType != null && o.SpecialType == false)
                {
                    //移除
                    if (o_r.Where<UserOperate>(p => p.OperateID == o.OperateID).ToList<UserOperate>().Count > 0)
                    {
                        o_r.Remove(o_r.First<UserOperate>(p => p.OperateID == o.OperateID));
                    }

                }
                else
                { 
                    //增加特殊权限
                    if (o_r.Where<UserOperate>(p => p.OperateID == o.OperateID).ToList<UserOperate>().Count == 0)
                    {
                        o_r.Add(new UserOperate() { MenuID = o.MenuID,MenuName=o.MenuName,MenuSort=o.MenuSort,MenuType=o.MenuType, ModuleCode = o.ModuleCode, OperateID = o.OperateID, OperateName = o.OperateName, SpecialType = true });
                    }
                }
            }
            return o_r;
        }
        public int InsertUserOperate(SysUserOperate suo)
        {
            return du.InsertUserOperate(suo);
        }
        //删除一个机构下所有用户的特殊权限
        public int DeleteUserOperateByOrgID(int OrgID)
        {
            return du.DeleteUserOperateByOrgID(OrgID);
        }
        #endregion

        public SysUser GetUserByUserLoginName(string UserLoginName)
        {
            return du.GetUserByUserLoginName(UserLoginName);
        }
        public SysUser GetUserByUserID(string UserID)
        {
            return du.GetUserByUserID(UserID);
        }


        /// <summary>
        /// 拷贝一个用户的权限给另一个用户
        /// </summary>
        /// <param name="FromUserID"></param>
        /// <param name="ToUserID"></param>
        public void CopyRoleToOtherUser(string FromUserID, string ToUserID)
        {
            dur.DeleteByUserID(ToUserID);
            DeleteOperateByUserID(ToUserID);
            string sql = @"insert into sysuserrole
                            select RoleID,'" + ToUserID + @"' from sysuserrole where 
                            userid='" + FromUserID + "'";
            du.Exc(sql);
            sql = @"insert into SysUserOperate
                        select '" + ToUserID + @"',OperateID,SpecialType from SysUserOperate where 
                        userid='" + FromUserID + "'";
            du.Exc(sql);



        }
        // 负责主用户的权限给子用户
        public void CopyMainOperateToChild(int OrgID, string MainUserID)
        {
            Query qm = new Query();
            qm.OrderBy("UserID");
            qm.Append("IsPayUser=1 and IsMain<>1 and orgid=" + OrgID);
            IList<SysUser> ls = du.GetUserList(qm);
            foreach (SysUser s in ls)
            {
                CopyRoleToOtherUser(MainUserID, s.UserID);
            }
        }
        public IList<SysUser> GetSendMailUsers(string where)
        {
            return du.GetSendMailUsers(where);
        }
        public SysUser GetUserByTel(string tel)
        {
            Query qm = new Query();
            qm.Add("Tel", tel);
            return du.GetUserByQuery(qm);
        }
        public SysUser GetUserByToken(string Token)
        {
            Query qm = new Query();
            qm.Add("LastToken", Token);
            return du.GetUserByQuery(qm);
        }
        public SysUser GetUserByQuery(Query qm)
        {
            return du.GetUserByQuery(qm);
        }
        public SysUser GetLoginUserByUserID(string UserID)
        {
            IList<SysUser> ls = du.GetLoginUserByUserID(UserID);
            if (ls != null && ls.Count > 0)
            {
                return ls[0];
            }
            else
                return null;
        }
        public IList<SysUser> GetUserList(Query q)
        {
            return du.GetUserList(q);
        }
        public IList<SysUser> GetUserList(Query q, int pageindex, int pagesize, out int totalcount)
        {
            return du.GetUserList(q, pageindex, pagesize, out totalcount);
        }
        public IList<SysUser> GetUserList(string sql)
        {
            return du.GetUserList(sql);
        }

        public bool IsHaveUser(string UserID)
        {
            SysUser su = GetUserByUserID(UserID);
            if (su != null)
            {
                return true;
            }
            else
                return false;
        }
        public IList<SysUserRole> GetUserRoleList(Query q)
        {
            return dur.GetUserRoleList(q);
        }


        public IList<SysUser> GetUserListByRoleID(int RoleID)
        {

            return du.GetUserListByRoleID(RoleID);
        }


    }

    public class BUserRole
    {
        DUserRole dur = new DUserRole();
        DUser du = new DUser();
        public int Insert(SysUserRole sur)
        {
            return dur.Insert(sur);
        }
        public IList<SysUserRole> GetUserRoleList(Query q, int pageindex, int pagesize)
        {
            return dur.GetUserRoleList(q, pageindex, pagesize);
        }
        public IList<SysUserRole> GetUserRoleListByUserID(string UserID)
        {
            return dur.GetUserRoleModeByUserID(UserID);
        }
        public IList<SysUserRole> GetAllUserRole()
        {
            return dur.GetAllUserRole();
        
        }
        public DataTable GetUserRoleByUserID(string UserID)
        {
            return dur.GetUserRoleByUserID(UserID);
        }
        public SysUserRole GetUserRoleModeByUserID(string UserID)
        {
            IList<SysUserRole> isur=dur.GetUserRoleModeByUserID(UserID);
            if (isur != null)
            {
                if (isur.Count > 0)
                    return isur[0];
                else
                    return null;
            }
            else
                return null;
        }
        public int DeleteByUserID(string UserID)
        {
            //取消用户的角色，同步取消特殊权限
            du.DeleteOperateByUserID(UserID);
            return dur.DeleteByUserID(UserID);
        }

        public int DeleteByUserIDAndRoleID(string UserID, int roleid)
        {
            return dur.DeleteByUserIDAndRoleID(UserID, roleid);
        }

        public IList<SysRole> GetRoleByUserID(string UserID)
        {
            return dur.GetRoleByUserID(UserID);
        }

    }
}
