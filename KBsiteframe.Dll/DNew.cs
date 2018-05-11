using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KBsiteframe.Model;
using Z;
using Z.Data;

namespace KBsiteframe.Dll
{
    public class DNew
    {
        #region
        DbHelper db = new DbHelper();
        private string Vsql = "select * from New where 1=1{0}";
        //private string Sql = "select * from(select  top 100 percent row_number()over(order by AddTime Desc, IsTop Desc) as NewsIndex ,p.*,q.ClassName from New p left join mycms_class q on p.ClassId=q.Id where 1=1{0}) as T where 1=1{1}";
 


        //public IList<New> GetNewsList(Query q)
        //{
        //    return db.Query<New>(q, 1, 1000);
        //}
        public IList<New> GetNewsList(Query q, int pageindex, int pagesize, out int totalcount)
        {
            return db.Query<New>(string.Format(Vsql, q.GetCondition(true)), pageindex, pagesize, out totalcount);
        }
        public IList<New> GetNewsList(Query q)
        {
            return db.Query<New>(string.Format(Vsql, q.GetCondition(true)));
        }
        public IList<New> GetNewsTitleList()
        {//因content过大，过滤掉content
            string sql = @"select top(11) NewsID,Title,Uploader,SubmitTime,Views,IsTop,IsHot,NewsPicPath from New order by  IsTop desc,IsHot desc";
            return db.Query<New>(sql);
        }
        
        //public IList<New> GetNewsList(Query q1, Query q2)
        //{
        //    return db.Query<New>(string.Format(Sql, q1.GetCondition(true), q2.GetCondition(true)));
        //}
        //public IList<New> GetNewsList(string sql, Query q)
        //{
        //    return db.Query<New>(string.Format(sql, q.GetCondition(true)));
        //}
        //public IList<New> GetNewsList(string sql, Query q1, Query q2)
        //{
        //    return db.Query<New>(string.Format(sql, q1.GetCondition(true), q2.GetCondition(true)));
        //}
        //public int getcount(string sql, Query q)
        //{
        //    return (int)db.ExecuteScalar(string.Format(sql, q.GetCondition(false)));

        //}
        #endregion



        public int Insert(New m)
        {
            return db.Insert<New>(m);
        }
        public int Delete(New m)
        {
            return db.Delete<New>(m);
        }
        public int Update(New m)
        {
            return db.Update<New>(m);
        }

        public New GetNewsById(int newsID)
        {
            return db.GetEntityById<New>(newsID);
        }

        public int GetMaxID()
        {
            string ret = db.ExecuteScalar("select max(NewsID) from New").ToString();
            if (ret == "")
                return 0;
            else
                return int.Parse(ret);
        }

    }
}
