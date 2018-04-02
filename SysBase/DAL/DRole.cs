using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Z;
using Z.Data;
using SysBase.Model;

namespace SysBase.DAL
{
    public class DRole
    {
        DbHelper db = new DbHelper();
        #region"增删改"
        public int Insert(SysRole m)
        {
            return db.Insert<SysRole>(m);
        }
        public int Update(SysRole m)
        {
            return db.Update<SysRole>(m);
        }
        public int Delete(SysRole m)
        {
            //递归删除
            return db.Delete<SysRole>(m);
        }
        public int GetMaxID()
        {
            string ret = db.ExecuteScalar("select max(RoleID) from SysRole").ToString();
            if (ret == "")
                return 0;
            else
                return int.Parse(ret);
        }
        #endregion

        public IList<SysRole> GetRoleList(Query q)
        {
            return db.Query<SysRole>(q);
        }

        public IList<SysRole> GetRoleList(Query q, int pageindex, int pagesize, out int totalcount)
        {
            return db.Query<SysRole>(q, pageindex, pagesize, out totalcount);
        }

        public SysRole GetRoleByID(int RoleID)
        {

            return db.GetEntityById<SysRole>(RoleID);
        }
    }

    public class DRoleOperate
    {
        DbHelper db = new DbHelper();
        #region"增删改"
        public int Insert(SysRoleOperate m)
        {
            return db.Insert<SysRoleOperate>(m);
        }
        public int Update(SysRoleOperate m)
        {
            return db.Update<SysRoleOperate>(m);
        }
        public int Delete(SysRoleOperate m)
        {
            return db.Delete<SysRoleOperate>(m);
        }
        public int DeleteByRoleID(int roleid)
        {
            return db.ExecuteNonQuery("delete from sysroleoperate where roleid=" + roleid);
        }
        #endregion
        /// <summary>
        /// 获取角色的操作权限
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        public IList<SysOperate> GetOperateByRoleID(int roleid)
        {
            return db.Query<SysOperate>("select * from sysoperate where operateid in(select operateid from sysroleoperate where roleid=" + roleid + ")");
        }

    }
}
