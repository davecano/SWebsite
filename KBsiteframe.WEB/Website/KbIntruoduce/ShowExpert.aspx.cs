using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using KBsiteframe.Bll;
using KBsiteframe.Model;
using KBsiteframe.WEB.Comm;
using Z;


namespace KBsiteframe.WEB.Website.KbIntruoduce
{
    public partial class ShowExpert : VistorPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Q("ID");
            if (!IsPostBack)
            {
                BindDetail();
                BindList();
            }
        }
        public string id;

        BExpert be = new BExpert();
        BArticle ba = new BArticle();
        private void BindList()
        {
            Query q = new Query();
            q.OrderBy("ArticleID desc");
            q.Append("a.ExpertID=" + Utils.StrToInt(hfEID.Value, 0));
            int ret = 0;
            rplist.DataSource = ba.GetArticlesList(q, AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize, out ret);
            rplist.DataBind();
            AspNetPager1.RecordCount = ret;
        }

        private void BindDetail()
        {
            Expert e = be.GetExpertsByID(Utils.StrToInt(id, 0));
            hfEID.Value = e.ExpertID.ToString();
            ltexpertname.Text = e.EName;
            ltsummary.Text = e.ESummary;
            //img.ImageUrl = PicFilePathV + e.EPicPath;
            //HtmlImage img=
            if(e.EPicPath != null)
            htmlimg.Attributes["src"] = PicFilePathV + e.EPicPath;
        }

        protected void AspNetPager1_OnPageChanged(object sender, EventArgs e)
        {
            BindList();
        }
    }
}