using System;
using System.Collections;
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
    public partial class AboutIndex : VistorPageBase
    {
        BExpert be=new BExpert();
        BArticle ba=new BArticle();
        BMember bm=new BMember();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindStu();
                //绑定校内专家
                Query q=new Query();
                q.OrderBy("Istop desc,Sort");
                q.Append("EIdentification='"+ExpertType.校内专家+"'");
                int rec = 0;
                IList<Expert> elist = be.GetExpertsList(q, 1, 4, out rec);
                ltexpertname1.Text = elist[0].EName;
                ltcountry1.Text = elist[0].ECountry;
                ltsummary1.Text = Utils.CutString(elist[0].ESummary,20);
                   if (elist[0].EPicPath != null)
                 img1.Attributes["src"] = PicFilePathV + elist[0].EPicPath;
                Query qatta1 = new Query();
                qatta1.OrderBy("Views desc, Downloads desc");
                qatta1.Append("e.ExpertID=" + elist[0].ExpertID);
                int recatta1;
                rplist1.DataSource = ba.GetArticlesList(qatta1, 1, 6, out recatta1);
                rplist1.DataBind();


                ltexpertname2.Text = elist[1].EName;
                ltcountry2.Text = elist[1].ECountry;
                ltsummary2.Text = Utils.CutString(elist[1].ESummary, 20);
                if (elist[1].EPicPath != null)
                    img2.Attributes["src"] = PicFilePathV + elist[1].EPicPath;
                Query qatta2 = new Query();
                qatta2.OrderBy("Views desc, Downloads desc");
                qatta2.Append("e.ExpertID=" + elist[1].ExpertID);
                int recatta2;
                rplist2.DataSource = ba.GetArticlesList(qatta2, 1, 6, out recatta2);
                rplist2.DataBind();


                ltexpertname3.Text = elist[2].EName;
                ltcountry3.Text = elist[2].ECountry;
                ltsummary3.Text = Utils.CutString(elist[2].ESummary, 20);
                if (elist[2].EPicPath != null)
                    img3.Attributes["src"] = PicFilePathV + elist[2].EPicPath;
                Query qatta3 = new Query();
                qatta3.OrderBy("Views desc, Downloads desc");
                qatta3.Append("e.ExpertID=" + elist[2].ExpertID);
                int recatta3;
                rplist3.DataSource = ba.GetArticlesList(qatta3, 1, 6, out recatta3);
                rplist3.DataBind();
                ltexpertname4.Text = elist[3].EName;
                ltcountry4.Text = elist[3].ECountry;
                ltsummary4.Text = Utils.CutString(elist[3].ESummary, 20);
                if (elist[3].EPicPath != null)
                    img4.Attributes["src"] = PicFilePathV + elist[3].EPicPath;
                Query qatta4 = new Query();
                qatta4.OrderBy("Views desc, Downloads desc");
                qatta4.Append("e.ExpertID=" + elist[3].ExpertID);
                int recatta4;
                rplist4.DataSource = ba.GetArticlesList(qatta4, 1, 6, out recatta4);
                rplist4.DataBind();

           
            }
        }

        private void BindStu()
        {
           //学生绑定
            int ret = 0;
            rpstulist.DataSource = bm.GetMembersListByGrade(AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize, out ret);
            rpstulist.DataBind();
            AspNetPager1.RecordCount = ret;
        }

        protected void AspNetPager1_OnPageChanged(object sender, EventArgs e)
        {
            BindStu();
        }
    }
}