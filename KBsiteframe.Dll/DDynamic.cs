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
    public class DDynamic
    {
        #region
        DbHelper db = new DbHelper();
        private string Vsql = "select * from Dynamic where 1=1{0}";
        //private string Sql = "select * from(select  top 100 percent row_number()over(order by AddTime Desc, IsTop Desc) as DynamicsIndex ,p.*,q.ClassName from Dynamic p left join mycms_class q on p.ClassId=q.Id where 1=1{0}) as T where 1=1{1}";
 


        //public IList<Dynamic> GetDynamicsList(Query q)
        //{
        //    return db.Query<Dynamic>(q, 1, 1000);
        //}
        public IList<Dynamic> GetDynamicsList(Query q, int pageindex, int pagesize, out int totalcount)
        {
            return db.Query<Dynamic>(string.Format(Vsql, q.GetCondition(true)), pageindex, pagesize, out totalcount);
        }
        public IList<Dynamic> GetDynamicsList(Query q)
        {
            return db.Query<Dynamic>(string.Format(Vsql, q.GetCondition(true)));
        }
        public IList<Dynamic> GetDynamicsTitleList(DynamicType dt)
          {
            string sql = "";
            sql = @"select top(11) DynamicID,Title,DynamicType,Uploader,SubTime,IsTop from Dynamic where DynamicType='" + dt.ToString() + "' order by istop desc,SubTime desc";
            //if (dt==DynamicType.联盟动态)
            // sql = @"select top(11) DynamicID,Title,DynamicType,Uploader,SubTime,IsTop from Dynamic where DynamicType='"+dt.ToString()+"' order by istop desc,SubTime desc";
            //else if (dt == DynamicType.团队动态)
            // sql = @"select top(11) DynamicID,Title,DynamicType,Uploader,SubTime,IsTop from Dynamic where DynamicType='" + dt.ToString() + "' order by istop desc,SubTime desc";
            //else
            //throw new Exception("DynamicType error");
            return db.Query<Dynamic>(sql);
        }
        #endregion



        public int Insert(Dynamic m)
        {
            return db.Insert<Dynamic>(m);
        }
        public int Delete(Dynamic m)
        {
            return db.Delete<Dynamic>(m);
        }
        public int Update(Dynamic m)
        {
            return db.Update<Dynamic>(m);
        }

        public Dynamic GetDynamicsById(int newsID)
        {
            return db.GetEntityById<Dynamic>(newsID);
        }

        public int GetMaxID()
        {
            string ret = db.ExecuteScalar("select max(DynamicID) from Dynamic").ToString();
            if (ret == "")
                return 0;
            else
                return int.Parse(ret);
        }

    }
}
