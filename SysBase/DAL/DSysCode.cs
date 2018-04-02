using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SysBase.Model;
using Z;
using Z.Data;

namespace SysBase.DAL
{
    public class DSysCode
    {
        DbHelper db = new DbHelper();

        #region 基础操作

        public int GetMaxID()
        {
            string ret = db.ExecuteScalar("select max(CodeID) from SysCode").ToString();
            if (ret == "")
                return 0;
            else
                return int.Parse(ret);
        }

        public IList<SysCode> GetSysCodeList(Query q, int pageindex, int pagesize, out int totalcount)
        {
            return db.Query<SysCode>(q, pageindex, pagesize, out totalcount);
        }

        public IList<SysCode> GetSysCodeList(Query q)
        {
            return db.Query<SysCode>(q);
        }

        public SysCode GetCodeByID(int CodeID)
        {
            return db.GetEntityById<SysCode>(CodeID);
        }

        public int Insert(SysCode sc)
        {
            return db.Insert<SysCode>(sc);
        }

        public int Update(SysCode sc)
        {
            return db.Update<SysCode>(sc);
        }

        public int Delete(SysCode sc)
        {
            return db.Delete<SysCode>(sc);
        }

        #endregion

    }
}
