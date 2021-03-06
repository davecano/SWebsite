﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KBsiteframe.Model;
using Z;
using Z.Data;

namespace KBsiteframe.Dll
{
    public class DArticle
    {
        #region
        DbHelper db = new DbHelper();
        private string Vsql = @"select a.*,e.EName,p.ProjectName,m.MemberName as LmMemberName,m2.MemberName as  TdMemberName from Article a 
left join Expert e on a.ExpertID=e.ExpertID
left join Project p on p.ProjectID= a.ProjectID
left join Member m on m.MemberID= a.LmMemberID
left join  Member m2 on m2.MemberID= a.TdMemberID where 1=1{0}";
        //private string Sql = "select * from(select  top 100 percent row_number()over(order by AddTime Desc, IsTop Desc) as ArticlesIndex ,p.*,q.ClassName from Article p left join mycms_class q on p.ClassId=q.Id where 1=1{0}) as T where 1=1{1}";



        //public IList<Article> GetArticlesList(Query q)
        //{
        //    return db.Query<Article>(q, 1, 1000);
        //}
        public IList<Article> GetArticlesList(Query q, int pageindex, int pagesize, out int totalcount)
        {
            return db.Query<Article>(string.Format(Vsql, q.GetCondition(true)), pageindex, pagesize, out totalcount);
        }
        public IList<Article> GetArticlesList(Query q)
        {
            return db.Query<Article>(string.Format(Vsql, q.GetCondition(true)));
        }

        #endregion
        public IList<Article> GetBriefArticlelist(Query q,int pagesize)
        {
            string sql = @"select top(" + pagesize +
                         ") ArticleID,ArticleTitle,SubmitTime,Summary from article where 1=1{0}";
            return db.Query<Article>(string.Format(sql, q.GetCondition(true)));
        }
         

        public int Insert(Article m)
        {
            return db.Insert<Article>(m);
        }
        public int Delete(Article m)
        {
            return db.Delete<Article>(m);
        }

     
        public int sqlUpdate(int objID, string type)
        {
            string sql = "";
            switch (type)
            {
                case "Expert":
                    sql = @"Update  Article set ExpertID=null where ExpertID=" + objID;
                    break;
                case "Project":
                    sql = @"Update  Article set ProjectID=null where ProjectID=" + objID;
                    break;
                case "LmMember":
                    sql = @"Update  Article set LmMemberID=null where LmMemberID=" + objID;
                    break;
                default:
                    sql = @"Update  Article set TdMemberID=null where TdMemberID=" + objID;
                    break;
            }
            return db.ExecuteNonQuery(sql);
        }
        public int Update(Article m)
        {
            return db.Update<Article>(m);
        }

        public Article GetArticlesById(int newsID)
        {
            return db.GetEntityById<Article>(newsID);
        }

        public int GetMaxID()
        {
            string ret = db.ExecuteScalar("select max(ArticleID) from Article").ToString();
            if (ret == "")
                return 0;
            else
                return int.Parse(ret);
        }

    }
}
