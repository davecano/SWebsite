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
    public partial class ShowAllDynamic : VistorPageBase
    {
        BDynamic bd=new BDynamic();
        private int type;
        protected void Page_Load(object sender, EventArgs e)
        {
            type = Utils.StrToInt(Q("Type"),0);
            if (!IsPostBack)
            {
                BindDetail();
            }
        }

        private void BindDetail()
        {
            lttype.Text = (type == 1 ? DynamicType.联盟动态.ToString() : DynamicType.团队动态.ToString());
            Query q=new Query();
            q.OrderBy("IsTop desc,SubTime desc");
            int rec = 0;
            q.Append("DynamicType='" + Enum.GetName(typeof (DynamicType), type)+"'");
            rplist.DataSource= bd.GetDynamicsList(q,AspNetPager1.CurrentPageIndex,AspNetPager1.PageSize,out rec);
            rplist.DataBind();
            AspNetPager1.RecordCount = rec;
        }

    

        protected void AspNetPager1_OnPageChanged(object sender, EventArgs e)
        {
            BindDetail();
        }
    }
}