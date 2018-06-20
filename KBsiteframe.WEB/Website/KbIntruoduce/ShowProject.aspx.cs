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
    public partial class ShowProject : VistorPageBase
    {
        private string id;
        BProject bp = new BProject();
        BTreatise bt = new BTreatise();
        BArticle ba = new BArticle();
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Q("ID");

            if (!IsPostBack)
            {
                BindDetail();
                BindAttach();
            }
        }

        private void BindAttach()
        {
            Query q = new Query();
            q.OrderBy("ArticleID");
            q.Append("p.ProjectID=" + Utils.StrToInt(id, 0));
            Query q2 = new Query();
            q2.OrderBy("TreatiseID");
            q2.Append("p.ProjectID=" + Utils.StrToInt(id, 0));
            IList<Article> list1 = ba.GetArticlesList(q);
            if (list1 != null && list1.Count > 0)
            {
                rplist1.DataSource = list1.Take(5);
                rplist1.DataBind();
               
            }

            else v1.Visible = false;
            IList<Treatise> list2 = bt.GetTreatisesList(q2);
            if (list2 != null && list2.Count > 0)
            {
                rplist2.DataSource = list2.Take(5);
                rplist2.DataBind();
            }

            else v2.Visible = false;

        }

        private void BindDetail()
        {
            Project p = bp.GetProjectsByID(Utils.StrToInt(id, 0));
            ltProjectTitle.Text = p.ProjectName;
            lttime.Text = string.Format(p.StartTime.ToString(), "yyyy-MM-dd") + "~" + string.Format(p.EndTime.ToString(), "yyyy-MM-dd");
            ltorg.Text = p.OrgName;
            ltcontent.Text = p.ProjectContent;
            ltstage.Text = p.ProjectStage;
            ltPeriod.Text = p.ProjectPeriod;
        }
    }
}