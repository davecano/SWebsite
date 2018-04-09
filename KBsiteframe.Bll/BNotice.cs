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
    public class BNotice
    {
        DNotice dd = new DNotice();

        #region"增删改"
        public int Insert(Notice m)
        {
            return dd.Insert(m);
        }
        public int Update(Notice m)
        {
            return dd.Update(m);
        }
        public int Delete(Notice m)
        {

            return dd.Delete(m);
        }
        #endregion


        /// <summary>
        /// 根据条件查询所有菜单
        /// </summary>
        /// <param name="q"></param>
        /// <returns></returns>
        public IList<Notice> GetNoticesList(Query q, int pageindex, int pagesize, out int totalcount)
        {
            return dd.GetNoticesList(q, pageindex, pagesize, out totalcount);
        }
        public IList<Notice> GetNoticesList(Query q)
        {
            return dd.GetNoticesList(q);
        }
  
        public Notice GetNoticesByID(int noticeid)
        {
            return dd.GetNoticesById(noticeid);
        }
        public int GetMaxID()
        {
            return dd.GetMaxID();
        }

    }
}
