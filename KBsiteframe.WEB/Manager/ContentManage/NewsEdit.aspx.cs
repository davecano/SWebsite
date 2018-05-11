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
using SysBase.BLL;
using SysBase.Model;
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
        BSysOperateLog bsol = new BSysOperateLog();
        private string ID = "";

     

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
            New n = bn.GetNewsByID(Utils.StrToInt(ID, 0));
            txtTitle.Text = n.Title;
            txtauthor.Text = n.Uploader;
            if (n.IsTop != null) CbIstop.Checked = (bool)n.IsTop;
            if (n.IsHot != null) CbIsHot.Checked = (bool)n.IsHot;
            container.Text = n.NewsContent;
            if(n.NewsPicPath!="")
            ImgNews.ImageUrl = PicFilePathV + n.NewsPicPath;
        }



        private void BindDropDownList()
        {

        }






        protected void btnEdit_OnClick(object sender, EventArgs e)
        {
            New oldn = bn.GetNewsByID(Utils.StrToInt(ID, 0));

            if (bn.Update(new New
            {
                NewsID = Utils.StrToInt(hfNewsID.Value, 0),
                Title = PubCom.CheckString(txtTitle.Text.Trim()),
                NewsContent = container.Text,
                Uploader = txtauthor.Text.Trim(),
                SubmitTime = DateTime.Now,
                IsHot = CbIsHot.Checked,
                IsTop = CbIstop.Checked
            }) != 1)


                Message.ShowWrong(this, "更新文章失败");


            else
            {
                bn.UploadValidate(pic_upload, lbl_pic, PicFilePath, Utils.StrToInt(hfNewsID.Value, 0));

                New n = bn.GetNewsByID(Utils.StrToInt(ID, 0));
                SysOperateLog log = new SysOperateLog();
                log.LogID = StringHelper.getKey();
                log.LogType = LogType.新闻信息.ToString();
                log.OperateUser = GetLogUserName();
                log.OperateDate = DateTime.Now;
                log.LogOperateType = "新闻修改";
                log.LogBeforeObject = JsonHelper.Obj2Json(oldn);
                log.LogAfterObject = JsonHelper.Obj2Json(n);
                bsol.Insert(log);
                Message.ShowOKAndRedirect(this, "更新新闻成功", "NewsManage.aspx");
            }



        }


    }
}