using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SysBase.DAL;
using SysBase.Model;
using Z;

namespace SysBase.BLL
{
    public class BSysCode
    {
        DSysCode dsc = new DSysCode();

        #region 基础操作

        public int GetMaxID()
        {
            return dsc.GetMaxID();
        }

        public IList<SysCode> GetSysCodeList(Query q, int pageindex, int pagesize, out int totalcount)
        {
            return dsc.GetSysCodeList(q, pageindex, pagesize, out totalcount);
        }

        public IList<SysCode> GetSysCodeList(Query q)
        {
            return dsc.GetSysCodeList(q);
        }

        public SysCode GetCodeByID(int CodeID)
        {
            return dsc.GetCodeByID(CodeID);
        }

        public int Insert(SysCode sc)
        {
            return dsc.Insert(sc);
        }

        public int Update(SysCode sc)
        {
            return dsc.Update(sc);
        }

        public int Delete(SysCode sc)
        {
            return dsc.Delete(sc);
        }

        #endregion
    }
}
