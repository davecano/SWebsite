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
    public partial class ShowAll : VistorPageBase
    {
        BNew bn = new BNew();
        private int type;
        protected void Page_Load(object sender, EventArgs e)
        {
            type = Utils.StrToInt(Q("type"), 0);
            if (!IsPostBack)
            {
                BindDetail();
            }
        }

        private void BindDetail()
        {
            //国内新闻 = 1,
            //国际新闻 = 2,
            //国际会议 = 3
            Query q = new Query();
            q.OrderBy("IsTop desc,IsHot desc");
            if (type != 0)
            {

                q.Append("NewsType='"+ Enum.GetName(typeof (NewsType), type)+"'");

            }
            int rec = 0;
            rplist.DataSource = bn.GetNewsList(q, AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize, out rec);
            rplist.DataBind();
            AspNetPager1.RecordCount = rec;
        }



        protected void AspNetPager1_OnPageChanged(object sender, EventArgs e)
        {
            BindDetail();
        }
    }
}