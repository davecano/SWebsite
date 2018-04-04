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
    public class BMember
    {
        DMember de = new DMember();

        #region"增删改"
        public int Insert(Member m)
        {
            return de.Insert(m);
        }
        public int Update(Member m)
        {
            return de.Update(m);
        }
        public int Delete(Member m)
        {

            return de.Delete(m);
        }
        #endregion


        /// <summary>
        /// 根据条件查询所有菜单
        /// </summary>
        /// <param name="q"></param>
        /// <returns></returns>
        public IList<Member> GetMembersList(Query q, int pageindex, int pagesize, out int totalcount)
        {
            return de.GetMembersList(q, pageindex, pagesize, out totalcount);
        }
        public IList<Member> GetMembersList(Query q)
        {
            return de.GetMembersList(q);
        }
  
        public Member GetMembersByID(int newsid)
        {
            return de.GetMembersById(newsid);
        }
        public int GetMaxID()
        {
            return de.GetMaxID();
        }

    }
}
