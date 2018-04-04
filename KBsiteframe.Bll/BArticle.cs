using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KBsiteframe.Dll;
using KBsiteframe.Model;
using System.Web;
using Z;

namespace KBsiteframe.Bll
{
    public class BArticle
    {
       
        DArticle da = new DArticle();

        #region"增删改"
        public int Insert(Article a)
        {
            return da.Insert(a);
        }
        public int Update(Article a)
        {
            return da.Update(a);
        }
        public int Delete(Article a)
        {

            return da.Delete(a);
        }
        #endregion


        /// <summary>
        /// 根据条件查询所有菜单
        /// </summary>
        /// <param name="q"></param>
        /// <returns></returns>
        public IList<Article> GetArticlesList(Query q, int pageindex, int pagesize, out int totalcount)
        {
            return da.GetArticlesList(q, pageindex, pagesize, out totalcount);
        }
        public IList<Article> GetArticlesList(Query q)
        {
            return da.GetArticlesList(q);
        }
  
        public Article GetArticlesByID(int newsid)
        {
            return da.GetArticlesById(newsid);
        }
        public int GetMaxID()
        {
            return da.GetMaxID();
            
        }
      
        public int UploadFile( HttpPostedFile hpf, string UploadBasePath,int articleid)
        {
            string timePackage = DateTime.Now.Year + "_" + DateTime.Now.Month + "/" + DateTime.Now.Day;
            string hzm = Path.GetExtension(hpf.FileName);
            bool flag = false;
            foreach (string s in ModelConstants.CanUploadFile.Split('|'))
            {
                if (s.ToLower() == hzm.ToLower())
                {
                    flag = true;
                    break;
                }
            }
            if (!flag)
                return -4;

            string path = ModelConstants.FileBathPath + "/" + timePackage + "/";

            string path_p = UploadBasePath + path;
            if (!Directory.Exists(path_p))
                Directory.CreateDirectory(path_p);

            string fn = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            if (hpf.ContentLength > 0)
            {
                if (hpf.ContentLength > 1048576 * ModelConstants.FileMaxLength)
                {
                    return -2;
                }
                else
                {
                   
                    hpf.SaveAs(path_p + fn + hzm);
                    //更新article
                    return da.Update(new Article()
                    {
                        ArticleID = articleid,
                        ArticlePath = path + fn + hzm
                    });
                     
                }
            }
            else
            {
                return -3;
            }
        }
    }
}
