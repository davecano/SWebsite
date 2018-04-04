using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KBsiteframe.Bll;
using KBsiteframe.WEB.Comm;
using Z;




namespace KBsiteframe.WEB.Manager.ContentManage
{
    public partial class NewsManage : PageBase
    {
        public NewsManage()
        {
            ModuleCode = "NewsManage";
            PageOperate=PurOperate.查询;
        }
 
      
        BNew bn=new BNew();
   
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindingList();
            }
        }

        private void BindingList()
        {
            Query qm = Query.Build(new {SortFields = "IsTop Desc,IsHot Desc,SubmitTime Desc" });
         
            string Title = PubCom.CheckString(txtTitle.Text.Trim());
            if (Title != "")
                qm.Add("Title", Title);
            string Author = PubCom.CheckString(txtAuthor.Text.Trim());
            if (Author != "")
                qm.Add("Uploader", Author);
            string Subtime = PubCom.CheckString(StarTime.Text.Trim());
         
   
            if (Subtime != "")
                qm.Add("Subtime", DateTime.Parse(Subtime));
         
            if (dpIsTop.SelectedValue != "")
                qm.Add("IsTop", dpIsTop.SelectedValue == "1" );

            if (dpIsHot.SelectedValue != "")
                qm.Add("IsHot", dpIsHot.SelectedValue == "1");

            int ret = 0;
            rplist.DataSource = bn.GetNewsList(qm, AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize, out ret);
            rplist.DataBind();
            AspNetPager1.RecordCount = ret;
        }

        protected void zbquery_OnClick(object sender, EventArgs e)
        {
            AspNetPager1.CurrentPageIndex = 1;
            BindingList();
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindingList();
        }

        protected void ZButton2_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("NewsAdd.aspx");
        }

        protected void rplist_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName=="bj")
            {
                Response.Redirect("NewsEdit.aspx?ID="+e.CommandArgument);
            }
            if (e.CommandName == "sc")
            {
              
                int id = int.Parse(e.CommandArgument.ToString());
                var newsmodel = bn.GetNewsByID(id);
              
           if(bn.Delete(newsmodel)==1)
                    Message.ShowOK(this, "删除文章成功!");
                
                else
                    Message.ShowWrong(this,"删除文章失败");
                
            }
            BindingList();
        }
    }
}