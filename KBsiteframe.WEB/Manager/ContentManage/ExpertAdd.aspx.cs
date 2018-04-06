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
    public partial class ExpertAdd : PageBase
    {
        public ExpertAdd()
        {
            ModuleCode = "ExpertManage";
            PageOperate = PurOperate.添加;
        }

        BExpert be = new BExpert();
        BSysCode bs = new BSysCode();
        BSysOperateLog bsol=new BSysOperateLog();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDownList();
            }
        }

        void BindDropDownList()
        {
          Utils.BindDropDownList(typeof(ExpertType),dpEIdentification,"");
            //dpsort.Items.Clear();
            //dpsort.Items.Add(new ListItem("==请选择==", ""));
            //for (int i = 1; i < 10; i++)
            //{
            //   dpsort.Items.Add(new ListItem(i+"",i+"")); 
            //}
        }


        protected void btnAdd_OnClick(object sender, EventArgs e)
        {

            string savepath = DateTime.Now.Year + "_" + DateTime.Now.Month + "/" + DateTime.Now.Day;

            Expert ex = new Expert();
            ex.ExpertID = be.GetMaxID() + 1;
            ex.EName = PubCom.CheckString(txtEName.Text.Trim());
            ex.ECountry = PubCom.CheckString(txtECountry.Text.Trim());
            ex.ESummary = PubCom.CheckString(txtESummary.Text.Trim());
            if (dpIstop.SelectedValue != "")
                ex.Istop = dpIstop.SelectedValue == "1";
            if (dpEIdentification.SelectedValue != "")
                ex.EIdentification = dpEIdentification.SelectedValue;
            if (be.Insert(ex) == 1)
            {
                be.UploadValidate(pic_upload, lbl_pic, PicFilePath, savepath, ex.ExpertID);

                //// 插入日志 add
                SysOperateLog log = new SysOperateLog();
                log.LogID = StringHelper.getKey();
                log.LogType = LogType.专家信息.ToString();
                log.OperateUser = GetLogUserName();
                log.OperateDate = DateTime.Now;
                log.LogOperateType = "专家新增";

                log.LogAfterObject = JsonHelper.Obj2Json(ex);
                bsol.Insert(log);
                Message.ShowOKAndRedirect(this, "添加专家成功", "ExpertManage.aspx");
            }

            else
            {
                Message.ShowWrong(this, "添加专家失败！");
                return;
            }


        }



    }

}