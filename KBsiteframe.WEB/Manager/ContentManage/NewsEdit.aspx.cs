using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using KBsiteframe.Bll;
using KBsiteframe.Model;
using KBsiteframe.WEB.Comm;
using Z;

namespace KBsiteframe.Web.Manager.ContentManage
{
    public partial class NewsEdit : PageBase
    {
        public NewsEdit()
        {
            ModuleCode = "NewsManage";
            PageOperate = PurOperate.修改;
        }
     
        BNew bn = new BNew();
        private string ID = "";
 
        private int newsId = int.Parse(Q("Id"));
        
        protected void Page_Load(object sender, EventArgs e)
        {
            ID = PubCom.Q("ID");
            if (!IsPostBack)
            {
                hfNewsID.Value = ID;
                BindDropDownList();
                BindContent();
            }
           
        }

        private void BindContent()
        {
            New n = bn.GetNewsByID(Utils.StrToInt(ID,0));
            txtTitle.Text = n.Title;
            txtauthor.Text = n.Uploader;
            if (n.IsTop != null) CbIstop.Checked = (bool)n.IsTop;
            if (n.IsHot != null) CbIsHot.Checked = (bool) n.IsHot;
            container.Text = n.NewsContent;
        }

      
      
        private void BindDropDownList()
        {
      
        }

     


     

        protected void btnEdit_OnClick(object sender, EventArgs e)
        {  
        
           

            if (bn.Update(new New
            {
                NewsID = Utils.StrToInt(hfNewsID.Value,0),
                Title = PubCom.CheckString(txtTitle.Text.Trim()),
                NewsContent = container.Text,
                Uploader=txtauthor.Text.Trim(),
                SubmitTime = DateTime.Now,
                IsHot = CbIsHot.Checked,
                IsTop = CbIstop.Checked
            }) != 1)
            
                Message.ShowWrong(this, "更新文章失败");

          
            else
         
                
                Message.ShowOKAndRedirect(this, "更新文章成功", "NewsManage.aspx");
           
        }

    
}
}