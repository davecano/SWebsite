using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Z;
using Z.Data;
using SysBase.Model;
using System.Data;
namespace SysBase.DAL
{
    public class DMenu
    {
        DbHelper db = new DbHelper();
        #region"增删改"
        public int Insert(SysMenu m)
        {
            return db.Insert<SysMenu>(m);
        }
        public int Update(SysMenu m)
        {
            return db.Update<SysMenu>(m);
        }
        public int Delete(SysMenu m)
        {
            //递归删除
            return db.Delete<SysMenu>(m);
        }
        #endregion
        public int GetMaxID()
        {
            string ret = db.ExecuteScalar("select max(MenuID) from SysMenu").ToString();
            if (ret == "")
                return 0;
            else
                return int.Parse(ret);
        }
        /// <summary>
        /// 根据条件查询所有菜单
        /// </summary>
        /// <param name="q"></param>
        /// <returns></returns>
        public IList<SysMenu> GetMenuList(Query q)
        {
            return db.Query<SysMenu>(q, 1, 1000);
        }

        public IList<SysMenu> GetMenuByModulCodel(string str)
        {
            return db.Query<SysMenu>("select * from sysmenu where ModuleCode='" + str + "'");
        }
        public SysMenu GetSysMenuByID(int menuid)
        {

            return db.GetEntityById<SysMenu>(menuid);
        }

        
        public IList<SysMenu> GetMenuByRoleAndUserOperate(string UserID, string RoleID)
        {
            string sql = "select * from SysMenu where MenuID in (select op.MenuID from SysRoleOperate sro left join SysOperate op on op.OperateID=sro.OperateID where op.OperateName='" + PurOperate.查询.ToString() + "' and sro.RoleID in (" + RoleID + ") union select op.MenuID from SysUserOperate suo left join SysOperate op on op.OperateID=suo.OperateID where op.OperateName='" + PurOperate.查询.ToString() + "' and suo.UserID='" + UserID + "')";
            return db.Query<SysMenu>(sql);
        }
    }


    public class DOperate {
        DbHelper db = new DbHelper();
        public IList<SysOperate> GetOperateList(Query qm)
        {
            return db.Query<SysOperate>(qm, 1, 10000);
        }
        public IList<SysOperate> GetMenuOperate(int MenuID)
        {
            return db.Query<SysOperate>("select * from SysOperate where MenuID=" + MenuID.ToString());
        }

        public IList<SysOperate> GetMenuOperate()
        {
            return db.Query<SysOperate>("select * from SysOperate ");
        }

        public int Insert(SysOperate so)
        {
            return db.Insert<SysOperate>(so);
        }
        public int Delete(SysOperate so)
        {
            return db.Delete<SysOperate>(so);
        }
        public int DeleteByMenuID(int MenuID)
        {
            db.ExecuteNonQuery("delete from SysUserOperate where operateID in(select operateID from  SysOperate where menuid=" + MenuID + ")");
            db.ExecuteNonQuery("delete from SysRoleOperate where operateID in(select operateID from  SysOperate where menuid=" + MenuID + ")");
            return db.ExecuteNonQuery("delete from SysOperate where MenuID=" + MenuID.ToString());
        }
        public int GetMaxID()
        {
            string ret = db.ExecuteScalar("select max(OperateID) from SysOperate").ToString();
            if (ret == "")
                return 0;
            else
                return int.Parse(ret);
        }
        public bool IsHaveOperareName(int Menuid, string OperareName)
        {
            DataTable dt = new DataTable();
            dt=db.ExecuteTable("select * from SysOperate where Menuid=" + Menuid + " and OperateName='" + OperareName + "'");
            if (dt.Rows.Count != 0) 
                return true;
            else
                return false;
        }
        public int GetOperateID(int Menuid, string OperareName)
        {
            DataTable dt = db.ExecuteTable("select OperateID from SysOperate where Menuid=" + Menuid + "and OperateName='" + OperareName + "'");
            if (dt.Rows.Count > 0)
                return int.Parse(dt.Rows[0]["OperateID"].ToString());
            else
                return 0;
        }
    }
}
