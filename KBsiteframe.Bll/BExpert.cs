using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KBsiteframe.Dll;
using KBsiteframe.Model;
using Z;

namespace KBsiteframe.Bll
{
    public class BExpert
    {
        DExpert de = new DExpert();

        #region"增删改"
        public int Insert(Expert m)
        {
            return de.Insert(m);
        }
        public int Update(Expert m)
        {
            return de.Update(m);
        }
        public int Delete(Expert m)
        {

            return de.Delete(m);
        }
        #endregion


        /// <summary>
        /// 根据条件查询所有菜单
        /// </summary>
        /// <param name="q"></param>
        /// <returns></returns>
        public IList<Expert> GetExpertsList(Query q, int pageindex, int pagesize, out int totalcount)
        {
            return de.GetExpertsList(q, pageindex, pagesize, out totalcount);
        }
        public IList<Expert> GetExpertsList(Query q)
        {
            return de.GetExpertsList(q);
        }
  
        public Expert GetExpertsByID(int newsid)
        {
            return de.GetExpertsById(newsid);
        }
        public int GetMaxID()
        {
            return de.GetMaxID();
        }

    }
}
