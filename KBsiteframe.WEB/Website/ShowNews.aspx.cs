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
    public partial class ShowNews : VistorPageBase
    {
        public string id;
        BNew bn = new BNew();
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Q("ID");
            if (!IsPostBack)
            {

                BindDetail();
            }
        }



        private void BindDetail()
        {//新闻绑定
            New n = bn.GetNewsByID(Utils.StrToInt(id, 0));
            ltTitle.Text = n.Title;
            ltViews.Text = (n.Views ?? 0).ToString();
            ltdate.Text = ((DateTime)n.SubmitTime).ToString("yyyy-MM-dd");
            ltauthor.Text = n.Uploader;
            ltContent.Text = n.NewsContent;
            //修改Views
            bn.Update(new New() { NewsID = Utils.StrToInt(id, 0), Views = (n.Views ?? 0) + 1 });
        }
    }
}