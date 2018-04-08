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
    public class DTreatise
    {
        #region
        DbHelper db = new DbHelper();
        private string Vsql = @"select t.*,e.EName,p.ProjectName,m.MenberName as LmMemberName,m2.MenberName as  TdMemberName   from Treatise t
left join Expert e on t.ExpertID=e.ExpertID
left join Project p on p.ProjectID= t.ProjectID
left join Member m on m.MemberID= t.LmMemberID
left join  Member m2 on m2.MemberID= t.TdMemberID  where 1=1{0}";
   
        public IList<Treatise> GetTreatisesList(Query q, int pageindex, int pagesize, out int totalcount)
        {
            return db.Query<Treatise>(string.Format(Vsql, q.GetCondition(true)), pageindex, pagesize, out totalcount);
        }
        public IList<Treatise> GetTreatisesList(Query q)
        {
            return db.Query<Treatise>(string.Format(Vsql, q.GetCondition(true)));
        }
      
        #endregion



        public int Insert(Treatise m)
        {
            return db.Insert<Treatise>(m);
        }
        public int Delete(Treatise m)
        {
            return db.Delete<Treatise>(m);
        }
        public int Update(Treatise m)
        {
            return db.Update<Treatise>(m);
        }
        public int sqlUpdate(int objID,string type)
        {
            string sql = "";
            if (type== "Expert")
           sql= @"Update  Treatise set ExpertID=null where ExpertID=" + objID;
           else if (type == "Project")
                sql = @"Update  Treatise set ProjectID=null where ProjectID=" + objID;
            else if(type== "LmMemberID")
                sql = @"Update  Treatise set LmMemberID=null where LmMemberID=" + objID;
            else
                sql = @"Update  Treatise set TdMemberID=null where TdMemberID=" + objID;
            return db.ExecuteNonQuery(sql);
        }

        public Treatise GetTreatisesById(int newsID)
        {
            return db.GetEntityById<Treatise>(newsID);
        }

        public int GetMaxID()
        {
            string ret = db.ExecuteScalar("select max(TreatiseID) from Treatise").ToString();
            if (ret == "")
                return 0;
            else
                return int.Parse(ret);
        }

    }
}
