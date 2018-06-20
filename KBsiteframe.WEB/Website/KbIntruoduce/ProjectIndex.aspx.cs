using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KBsiteframe.Bll;
using KBsiteframe.WEB.Comm;
using Z;

namespace KBsiteframe.WEB.Website.KbIntruoduce
{
    public partial class ProjectIndex :VistorPageBase
    {
        BProject bp = new BProject();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            Bindlist();
        }

        private void Bindlist()
        {
            Query q=new Query();
            q.OrderBy("StartTime desc");
            int rec = 0;
            rplist.DataSource=bp.GetProjectsList(q, AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize, out rec);
            rplist.DataBind();
            AspNetPager1.RecordCount = rec;
        }

        protected void AspNetPager1_OnPageChanged(object sender, EventArgs e)
        {
          Bindlist();
        }
    }
}