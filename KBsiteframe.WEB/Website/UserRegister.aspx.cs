using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KBsiteframe.Model;
using KBsiteframe.WEB.Comm;
using SysBase.BLL;
using SysBase.Model;
using Z;

namespace KBsiteframe.WEB.Website
{
    public partial class UserRegister : VistorPageBase
    {
        BUser bu = new BUser();
        BRole br = new BRole();
        BUserRole bur = new BUserRole();
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void btnReg_OnClick(object sender, EventArgs e)
        {
            SysUser su = new SysUser();
            su.UserID = System.Guid.NewGuid().ToString("N");//ID生成策略
            //su.UserLoginName = txtUserLoginName.Text.Trim();
            su.UserLoginName = txtUserName.Text.Trim();
            su.UserPassword = EncryptHelper.EncryptPassword(PubCom.CheckString(txtPsw.Text.Trim()), Constants.PassWordEncodeType);//默认密码
            su.Tel = txtPhone.Text.Trim();

            su.RegDate = DateTime.Now;
            su.Phone = txtPhone.Text.Trim();
            su.IsMain = true;
            su.Email = txtMail.Text.Trim();
            su.IsUse = true;
            su.UserType = UserType.访客.ToString();
            su.UserStatus = UserStatus.未审核.ToString();
            if (bu.GetUserByUserLoginName(su.UserLoginName) != null)
            {
                Message.ShowWrong(this, "用户登录名已经存在");
                txtUserName.Focus();
                return;
            }
            int rec = bu.Insert(su);
            if (rec == 1)
            {

                //为用户设置为vip角色，拥有自己的账号且有下载权限
                bur.Insert(new SysUserRole() { RoleID = 1, UserID = su.UserID });
                MailHelper.sendMail(SmtpServer, 1, MailServer, MailPassword, MailUserName, MailServer, txtMail.Text.Trim(),
                Subject, Content);
                Message.ShowAndClose("用户注册成功,系统已为您发送邮件，请查收");
            }
            else
            {
                Message.ShowWrong(this, "添加失败");
            }
        }
    }
}