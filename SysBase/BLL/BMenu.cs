using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SysBase.DAL;
using SysBase.Model;
using System.Data;
using Z;
namespace SysBase.BLL
{
    public class BMenu
    {
        DMenu dm = new DMenu();
        DOperate dop = new DOperate();
        #region"增删改"
        public int Insert(SysMenu m)
        {
            return dm.Insert(m);
        }
        public int Update(SysMenu m)
        {
            return dm.Update(m);
        }
        public int Delete(SysMenu m)
        {
            dop.DeleteByMenuID(m.MenuID);
            return dm.Delete(m);
        }
        #endregion
        public int GetMaxID()
        {
            return dm.GetMaxID();
        }

        /// <summary>
        /// 根据条件查询所有菜单
        /// </summary>
        /// <param name="q"></param>
        /// <returns></returns>
        public IList<SysMenu> GetMenuList(Query q)
        {
            return dm.GetMenuList(q);
        }

        public SysMenu GetSysMenuByID(int menuid)
        {
            return dm.GetSysMenuByID(menuid);
        }
        
        public IList<SysMenu> GetMenuByRoleAndUserOperate(string UserID, string RoleID)
        {
            return dm.GetMenuByRoleAndUserOperate(UserID, RoleID);
        }
    }

    public class BOperate
    {
        DOperate dop = new DOperate();
        public IList<SysOperate> GetOperateList(Query qm)
        {
            return dop.GetOperateList(qm);
        }
        public IList<SysOperate> GetMenuOperate(int MenuID)
        {
            return dop.GetMenuOperate(MenuID);
        }
        public IList<SysOperate> GetMenuOperate()
        {
            return dop.GetMenuOperate();
        }
        public int Insert(SysOperate so)
        { return dop.Insert(so); }
        public int Delete(SysOperate so)
        { return dop.Delete(so); }
        public int DeleteByMenuID(int MenuID)
        { return dop.DeleteByMenuID(MenuID); }
        public int GetMaxID()
        { return dop.GetMaxID(); }
        public bool IsHaveOperareName(int Menuid, string OperareName)
        {
            return dop.IsHaveOperareName(Menuid, OperareName);
        }
        public int GetOperateID(int Menuid, string OperareName)
        {
            return dop.GetOperateID(Menuid, OperareName);
        }
    }
}
