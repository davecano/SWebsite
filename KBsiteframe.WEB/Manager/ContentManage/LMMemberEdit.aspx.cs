using System;
using System.Collections;
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
    public partial class LMMemberEdit : PageBase
    {
        public LMMemberEdit()
        {
            ModuleCode = "LMMemberManage";
            PageOperate = PurOperate.修改;
        }
        
   
     
        BMember bm = new BMember();
        BSysOperateLog bsol = new BSysOperateLog();
        protected void Page_Load(object sender, EventArgs e)
        {
            hfMemberID.Value = PubCom.Q("ID");
            if (!IsPostBack)
            {
                BindDetail();
            }
        }

        private void BindDetail()
        {
            Member m = bm.GetMembersByID(Utils.StrToInt(hfMemberID.Value,0));
            txtMName.Text = m.MemberName;
            txtMail.Text = m.Email;
            txtPhone.Text = m.Phone;
            txtQualification.Text = m.Qualification;
            ttxOrgName.Text = m.Organization;
            if (m.MemberPic != "")
                ImgNews.ImageUrl = PicFilePathV + m.MemberPic;
        }


        protected void btnAdd_OnClick(object sender, EventArgs e)
        {
            Member m=new Member();
            m.MemberID = Utils.StrToInt(hfMemberID.Value, 0);
        
            m.MemberName = PubCom.CheckString(txtMName.Text.Trim());
            m.Phone = PubCom.CheckString(txtPhone.Text.Trim());
            m.Email = PubCom.CheckString(txtMail.Text.Trim());
            m.Organization = PubCom.CheckString(ttxOrgName.Text.Trim());
            m.Qualification = PubCom.CheckString(txtQualification.Text.Trim());


            Member mold = bm.GetMembersByID(Utils.StrToInt(hfMemberID.Value, 0));
            if (bm.Update(m) == 1)
            {
                //插入图片
                bm.UploadValidate(pic_upload, lbl_pic, PicFilePath, m.MemberID, BMember.RoleType.联盟成员);
                //// 插入日志 add
                SysOperateLog log = new SysOperateLog();
                log.LogID = StringHelper.getKey();
                log.LogType = LogType.联盟成员信息.ToString();
                log.OperateUser = GetLogUserName();
                log.OperateDate = DateTime.Now;
                log.LogOperateType = "联盟成员修改";
                log.LogBeforeObject = JsonHelper.Obj2Json(mold);
                log.LogAfterObject = JsonHelper.Obj2Json(m);
                bsol.Insert(log);
                Message.ShowOKAndRedirect(this, "修改联盟成员成功", "LMMemberManage.aspx");
            }

            else
            {
                Message.ShowWrong(this, "修改联盟成员失败！");
                return;
            }


        }



    }

}