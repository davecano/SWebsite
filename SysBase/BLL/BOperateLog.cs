using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SysBase.DAL;
using SysBase.Model;
using Z;

namespace SysBase.BLL
{
    public class BOperateLog
    {
        DOperateLog dol = new DOperateLog();

        #region 基础操作

        public IList<OperateLog> GetOperateLog(Query q, int pageindex, int pagesize, out int totalcount)
        {
            return dol.GetOperateLog(q, pageindex, pagesize, out totalcount);
        }

        public IList<OperateLog> GetOperateLog(Query q)
        {
            return dol.GetOperateLog(q);
        }

        public int InsertOperateLog(OperateLog ol)
        {
            return dol.InsertOperateLog(ol);
        }

        #endregion

    }
}
