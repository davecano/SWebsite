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

        //还是通过ajax来做吧
        private void BindDetail()
        {
            Query q = new Query();
            q.OrderBy("Istop desc,Sort");
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