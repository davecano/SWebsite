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
    public class BNew
    {
        DNew dn = new DNew();

        #region"增删改"
        public int Insert(New m)
        {
            return dn.Insert(m);
        }
        public int Update(New m)
        {
            return dn.Update(m);
        }
        public int Delete(New m)
        {

            return dn.Delete(m);
        }
        #endregion


        /// <summary>
        /// 根据条件查询所有菜单
        /// </summary>
        /// <param name="q"></param>
        /// <returns></returns>
        public IList<New> GetNewsList(Query q, int pageindex, int pagesize, out int totalcount)
        {
            return dn.GetNewsList(q, pageindex, pagesize, out totalcount);
        }
        public IList<New> GetNewsList(Query q)
        {
            return dn.GetNewsList(q);
        }
  
        public New GetNewsByID(int newsid)
        {
            return dn.GetNewsById(newsid);
        }
        public int GetMaxID()
        {
            return dn.GetMaxID();
        }

    }
}
