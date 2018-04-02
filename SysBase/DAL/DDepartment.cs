using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SysBase.Model;
using Z;
using Z.Data;

namespace SysBase.DAL
{
    public class DDepartment
    {
        DbHelper db = new DbHelper();

        #region 基础操作

        public int GetMaxID()
        {
            string ret = db.ExecuteScalar("select max(DepartmentID) from SysDepartment").ToString();
            if (ret == "")
                return 0;
            else
                return int.Parse(ret);
        }

        public IList<SysDepartment> GetDepartmentList(Query q, int pageindex, int pagesize, out int totalcount)
        {
            return db.Query<SysDepartment>(q, pageindex, pagesize, out totalcount);
        }

        public IList<SysDepartment> GetDepartmentList(Query q)
        {
            return db.Query<SysDepartment>(q);
        }

        public SysDepartment GetDepartmentByID(int DepartmentID)
        {
            return db.GetEntityById<SysDepartment>(DepartmentID);
        }

        public int Insert(SysDepartment d)
        {
            return db.Insert<SysDepartment>(d);
        }

        public int Update(SysDepartment d)
        {
            return db.Update<SysDepartment>(d);
        }

        public int Delete(SysDepartment d)
        {
            return db.Delete<SysDepartment>(d);
        }

        #endregion

    }
}
