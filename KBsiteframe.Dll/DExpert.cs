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
    public class DExpert
    {
        #region
        DbHelper db = new DbHelper();
        private string Vsql = "select * from Expert where 1=1{0}";
      
        public IList<Expert> GetExpertsList(Query q, int pageindex, int pagesize, out int totalcount)
        {
            return db.Query<Expert>(string.Format(Vsql, q.GetCondition(true)), pageindex, pagesize, out totalcount);
        }
        public IList<Expert> GetExpertsList(Query q)
        {
            return db.Query<Expert>(string.Format(Vsql, q.GetCondition(true)));
        }
     
        #endregion



        public int Insert(Expert m)
        {
            return db.Insert<Expert>(m);
        }
        public int Delete(Expert m)
        {
            return db.Delete<Expert>(m);
        }
        public int Update(Expert m)
        {
            return db.Update<Expert>(m);
        }

        public Expert GetExpertsById(int newsID)
        {
            return db.GetEntityById<Expert>(newsID);
        }

        public int GetMaxID()
        {
            string ret = db.ExecuteScalar("select max(ExpertID) from Expert").ToString();
            if (ret == "")
                return 0;
            else
                return int.Parse(ret);
        }

    }
}
