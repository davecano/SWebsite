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
        private int id;
        private int type;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Utils.StrToInt(Q("ID"),0);
            type= Utils.StrToInt(Q("type"), 0);
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
            if (id != 0)
            {
                // 表明id 类型 type 1 = project ,2=expert,3=lmmember,4=tdmember,5代表国内,6代表国外
                switch (type)
                {
                    case 1:
                        q.Append("p.ProjectID=" + id);
                             break;
                    case 2:
                        q.Append("e.ExpertID=" + id);
                        break;
                    case 3:
                        q.Append("m.MemberID=" + id);
                        break;
                    case 4:
                        q.Append("m2.MemberID=" + id);
                        break;
                    case 5:
                        q.Append("a.IsInternal=" + 1);
                        break;
                    case 6:
                        q.Append("a.IsInternal=" + 0);
                        break;
                }
            }
         
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