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
    public partial class ShowNotice : VistorPageBase
    {
        public string id;
        BNotice bn = new BNotice();
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Q("ID");
            if (!IsPostBack)
            {

                BindDetail();
            }
        }



        private void BindDetail()
        {//公告绑定
            Notice n = bn.GetNoticesByID(Utils.StrToInt(id, 0));
            ltTitle.Text = n.NoticeTitle;
            ltViews.Text = (n.Views ?? 0).ToString();
            ltdate.Text = ((DateTime)n.LastUpdateDate).ToString("yyyy-MM-dd");
            ltauthor.Text = n.CreateUser;
            ltContent.Text = n.NoticeContent;
            //修改Views
            bn.Update(new Notice() { NoticeID = Utils.StrToInt(id, 0), Views = (n.Views ?? 0) + 1 });
        }
    }
}