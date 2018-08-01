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

        //public IList<Member> GetShowMemberlist(Query q,int pageindex, int pagesize, out int totalcount)
        //{
        //    string sql = @"select * from Member where MemberType='"+MemberType.普通学生+"'";
        //}


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
        public IList<Member> GetMembersListByGrade(int pageindex, int pagesize, out int totalcount)
        {
             string gsql = "select Grade from Member  where MemberType='" + MemberType.普通学生 + "' group by Grade order by Grade";
            string sql = @"select * from Member where MemberType='"+MemberType.普通学生+"' and Sort>0 order by Sort";
            IList<Member> mlist = db.Query<Member>(sql);
            IList<Member> gmlist= db.Query<Member>(gsql, pageindex, pagesize, out totalcount);
            IList<Member> new_mlist = new List<Member>();
            foreach (var grade in gmlist.Select(p=>p.Grade))
            {
                Member m = new Member();
                m.Grade = grade;
                m.PHD = string.Join(",", mlist.Where(p => p.Grade == grade && p.Qualification == Qualification.博士.ToString())
                    .Select(r => r.MemberName)
                   .ToArray());
                m.Graduate = string.Join(",", mlist.Where(p => p.Grade == grade && p.Qualification == Qualification.硕士.ToString())
                  .Select(r => r.MemberName)
                 .ToArray());
                new_mlist.Add(m);
            }
            return new_mlist;
        }

}
}
