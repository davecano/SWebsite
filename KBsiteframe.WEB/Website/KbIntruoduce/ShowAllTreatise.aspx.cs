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
    public partial class ShowAllTreatise : VistorPageBase
    {
       BTreatise  bt=new BTreatise();
        private int ID;
        protected void Page_Load(object sender, EventArgs e)
        {
            ID = Utils.StrToInt(Q("ID"),0);
            if (!IsPostBack)
            {
                BindDetail();
            }
        }

        private void BindDetail()
        {
          
            Query q=new Query();
            q.OrderBy("TreatiseID desc");
            int rec = 0;
            if(ID!=0)
            q.Append("p.ProjectID="+ID);
            rplist.DataSource= bt.GetTreatisesList(q,AspNetPager1.CurrentPageIndex,AspNetPager1.PageSize,out rec);
            rplist.DataBind();
            AspNetPager1.RecordCount = rec;
        }

    

        protected void AspNetPager1_OnPageChanged(object sender, EventArgs e)
        {
            BindDetail();
        }
    }
}