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

namespace KBsiteframe.WEB.Manager.ContentManage
{
    public partial class TreatiseEdit : PageBase
    {
        public TreatiseEdit()
        {
            ModuleCode = "TreatiseManage";
            PageOperate = PurOperate.修改;
        }
        BTreatise bt = new BTreatise();
        BSysOperateLog bsol = new BSysOperateLog();
        private string treatiseID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            treatiseID = PubCom.Q("ID");
            if (!IsPostBack)
            {
                BindDetail();
            }
        }

        private void BindDetail()
        {
            hftreatiseID.Value = treatiseID;
            Treatise t = bt.GetTreatisesByID(Utils.StrToInt(hftreatiseID.Value, 0));
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

            string savepath = DateTime.Now.Year + "_" + DateTime.Now.Month + "/" + DateTime.Now.Day;
            Treatise oldt = bt.GetTreatisesByID(Utils.StrToInt(hftreatiseID.Value, 0));
            Treatise t = new Treatise();
            t.TreatiseID = Utils.StrToInt(hftreatiseID.Value, 0);
            t.TreatiseName = PubCom.CheckString(txtBookName.Text.Trim());
            t.FinishTime = DateTime.Parse(StarTime.Text.Trim());
            t.Author = PubCom.CheckString(txtauthor.Text.Trim());
            t.Publishing = PubCom.CheckString(txtPublishing.Text.Trim());
            t.Summary = PubCom.CheckString(txtsummary.Text.Trim());
            t.Catalog = PubCom.CheckString(txtCatalog.Text.Trim());
            if (dpExpert.SelectedValue != "")
                t.ExpertID = Utils.StrToInt(dpExpert.SelectedValue, 0);
            if (dpLm.SelectedValue != "")
                t.LmMemberID = Utils.StrToInt(dpLm.SelectedValue, 0);
            if (dpTd.SelectedValue != "")
                t.TdMemberID = Utils.StrToInt(dpTd.SelectedValue, 0);
            if (dpProject.SelectedValue != "")
                t.ProjectID = Utils.StrToInt(dpProject.SelectedValue, 0);
            if (bt.Update(t) == 1)
            {
                bt.UploadValidate(pic_upload, lbl_pic, PicFilePath, savepath, Utils.StrToInt(hftreatiseID.Value, 0));
                // 插入日志  update


                SysOperateLog log = new SysOperateLog
                {
                    LogID = StringHelper.getKey(),
                    LogType = LogType.专著信息.ToString(),
                    OperateUser = GetLogUserName(),
                    OperateDate = DateTime.Now,
                    LogOperateType = "专著修改",
                    LogBeforeObject = JsonHelper.Obj2Json(oldt),
                    LogAfterObject = JsonHelper.Obj2Json(t)
                };
                bsol.Insert(log);
                Message.ShowOKAndRedirect(this, "修改专著成功", "TreatiseManage.aspx");
            }

            else
            {
                Message.ShowWrong(this, "修改专著失败！");
                return;
            }


        }



    }

}