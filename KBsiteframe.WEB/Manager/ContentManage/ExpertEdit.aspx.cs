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
    public partial class ExpertEdit : PageBase
    {
        public ExpertEdit()
        {
            ModuleCode = "ExpertManage";
            PageOperate = PurOperate.修改;
        }

        BExpert be = new BExpert();
        BSysCode bs = new BSysCode();
        BSysOperateLog bsol = new BSysOperateLog();
        private string expertid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            expertid = PubCom.Q("ID");
            if (!IsPostBack)
            {
                hfexpertid.Value = expertid;
                BindDropDownList();
                BindDetail();
            }
        }

        private void BindDetail()
        {
            Expert e = be.GetExpertsByID(Utils.StrToInt(hfexpertid.Value, 0));
            txtEName.Text = e.EName;
            txtECountry.Text = e.ECountry;
            txtESummary.Text = e.ESummary;
            dpIstop.SelectedValue = e.Istop != null && (bool)e.Istop ? "1" : "0";
            dpEIdentification.SelectedValue = e.EIdentification;
            if (e.EPicPath != "")
                ImgNews.ImageUrl = PicFilePathV + e.EPicPath;
        }

        void BindDropDownList()
        {
            Utils.BindDropDownList(typeof(ExpertType), dpEIdentification, "");

        }


        protected void btnAdd_OnClick(object sender, EventArgs e)
        {

            string savepath = DateTime.Now.Year + "_" + DateTime.Now.Month + "/" + DateTime.Now.Day;
            Expert exold = be.GetExpertsByID(Utils.StrToInt(hfexpertid.Value, 0));
            Expert ex = new Expert();
            ex.ExpertID = Utils.StrToInt(hfexpertid.Value, 0);
            ex.EName = PubCom.CheckString(txtEName.Text.Trim());
            ex.ECountry = PubCom.CheckString(txtECountry.Text.Trim());
            ex.ESummary = PubCom.CheckString(txtESummary.Text.Trim());
            if (dpIstop.SelectedValue != "")
                ex.Istop = dpIstop.SelectedValue == "1";
            if (dpEIdentification.SelectedValue != "")
                ex.EIdentification = dpEIdentification.SelectedValue;
            if (be.Update(ex) == 1)
            {
                be.UploadValidate(pic_upload, lbl_pic, PicFilePath, savepath, ex.ExpertID);

                // 插入日志  update

                Expert exnew = be.GetExpertsByID(Utils.StrToInt(hfexpertid.Value, 0));
                SysOperateLog log = new SysOperateLog();
                log.LogID = StringHelper.getKey();
                log.LogType = LogType.专家信息.ToString();
                log.OperateUser = GetLogUserName();
                log.OperateDate = DateTime.Now;
                log.LogOperateType = "专家修改";
                log.LogBeforeObject = JsonHelper.Obj2Json(exold);
                log.LogAfterObject = JsonHelper.Obj2Json(exnew);
                bsol.Insert(log);
                Message.ShowOKAndRedirect(this, "修改专家成功", "ExpertManage.aspx");
            }

            else
            {
                Message.ShowWrong(this, "修改专家失败！");
                return;
            }


        }



    }

}