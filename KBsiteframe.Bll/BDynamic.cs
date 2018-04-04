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
    public class BDynamic
    {
        DDynamic dd = new DDynamic();

        #region"增删改"
        public int Insert(Dynamic m)
        {
            return dd.Insert(m);
        }
        public int Update(Dynamic m)
        {
            return dd.Update(m);
        }
        public int Delete(Dynamic m)
        {

            return dd.Delete(m);
        }
        #endregion


        /// <summary>
        /// 根据条件查询所有菜单
        /// </summary>
        /// <param name="q"></param>
        /// <returns></returns>
        public IList<Dynamic> GetDynamicsList(Query q, int pageindex, int pagesize, out int totalcount)
        {
            return dd.GetDynamicsList(q, pageindex, pagesize, out totalcount);
        }
        public IList<Dynamic> GetDynamicsList(Query q)
        {
            return dd.GetDynamicsList(q);
        }
  
        public Dynamic GetDynamicsByID(int newsid)
        {
            return dd.GetDynamicsById(newsid);
        }
        public int GetMaxID()
        {
            return dd.GetMaxID();
        }

    }
}
