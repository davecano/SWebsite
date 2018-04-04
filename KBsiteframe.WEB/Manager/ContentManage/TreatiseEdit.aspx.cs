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

namespace MyCmsWEB.Content
{
    public partial class TreatiseEdit : PageBase
    {
        public TreatiseEdit()
        {
            ModuleCode = "TreatiseManage";
            PageOperate = PurOperate.添加;
        }
       BTreatise bt=new BTreatise();
        private string treatiseID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            treatiseID= PubCom.Q("ID");
            if (!IsPostBack)
            {
                BindDetail();
            }
        }

        private void BindDetail()
        {
            hftreatiseID.Value = treatiseID;
            Treatise t = bt.GetTreatisesByID(Utils.StrToInt(hftreatiseID.Value,0));
            txtBookName.Text = t.TreatiseName;
            txtauthor.Text = t.Author;
            txtPublishing.Text = t.Publishing;
            txtCatalog.Text = t.Catalog;
            txtsummary.Text = t.Summary;
            StarTime.Text = t.FinishTime.ToString();
            ImgNews.ImageUrl = PicFilePathV + t.Picpath;
         
        }


        protected void btnAdd_OnClick(object sender, EventArgs e)
        {
            string picurl = "";
            string  savepath= DateTime.Now.Year + "_" + DateTime.Now.Month + "/" + DateTime.Now.Day;
            if (bt.UploadValidate(pic_upload, lbl_pic, PicFilePath, savepath, out picurl))
            {
                Treatise t = new Treatise();

                t.TreatiseID = bt.GetMaxID() + 1;
                t.TreatiseName = PubCom.CheckString(txtBookName.Text.Trim());
                t.FinishTime = DateTime.Parse(StarTime.Text.Trim());
                t.Author = PubCom.CheckString(txtauthor.Text.Trim());
                t.Publishing = PubCom.CheckString(txtPublishing.Text.Trim());
                t.Summary = PubCom.CheckString(txtsummary.Text.Trim());
                t.Catalog = PubCom.CheckString(txtCatalog.Text.Trim());
                t.Picpath = picurl;
                if(bt.Update(t)==1)
                    Message.ShowOKAndRedirect(this, "添加专著成功", "TreatiseManage.aspx");
            }
            else
            {
                Message.ShowWrong(this, "添加专著失败！");
                return;
            }
          
       
            }
        
        
       
    }

}