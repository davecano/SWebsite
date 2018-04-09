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
    public class DNotice
    {
        #region
        DbHelper db = new DbHelper();
        private string Vsql = "select * from Notice where 1=1{0}";
        //private string Sql = "select * from(select  top 100 percent row_number()over(order by AddTime Desc, IsTop Desc) as NoticesIndex ,p.*,q.ClassName from Notice p left join mycms_class q on p.ClassId=q.Id where 1=1{0}) as T where 1=1{1}";
 


        //public IList<Notice> GetNoticesList(Query q)
        //{
        //    return db.Query<Notice>(q, 1, 1000);
        //}
        public IList<Notice> GetNoticesList(Query q, int pageindex, int pagesize, out int totalcount)
        {
            return db.Query<Notice>(string.Format(Vsql, q.GetCondition(true)), pageindex, pagesize, out totalcount);
        }
        public IList<Notice> GetNoticesList(Query q)
        {
            return db.Query<Notice>(string.Format(Vsql, q.GetCondition(true)));
        }
     
        #endregion



        public int Insert(Notice m)
        {
            return db.Insert<Notice>(m);
        }
        public int Delete(Notice m)
        {
            return db.Delete<Notice>(m);
        }
        public int Update(Notice m)
        {
            return db.Update<Notice>(m);
        }

        public Notice GetNoticesById(int noticeID)
        {
            return db.GetEntityById<Notice>(noticeID);
        }

        public int GetMaxID()
        {
            string ret = db.ExecuteScalar("select max(NoticeID) from Notice").ToString();
            if (ret == "")
                return 0;
            else
                return int.Parse(ret);
        }

    }
}
