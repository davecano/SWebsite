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

namespace KBsiteframe.WEB.Website.KbIntruoduce
{
    public partial class ShowAllArticle : VistorPageBase
    {
     BArticle ba=new BArticle();
        private int projectid;
        protected void Page_Load(object sender, EventArgs e)
        {
            projectid = Utils.StrToInt(Q("ID"),0);
            if (!IsPostBack)
            {
                BindDetail();
            }
        }

        private void BindDetail()
        {
          
            Query q=new Query();
            q.OrderBy("SubmitTime desc");
            int rec = 0;
            if(projectid!=0)
            q.Append("p.ProjectID="+projectid);
            rplist.DataSource= ba.GetArticlesList(q,AspNetPager1.CurrentPageIndex,AspNetPager1.PageSize,out rec);
            rplist.DataBind();
            AspNetPager1.RecordCount = rec;
        }

    

        protected void AspNetPager1_OnPageChanged(object sender, EventArgs e)
        {
            BindDetail();
        }
    }
}