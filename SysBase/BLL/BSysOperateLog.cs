using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SysBase.DAL;
using SysBase.Model;
using Z;

namespace SysBase.BLL
{
    public class BSysOperateLog
    {
        DSysOperateLog dol= new DSysOperateLog();
        DOperate dop = new DOperate();
        #region"增删改"
        public int Insert(SysOperateLog m)
        {
            return dol.Insert(m);
        }
        public int Update(SysOperateLog m)
        {
            return dol.Update(m);
        }
        public int Delete(SysOperateLog m)
        {
            return dol.Delete(m);

        }
        #endregion
        public int GetMaxID()
        {
            return dol.GetMaxID();
        }
        public IList<SysOperateLog> GetSysOperateLogList(Query q, int pageindex, int pagesize, out int totalcount)
        {
            return dol.GetSysOperateLogList(q, pageindex, pagesize, out totalcount);
        }

        public IList<SysOperateLog> GetSysOperateLogList(Query q)
        {
            return dol.GetSysOperateLogList(q);
        }
        public SysOperateLog GetSysOperateLogByID(string LogID)
        {
            return dol.GetSysOperateLogByID(LogID);
        }
    }
}