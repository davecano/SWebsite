using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KBsiteframe.Bll;
using KBsiteframe.Model;
using KBsiteframe.WEB.Comm;
using Z;

namespace KBsiteframe.WEB.Website.AcademicResource
{
    public partial class AcademicResourceIndex : VistorPageBase
    {
        BArticle ba = new BArticle();
        BNew bn = new BNew();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindList();
            }
        }
        private void BindList()
        {
            //国内
            Query q = new Query();
            q.OrderBy("Views desc");
            q.Append("IsInternal=1");
            rplist1.DataSource = ba.GetBriefArticlelist(q, 8);
            rplist1.DataBind();
            //国外
            Query q2 = new Query();
            q2.OrderBy("Views desc");
            q2.Append("IsInternal=0");
            rplist2.DataSource = ba.GetBriefArticlelist(q2, 8);
            rplist2.DataBind();
            //国际会议  新闻
            Query q3 = new Query();
            q3.OrderBy("IsTop desc,IsHot desc,SubmitTime desc");
            q3.Append("NewsType='" + NewsType.国际会议+"'");
            rplist3.DataSource = bn.GetNewsList(q3).Take(8);
            rplist3.DataBind();
        }
    }
}