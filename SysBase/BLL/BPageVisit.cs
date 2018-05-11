using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysBase.DAL;
using SysBase.Model;
using Z;
using Z.Data;

namespace SysBase.BLL
{
    public class BPageVisit
    {
        DPageVisit dv = new DPageVisit();
        #region

        public IList<PageVisit> GetPageVisitsList(Query q, int pageindex, int pagesize, out int totalcount)
        {
            return dv.GetPageVisitsList(q, pageindex, pagesize, out totalcount);
        }
        public IList<PageVisit> GetPageVisitsList(Query q)
        {
            return dv.GetPageVisitsList(q);
        }




        #endregion
        #region detail
        public IList<PageVisitDetail> GetPageVisitsDetailList(Query q, int pageindex, int pagesize, out int totalcount)
        {
            return dv.GetPageVisitsDetailList(q, pageindex, pagesize, out totalcount);
        }
        public IList<PageVisitDetail> GetPageVisitsDetailList(Query q)
        {
            return dv.GetPageVisitsDetailList(q);
        }
        #endregion

        public int insert(PageVisitDetail pd)
        {
            pd.VDetailID = dv.GetMaxDetailID() + 1;
            pd.VTime = DateTime.Now;

            PageVisit pv = dv.GetPageVisitsByPageName(pd.PageName);
            if (pv != null)
            {
               
                //获取当前页面的VisitID
                pd.VisitID = pv.VisitID;
                // 清除pd中的aspxname
                pd.PageName = null;
                if (dv.InsertDetail(pd) == 1)
                {
                    if (pv.Hits == null)
                        pv.Hits = 0;
                    pv.Hits ++;
                    return dv.Update(pv);
                }
           
            }
            else
            {
                PageVisit pvnew = new PageVisit();
                pvnew.VisitID = dv.GetMaxID() + 1;
                pvnew.Hits = 0;
                pvnew.PageName = pd.PageName;
                if (dv.Insert(pvnew) == 1)
                {
                 
                    //获取当前页面的VisitID
                    pd.VisitID = pvnew.VisitID;
                 // 清除pd中的aspxname
                    pd.PageName = null;
                   
                    if (dv.InsertDetail(pd) == 1)
                    {
                        if (pvnew.Hits == null)
                            pvnew.Hits = 0;
                        pvnew.Hits ++;
                        return dv.Update(pvnew);
                    }
                }
               
            }
            return 0;
        }


        public int GetMaxDetailID()
        {
            return dv.GetMaxDetailID();
        }
        public int GetMaxID()
        {
            return dv.GetMaxID();
        }

    }
}
