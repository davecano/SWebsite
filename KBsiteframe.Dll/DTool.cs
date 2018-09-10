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
    public class DTool
    {
        #region
        DbHelper db = new DbHelper();
        private string Vsql = "select * from Tool where 1=1{0}";
        //private string Sql = "select * from(select  top 100 percent row_number()over(order by AddTime Desc, IsTop Desc) as ToolsIndex ,p.*,q.ClassName from Tool p left join mycms_class q on p.ClassId=q.Id where 1=1{0}) as T where 1=1{1}";
 


        //public IList<Tool> GetToolsList(Query q)
        //{
        //    return db.Query<Tool>(q, 1, 1000);
        //}
        public IList<Tool> GetToolsList(Query q, int pageindex, int pagesize, out int totalcount)
        {
            return db.Query<Tool>(string.Format(Vsql, q.GetCondition(true)), pageindex, pagesize, out totalcount);
        }
        public IList<Tool> GetToolsList(Query q)
        {
            return db.Query<Tool>(string.Format(Vsql, q.GetCondition(true)));
        }
     
        
        #endregion



        public int Insert(Tool m)
        {
            return db.Insert<Tool>(m);
        }
        public int Delete(Tool m)
        {
            return db.Delete<Tool>(m);
        }
        public int Update(Tool m)
        {
            return db.Update<Tool>(m);
        }

        public Tool GetToolsById(int noticeID)
        {
            return db.GetEntityById<Tool>(noticeID);
        }

        public int GetMaxID()
        {
            string ret = db.ExecuteScalar("select max(ToolID) from Tool").ToString();
            if (ret == "")
                return 0;
            else
                return int.Parse(ret);
        }

    }
}
