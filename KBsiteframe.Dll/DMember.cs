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
    public class DMember
    {
        #region
        DbHelper db = new DbHelper();
        private string Vsql = "select * from Member where 1=1{0}";
   
        public IList<Member> GetMembersList(Query q, int pageindex, int pagesize, out int totalcount)
        {
            return db.Query<Member>(string.Format(Vsql, q.GetCondition(true)), pageindex, pagesize, out totalcount);
        }
        public IList<Member> GetMembersList(Query q)
        {
            return db.Query<Member>(string.Format(Vsql, q.GetCondition(true)));
        }
      
        #endregion



        public int Insert(Member m)
        {
            return db.Insert<Member>(m);
        }
        public int Delete(Member m)
        {
            return db.Delete<Member>(m);
        }
        public int Update(Member m)
        {
            return db.Update<Member>(m);
        }

        public Member GetMembersById(int newsID)
        {
            return db.GetEntityById<Member>(newsID);
        }

        public int GetMaxID()
        {
            string ret = db.ExecuteScalar("select max(MemberID) from Member").ToString();
            if (ret == "")
                return 0;
            else
                return int.Parse(ret);
        }

    }
}
