﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KBsiteframe.Bll;
using KBsiteframe.Model;
using KBsiteframe.WEB.Comm;
using Z;

namespace KBsiteframe.WEB.Website.AcademicAlliance
{
    public partial class MemberIndex : VistorPageBase
    {
        BMember bm=new BMember();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDetail();
            }
        }

        private void BindDetail()
        {
           Query q=new Query();
            q.OrderBy("MemberID");
            q.Append("MemberType='" + MemberType.联盟成员+"'");
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