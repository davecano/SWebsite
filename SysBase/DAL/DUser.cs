using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Z;
using Z.Data;
using System.Data.SqlClient;
using SysBase.Model;

namespace SysBase.DAL
{
    public class DUser
    {
        DbHelper db = new DbHelper();
        #region"增删改"
        public int Insert(SysUser m)
        {
            return db.Insert<SysUser>(m);
        }
        public int Update(SysUser m)
        {
            return db.Update<SysUser>(m);
        }
        public int Delete(string Userid)
        {
            string sql1 = "delete from SysUser where userid=@userid";
            string sql2 = "delete from SysUserRole where userid=@userid";
            string sql3 = "delete from SysUserOperate where userid=@userid";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@userid", Userid);
            db.ExecuteNonQuery(System.Data.CommandType.Text, sql2, param);
            db.ExecuteNonQuery(System.Data.CommandType.Text, sql3, param);
            return db.ExecuteNonQuery(System.Data.CommandType.Text, sql1, param);
        }
        #endregion
        public int Exc(string sql)
        {
            return db.ExecuteNonQuery(sql);
        }
        #region"用户操作权限操作"
        public int DeleteByRoleIDAndUserID(int roleid, string Userid)
        {
            string sql = "delete from SysUserOperate where userid=@userid and  OperateID in(select OperateID from SysRoleOperate where RoleID=@roleid)";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@userid", Userid);
            param[1] = new SqlParameter("@roleid", roleid);

            return db.ExecuteNonQuery(System.Data.CommandType.Text, sql, param);
        }
        //public int CoyeRoleOperateToUserOperate(int roleid, string userid)
        //{
        //    string sql = "insert into SysUserOperate select @UserID,operateid from SysRoleOperate  where RoleID=@RoleID";
        //    SqlParameter[] param = new SqlParameter[2];
        //    param[0] = new SqlParameter("@UserID", userid);
        //    param[1] = new SqlParameter("@RoleID", roleid);
        //    return db.ExecuteNonQuery(System.Data.CommandType.Text, sql, param);
        //}
        public int DeleteOperateByUserID(string UserID)
        {
            //---
            string sql = "delete from  SysUserOperate where UserID=@UserID";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@UserID", UserID);
            return db.ExecuteNonQuery(System.Data.CommandType.Text, sql, param);

        }

        /// <summary>
        /// 获取用户的特殊权限
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public IList<UserOperate> GetSpecialOperateByUserID(string UserID)
        {
            string sql = @"select  a.SpecialType ,b.*,c.ModuleCode,c.MenuName,c.MenuSort,c.MenuType,c.ParentMenuID from SysUserOperate a,SysOperate b,SysMenu c 
                            where a.OperateID=b.OperateID and b.MenuID=c.MenuID and a.UserID='" + UserID + "'";
            return db.Query<UserOperate>(sql);
        }
        /// <summary>
        /// 获取用户的角色权限
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public IList<UserOperate> GetOperateByUserID(string UserID)
        {
            string sql = @"select d.*,e.ModuleCode,'1' as SpecialType,e.MenuName,e.MenuSort,e.MenuType,e.ParentMenuID
                            from SysUserRole a,SysRole b,SysRoleOperate c,SysOperate d,SysMenu e
                            where a.RoleID=b.RoleID and b.RoleID=c.RoleID and c.OperateID=d.OperateID and d.MenuID=e.MenuID and b.IsUse=1 
                            and a.UserID='" + UserID + @"'";
            return db.Query<UserOperate>(sql);
        }
        public int InsertUserOperate(SysUserOperate suo)
        {
            return db.Insert<SysUserOperate>(suo);
        }
        public int DeleteUserOperateByOrgID(int OrgID)
        {
            string sql = "delete from SysUserOperate where UserID in(select UserID From Sysuser where OrgID=" + OrgID + ")";
            return db.ExecuteNonQuery(sql);
        }
        #endregion

