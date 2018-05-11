using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KBsiteframe.WEB.Comm;
using SysBase.BLL;
using Z;

namespace KBsiteframe.WEB.Manager.SysManage
{
    public partial class PageVisitManage : PageBase
    {
        BPageVisit bp = new BPageVisit();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDetail();
            }
        }

        private void BindDetail()
        {
            Query q = new Query();
            q.OrderBy("VisitID,VTime desc");
            string pagename = PubCom.CheckString(txtPageName.Text.Trim());
            if (pagename != "")
                q.Add("p.PageName", pagename);
            if (StarTime.Text.Trim() != "")
                q.Add("pd.VTime", StarTime.Text.Trim());
            int rec = 0;
            rplist.DataSource = bp.GetPageVisitsDetailList(q, AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize, out rec);
            rplist.DataBind();
            AspNetPager1.RecordCount = rec;

        }

        protected void AspNetPager1_OnPageChanged(object sender, EventArgs e)
        {
           BindDetail();
        }

        protected void zbquery_OnClick(object sender, EventArgs e)
        {
           BindDetail();
            AspNetPager1.CurrentPageIndex = 1;
        }
    }
}