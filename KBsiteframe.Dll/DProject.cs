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
    public class DProject
    {
        #region
        DbHelper db = new DbHelper();
        private string Vsql = @"select p.*,e.EName,m.MenberName as LmMemberName,m2.MenberName as  TdMemberName  from Project p left join Expert e on p.ExpertID=e.ExpertID

left join Member m on m.MemberID= p.LmMemberID
left join  Member m2 on m2.MemberID= p.TdMemberID 

 where 1=1{0}";

        public IList<Project> GetProjectsList(Query q, int pageindex, int pagesize, out int totalcount)
        {
            return db.Query<Project>(string.Format(Vsql, q.GetCondition(true)), pageindex, pagesize, out totalcount);
        }
        public IList<Project> GetProjectsList(Query q)
        {
            return db.Query<Project>(string.Format(Vsql, q.GetCondition(true)));
        }

        #endregion



        public int Insert(Project m)
        {
            return db.Insert<Project>(m);
        }
        public int Delete(Project m)
        {
            return db.Delete<Project>(m);
        }
        public int Update(Project m)
        {
            return db.Update<Project>(m);
        }
     
        public int sqlUpdate(int objID, string type)
        {
            string sql = "";
            if (type == "Expert")
                sql = @"Update  Project set ExpertID=null where ExpertID=" + objID;
        
            else if (type == "LmMemberID")
                sql = @"Update  Project set LmMemberID=null where LmMemberID=" + objID;
            else
                sql = @"Update  Project set TdMemberID=null where TdMemberID=" + objID;
            return db.ExecuteNonQuery(sql);
        }
        public Project GetProjectsById(int newsID)
        {
            return db.GetEntityById<Project>(newsID);
        }

        public int GetMaxID()
        {
            string ret = db.ExecuteScalar("select max(ProjectID) from Project").ToString();
            if (ret == "")
                return 0;
            else
                return int.Parse(ret);
        }

    }
}
