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

namespace KBsiteframe.WEB.Website.About
{
    public partial class StuMemberIndex : VistorPageBase
    {
        BMember bm=new BMember();
        private int grade;
        protected void Page_Load(object sender, EventArgs e)
        {
          grade=Utils.StrToInt(PubCom.Q("Grade"),0) ;
            if (!IsPostBack)
            {
                BindDetail();
            }
        }

        private void BindDetail()
        {
           Query q=new Query();
            q.OrderBy("CHARINDEX(RTRIM(CAST(Qualification as NCHAR)),'博士,硕士'), sort");
            //q.OrderBy("MemberID");
            q.Append("MemberType='" + MemberType.普通学生+"' AND Grade="+ grade);
            int rec = 0;
            rplist.DataSource = bm.GetMembersList(q, AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize, out rec);
            rplist.DataBind();
            AspNetPager1.RecordCount = rec;
        }

        protected void AspNetPager1_OnPageChanged(object sender, EventArgs e)
        {
            BindDetail();
        }
    }
}