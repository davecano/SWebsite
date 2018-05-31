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
    public partial class ShowArticle :VistorPageBase
    {
        public string id;
        BArticle ba = new BArticle();
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Q("ID");
     
            //未登录的情况，注册方法
            EventHandler += () =>
            {
                ltmsg.Visible = true;
                btndownload.Enabled = false;
            };

            if (!IsPostBack)
            {
                BindDetail();
            }
        }

        private void BindDetail()
        {
            Article a = ba.GetArticlesByID(Utils.StrToInt(id,0));
            lttitle.Text = a.ArticleTitle;
            ltauthor.Text = a.Author;
            ltdate.Text = a.SubmitTime.ToString();
            ltkeyword.Text = a.Keyword;
            ltsummary.Text = a.Summary;
            hfpath.Value = PicFilePathV + a.ArticlePath;
        }

        protected void btndownload_OnClick(object sender, EventArgs e)
        {
            ba.DownloadFile(hfpath.Value);
            
        }
    }
}