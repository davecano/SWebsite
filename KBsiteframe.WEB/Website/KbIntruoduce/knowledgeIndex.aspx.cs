using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using KBsiteframe.Bll;
using KBsiteframe.Model;
using KBsiteframe.WEB.Comm;
using Z;

namespace KBsiteframe.WEB.Website.KbIntruoduce
{
    public partial class knowledgeIndex : VistorPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDetail();
            }
        }

        BExpert be = new BExpert();
        BNew bn=new BNew();
        //还是通过ajax来做吧
        private void BindDetail()
        {
            Query q = new Query();
            q.OrderBy("Istop desc,Sort");
            q.Append("EIdentification='" + ExpertType.普通专家+"'");
            IList<Expert> exlist = new List<Expert>();
            int rec = 0;
            rplist_new.DataSource = be.GetExpertsList(q, 1, 4, out rec);
            rplist_new.DataBind();
            hfrec.Value = rec.ToString();
            hfPicFilePathV.Value = PicFilePathV;
            if (rec <= 4)
            {
                showmore.Visible = false;


            }
            //显示四个静态数据
            Query qn=new Query();
            qn.OrderBy("SubmitTime desc");
            qn.Append("StaticType='" + StaticType.知识建构理论 + "' or StaticType='" + StaticType.关于手段 + "' or StaticType='" +
                      StaticType.关于社区 + "' or StaticType='" + StaticType.关于观点 + "'");
            IList<New> nlist= bn.GetNewsTitleList(qn);
            New n1 = nlist.FirstOrDefault(p => p.StaticType == StaticType.知识建构理论.ToString());
             hfnew1.Value= Utils.ObjectToStr(n1?.NewsID) ;
            ltjgsummary.Text = Utils.CutString(n1?.summary,500);
            New n2 = nlist.FirstOrDefault(p => p.StaticType == StaticType.关于手段.ToString());
            hfnew2.Value = Utils.ObjectToStr(n2?.NewsID);
            New n3 = nlist.FirstOrDefault(p => p.StaticType == StaticType.关于观点.ToString());
            hfnew3.Value = Utils.ObjectToStr(n3?.NewsID);
            New n4 = nlist.FirstOrDefault(p => p.StaticType == StaticType.关于社区.ToString());
            hfnew4.Value = Utils.ObjectToStr(n4?.NewsID);
        }

        //private void BindDetail(bool ismore)
        //{
        //   Query q=new Query();
        //    q.OrderBy("Istop desc,Sort");
        //    IList<Expert> exlist=new List<Expert>();
        //    int rec = 0;
        //    exlist = be.GetExpertsList(q,AspNetPager1.CurrentPageIndex,AspNetPager1.PageSize,out rec);

        //    if (ismore)
        //    {
        //        rplist.DataSource = exlist;
        //        rplist.DataBind();

        //    }
        //    else
        //    {
        //        rplist.DataSource = exlist.Take(4).ToList();
        //        rplist.DataBind();
        //    }

        //}

        public string GetFullPath(object path)
        {
            if (path != null)
                return PicFilePathV + path;
            return "";
        }

        [WebMethod]
        public static IList<Expert> GetExpertsByPageIndex(string pageindex)
        {
            {
                BExpert be = new BExpert();
                Query q = new Query();
                q.OrderBy("Istop desc,Sort");
                int PageIndex = Utils.StrToInt(pageindex, 0);

                int rec = 0;
               IList<Expert> elist= be.GetExpertsList(q, PageIndex, 4, out rec);
                foreach (Expert  ex in elist)
                {
                    ex.ESummary = Utils.CutString(ex.ESummary, 20);
                    
                }
                return elist;
            }


        }
    }
}