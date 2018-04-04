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
    public class BProject
    {
        DProject de = new DProject();

        #region"增删改"
        public int Insert(Project m)
        {
            return de.Insert(m);
        }
        public int Update(Project m)
        {
            return de.Update(m);
        }
        public int Delete(Project m)
        {

            return de.Delete(m);
        }
        #endregion


        /// <summary>
        /// 根据条件查询所有菜单
        /// </summary>
        /// <param name="q"></param>
        /// <returns></returns>
        public IList<Project> GetProjectsList(Query q, int pageindex, int pagesize, out int totalcount)
        {
            return de.GetProjectsList(q, pageindex, pagesize, out totalcount);
        }
        public IList<Project> GetProjectsList(Query q)
        {
            return de.GetProjectsList(q);
        }
  
        public Project GetProjectsByID(int newsid)
        {
            return de.GetProjectsById(newsid);
        }
        public int GetMaxID()
        {
            return de.GetMaxID();
        }

    }
}
