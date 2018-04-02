using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SysBase.Model;
using Z;
using Z.Data;

namespace SysBase.DAL
{
    public class DSysOperateLog
    {
        DbHelper db = new DbHelper();
        #region"增删改"
        public int Insert(SysOperateLog m)
        {
            return db.Insert<SysOperateLog>(m);
        }
        public int Update(SysOperateLog m)
        {
            return db.Update<SysOperateLog>(m);
        }
        public int Delete(SysOperateLog m)
        {
            //递归删除
            return db.Delete<SysOperateLog>(m);
        }
        #endregion
        public int GetMaxID()
        {
            string ret = db.ExecuteScalar("select max(LogID) from SysOperateLog").ToString();
            if (ret == "")
                return 0;
            else
                return int.Parse(ret);
        }
        //查询
        public IList<SysOperateLog> GetSysOperateLogList(Query q, int pageindex, int pagesize, out int totalcount)
        {
            return db.Query<SysOperateLog>(q, pageindex, pagesize, out totalcount);
        }

        public IList<SysOperateLog> GetSysOperateLogList(Query q)
        {
            return db.Query<SysOperateLog>(q);
        }
        public SysOperateLog GetSysOperateLogByID(string LogID)
        {
            return db.GetEntityById<SysOperateLog>(LogID);
        }
    }
}
