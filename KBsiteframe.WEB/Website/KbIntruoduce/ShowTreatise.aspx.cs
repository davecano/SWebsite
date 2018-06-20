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
    public partial class ShowTreatise : VistorPageBase
    {
        public string id;
        BTreatise bt=new BTreatise();
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Q("ID");
     
            if (!IsPostBack)
            {
                BindDetail();
            }
        }

        private void BindDetail()
        {
            Treatise t = bt.GetTreatisesByID(Utils.StrToInt(id,0));
            lttitle.Text = t.TreatiseName;
            ltauthor.Text = t.Author;
         
            ltexpert.Text = t.EName??"无";
            ltlm.Text = t.LmMemberName ?? "无";
            lttd.Text = t.TdMemberName ?? "无";
            ltpublish.Text = t.Publishing;
            ltdate.Text = t.FinishTime.ToString();
            ltproject.Text = t.ProjectName ?? "无";
            aimg.ImageUrl = PicFilePathV + t.Picpath;
            ltsum.Text = t.Summary;
            ltcatalog.Text = t.Catalog;
        }

      

      
    }
}