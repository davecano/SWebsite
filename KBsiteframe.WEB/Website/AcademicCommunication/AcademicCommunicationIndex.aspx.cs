using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KBsiteframe.Bll;
using KBsiteframe.Model;
using KBsiteframe.WEB.Comm;
using Z;

namespace KBsiteframe.WEB.Website.AcademicCommunication
{
    public partial class AcademicCommunicationIndex : VistorPageBase
    {
         BNew bn=new BNew();
         //BArticle ba=new BArticle();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                BindList();
            }
        }

        private void BindList()
        {
            //国内
            Query q = new Query();
            q.OrderBy("Views desc");
            q.Append("NewsType='"+NewsType.国内新闻+"'");
            IList<New> alist1 = bn.GetNewsTitleList(q).Take(13).ToList();
            New toparticle = alist1.Take(1).FirstOrDefault();
            lttitle.Text = Utils.CutString(toparticle.Title, 50);
            ltsummary.Text = Utils.CutString(toparticle.summary, 170);
            hfaid.Value = Utils.ObjectToStr(toparticle.NewsID);
            rplist1.DataSource = alist1.Skip(1).ToList();
            rplist1.DataBind();

            //国外
            Query q2 = new Query();
            q2.OrderBy("Views desc");
            q2.Append("NewsType='" + NewsType.国际会议 + "'");
            IList<New> alist2 = bn.GetNewsTitleList(q2).Take(13).ToList();
            New toparticle2 = alist2.Take(1).FirstOrDefault();
            lttitle2.Text = Utils.CutString(toparticle2.Title, 50);
            ltsummary2.Text = Utils.CutString(toparticle2.summary, 170);
            hfaid2.Value = Utils.ObjectToStr(toparticle2.NewsID);
            rplist2.DataSource = alist2.Skip(1).ToList();
            rplist2.DataBind();
        }
    }
}