        public SysUser GetUserByQuery(Query qm)
        {
            return db.GetEntityWithQuery<SysUser>(qm);
        }
        public SysUser GetUserByUserID(string UserID)
        {
            return db.GetEntityById<SysUser>(UserID);
        }
        public SysUser GetUserByUserLoginName(string UserLoginName)
        {
            return db.GetEntityWithSql<SysUser>("select * from sysuser where   UserLoginName='" + UserLoginName + "'");
        }

        public IList<SysUser> GetSendMailUsers( string where)
        {
            return db.Query<SysUser>("select * from sysuser  where isnull(email,'')<>'' "+ where);
        }
        public IList<SysUser> GetLoginUserByUserID(string UserID)
        {
            return db.Query<SysUser>("select * from SysUser where UserID=@0 and isuse=1", new string[] { UserID });
        }
        public IList<SysUser> GetUserList(Query q, int pageindex, int pagesize, out int totalcount)
        {
            return db.Query<SysUser>(q, pageindex, pagesize, out totalcount);
        }

        public IList<SysUser> GetUserList(Query q)
        {
            return db.Query<SysUser>(q);
        }
        public IList<SysUser> GetUserList(string sql)
        {
            return db.Query<SysUser>(sql);
        }
        public IList<SysUser> GetUserListByRoleID(int RoleID)
        {
            string sql = "select su.* from SysUserRole sur left join SysUser su on su.UserID=sur.UserID where sur.RoleID=" + RoleID;
            return db.Query<SysUser>(sql);
        }

    }

    public class DUserRole
    {
        DbHelper db = new DbHelper();

        public int Insert(SysUserRole m)
        {
            return db.Insert<SysUserRole>(m);
        }
        public IList<SysUserRole> GetUserRoleList(Query q, int pageindex, int pagesize)
        {
            return db.Query<SysUserRole>(q, pageindex, pagesize);
        }

        public IList<SysUserRole> GetUserRoleList(Query q)
        {
            return db.Query<SysUserRole>(q);
        }
        public IList<SysUserRole> GetAllUserRole()
        {
            return db.Query<SysUserRole>("select a.*,b.rolename from SysUserRole a,SysRole b where a.roleid=b.roleid");
        }
        public int DeleteByUserID(string UserID)
        {
            string sql = "delete from  SysUserRole where UserID=@UserID";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@UserID", UserID);
            return db.ExecuteNonQuery(System.Data.CommandType.Text, sql, param);

        }
        public int DeleteByRoleID(string RoleID)
        {
            string sql = "delete from  SysUserRole where RoleID=@RoleID";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@RoleID", RoleID);
            return db.ExecuteNonQuery(System.Data.CommandType.Text, sql, param);

        }
        public DataTable GetUserRoleByUserID(string UserID)
        {
            string sql = "select a.*,b.RoleName from  SysUserRole a,SysRole b where a.RoleID=b.RoleID and a.UserID=@UserID";

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@UserID", UserID);
            return db.ExecuteTable(CommandType.Text, sql, param);
        }

        public IList<SysUserRole> GetVistorUserID()
        {
            string sql = @"select * from SysUserRole where RoleID=1";
            return db.Query<SysUserRole>(sql);
        }

        public IList<SysUserRole> GetUserRoleModeByUserID(string UserID)
        {
            string sql = "select a.*,b.RoleName from  SysUserRole a,SysRole b where a.RoleID=b.RoleID and a.UserID=@0";

            return db.Query<SysUserRole>(sql, new string[] { UserID });
        }
        public int DeleteByUserIDAndRoleID(string UserID, int roleid)
        {
            string sql = "delete from  SysUserRole where UserID=@UserID and RoleID=@RoleID";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@UserID", UserID);
            param[1] = new SqlParameter("@RoleID", roleid);
            return db.ExecuteNonQuery(System.Data.CommandType.Text, sql, param);
        }

        public IList<SysRole> GetRoleByUserID(string UserID)
        {
            return db.Query<SysRole>("select b.* from SysUserRole a,SysRole b where a.roleid=b.roleid and a.UserID='" + UserID + "'");
        }

        
    }
}
