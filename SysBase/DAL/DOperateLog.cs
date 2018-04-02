using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SysBase.Model;
using Z;
using Z.Data;

namespace SysBase.DAL
{
    public class DOperateLog
    {
        DbHelper db = new DbHelper();

        #region 基础操作

        public IList<OperateLog> GetOperateLog(Query q, int pageindex, int pagesize, out int totalcount)
        {
            return db.Query<OperateLog>(q, pageindex, pagesize, out totalcount);
        }

        public IList<OperateLog> GetOperateLog(Query q)
        {
            return db.Query<OperateLog>(q);
        }

        public int InsertOperateLog(OperateLog ol)
        {
            return db.Insert<OperateLog>(ol);
        }

        #endregion
    }
}
