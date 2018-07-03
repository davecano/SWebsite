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
    public partial class TDMemberAdd : PageBase
    {
        public TDMemberAdd()
        {
            ModuleCode = "TDMemberManage";
            PageOperate = PurOperate.添加;
        }
        
   
     
        BMember bm = new BMember();
        BSysOperateLog bsol = new BSysOperateLog();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
             
            }
        }

       


        protected void btnAdd_OnClick(object sender, EventArgs e)
        {
            Member m=new Member();
            m.MemberID = bm.GetMaxID() + 1;
            m.MemberType = MemberType.团队成员.ToString();
            m.MemberName = PubCom.CheckString(txtMName.Text.Trim());
            m.Phone = PubCom.CheckString(txtPhone.Text.Trim());
            m.Email = PubCom.CheckString(txtMail.Text.Trim());
            m.Organization = PubCom.CheckString(ttxOrgName.Text.Trim());
            m.Qualification = PubCom.CheckString(txtQualification.Text.Trim());

           

            if (bm.Insert(m) == 1)
            {
                //插入图片
                bm.UploadValidate(pic_upload, lbl_pic, PicFilePath, m.MemberID, MemberType.团队成员);
                //// 插入日志 add
                SysOperateLog log = new SysOperateLog();
                log.LogID = StringHelper.getKey();
                log.LogType = LogType.团队成员信息.ToString();
                log.OperateUser = GetLogUserName();
                log.OperateDate = DateTime.Now;
                log.LogOperateType = "团队成员新增";

                log.LogAfterObject = JsonHelper.Obj2Json(m);
                bsol.Insert(log);
                Message.ShowOKAndRedirect(this, "添加团队成员成功", "TDMemberManage.aspx");
            }

            else
            {
                Message.ShowWrong(this, "添加团队成员失败！");
                return;
            }


        }



    }

}