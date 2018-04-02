using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SysBase.DAL;
using SysBase.Model;
using Z;

namespace SysBase.BLL
{
    public class BDepartment
    {

        DDepartment dd = new DDepartment();

        #region 基础操作

        public int GetMaxID()
        {
            return dd.GetMaxID();
        }

        public IList<SysDepartment> GetDepartmentList(Query q, int pageindex, int pagesize, out int totalcount)
        {
            return dd.GetDepartmentList(q, pageindex, pagesize, out totalcount);
        }

        public IList<SysDepartment> GetDepartmentList(Query q)
        {
            return dd.GetDepartmentList(q);
        }

        public SysDepartment GetDepartmentByID(int DepartmentID)
        {
            return dd.GetDepartmentByID(DepartmentID);
        }

        public int Insert(SysDepartment d)
        {
            return dd.Insert(d);
        }

        public int Update(SysDepartment d)
        {
            return dd.Update(d);
        }

        public int Delete(SysDepartment d)
        {
            return dd.Delete(d);
        }

        #endregion
    }
}
