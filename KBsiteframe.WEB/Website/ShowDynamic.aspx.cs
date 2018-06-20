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

namespace KBsiteframe.WEB.Website
{
    public partial class ShowDynamic : VistorPageBase
    {
        public string id;
        BDynamic bd = new BDynamic();
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Q("ID");
            if (!IsPostBack)
            {

                BindDetail();
            }
        }



        private void BindDetail()
        {//绑定
            Dynamic d = bd.GetDynamicsByID(Utils.StrToInt(id, 0));
            ltTitle.Text = d.Title;
            ltViews.Text = (d.DynamicViews ?? 0).ToString();
            ltdate.Text = ((DateTime)d.SubTime).ToString("yyyy-MM-dd");
            ltauthor.Text = d.Uploader;
            ltContent.Text = d.Content;
            //修改Views
            bd.Update(new Dynamic() { DynamicID = Utils.StrToInt(id, 0), DynamicViews = (d.DynamicViews ?? 0) + 1 });
        }
    }
}