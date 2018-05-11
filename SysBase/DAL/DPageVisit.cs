using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysBase.Model;
using Z;
using Z.Data;

namespace SysBase.DAL
{
    public class DPageVisit
    {
        #region
        DbHelper db = new DbHelper();
        private string Vsql = "select * from PageVisit where 1=1{0}";

        private string VDsql = " select pd.*,p.PageName,p.Hits from PageVisitDetail  pd left join PageVisit p on p.VisitID=pd.VisitID where 1=1{0}";
        //private string Sql = "select * from(select  top 100 percent row_number()over(order by AddTime Desc, IsTop Desc) as PageVisitsIndex ,p.*,q.ClassName from PageVisit p left join mycms_class q on p.ClassId=q.Id where 1=1{0}) as T where 1=1{1}";



        //public IList<PageVisit> GetPageVisitsList(Query q)
        //{
        //    return db.Query<PageVisit>(q, 1, 1000);
        //}
        public IList<PageVisit> GetPageVisitsList(Query q, int pageindex, int pagesize, out int totalcount)
        {
            return db.Query<PageVisit>(string.Format(Vsql, q.GetCondition(true)), pageindex, pagesize, out totalcount);
        }
        public IList<PageVisit> GetPageVisitsList(Query q)
        {
            return db.Query<PageVisit>(string.Format(Vsql, q.GetCondition(true)));
        }




        #endregion
        #region detail
        public IList<PageVisitDetail> GetPageVisitsDetailList(Query q, int pageindex, int pagesize, out int totalcount)
        {
            return db.Query<PageVisitDetail>(string.Format(VDsql, q.GetCondition(true)), pageindex, pagesize, out totalcount);
        }
        public IList<PageVisitDetail> GetPageVisitsDetailList(Query q)
        {
            return db.Query<PageVisitDetail>(string.Format(VDsql, q.GetCondition(true)));
        }
        #endregion



        public int Insert(PageVisit m)
        {
            return db.Insert<PageVisit>(m);
        }
        public int InsertDetail(PageVisitDetail m)
        {
            return db.Insert<PageVisitDetail>(m);
        }
        public int Delete(PageVisit m)
        {
            return db.Delete<PageVisit>(m);
        }
        public int DeleteDetail(PageVisitDetail m)
        {
            return db.Delete<PageVisitDetail>(m);
        }

        public int Update(PageVisit m)
        {
            return db.Update<PageVisit>(m);
        }
        public int UpdateDetail(PageVisitDetail m)
        {
            return db.Update<PageVisitDetail>(m);
        }

        public PageVisit GetPageVisitsById(int Visitid)
        {
            return db.GetEntityById<PageVisit>(Visitid);
        }
        public PageVisit GetPageVisitsByPageName(string  pagename)
        {
            string sql = "select * from PageVisit where PageName='" + pagename + "'";
            IList<PageVisit> list = db.Query<PageVisit>(sql);
            if (list != null && list.Count > 0)
                return list[0];
            return null;
        }
        public PageVisitDetail GetPageVisitsDetailById(int id)
        {
            return db.GetEntityById<PageVisitDetail>(id);
        }

        public int GetMaxDetailID()
        {
            string ret = db.ExecuteScalar("select max(VDetailID) from PageVisitDetail").ToString();
            if (ret == "")
                return 0;
            else
                return int.Parse(ret);
        }
        public int GetMaxID()
        {
            string ret = db.ExecuteScalar("select max(VisitID) from PageVisit").ToString();
            if (ret == "")
                return 0;
            else
                return int.Parse(ret);
        }

    }
}
