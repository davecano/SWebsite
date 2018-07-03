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
    public partial class StuMemberAdd : PageBase
    {
        public StuMemberAdd()
        {
            ModuleCode = "StuMemberManage";
            PageOperate = PurOperate.添加;
        }
        
   
     
        BMember bm = new BMember();
        BSysOperateLog bsol = new BSysOperateLog();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropdownlist();
            }
        }

        private void BindDropdownlist()
        {
            dpgrade.Items.Clear();
            dpgrade.Items.Add(new ListItem("==请选择==",""));
            for (int i = 2030; i > 2000; i--)
            {
                dpgrade.Items.Add(new ListItem(i+"",i+""));
            }
        }


        protected void btnAdd_OnClick(object sender, EventArgs e)
        {
            Member m=new Member();
            m.MemberID = bm.GetMaxID() + 1;
            m.MemberType = MemberType.普通学生.ToString();
            m.MemberName = PubCom.CheckString(txtMName.Text.Trim());
            m.Phone = PubCom.CheckString(txtPhone.Text.Trim());
            m.Email = PubCom.CheckString(txtMail.Text.Trim());
            m.Organization = PubCom.CheckString(ttxOrgName.Text.Trim());
            m.Qualification = PubCom.CheckString(txtQualification.Text.Trim());
            m.Grade = dpgrade.SelectedValue;
           

            if (bm.Insert(m) == 1)
            {
               //插入图片
                bm.UploadValidate(pic_upload, lbl_pic, PicFilePath, m.MemberID,MemberType.普通学生);
                //// 插入日志 add
                SysOperateLog log = new SysOperateLog();
                log.LogID = StringHelper.getKey();
                log.LogType = LogType.普通学生信息.ToString();
                log.OperateUser = GetLogUserName();
                log.OperateDate = DateTime.Now;
                log.LogOperateType = "普通学生信息新增";

                log.LogAfterObject = JsonHelper.Obj2Json(m);
                bsol.Insert(log);
                Message.ShowOKAndRedirect(this, "添加普通学生信息成功", "StuMemberManage.aspx");
            }

            else
            {
                Message.ShowWrong(this, "普通学生信息失败！");
                return;
            }


        }



    }

}