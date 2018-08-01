using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KBsiteframe.Model;
using KBsiteframe.WEB.Comm;
using SysBase.Model;
using Z;
using SysBase;
using SysBase.BLL;

namespace KBsiteframe.WEB
{
    public partial class Login : System.Web.UI.Page
    {
        BUser bu = new BUser();

        protected void Page_Load(object sender, EventArgs e)
        {
            txtUserName.Text = "admin";
            txtPassword.Text = "999999";

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["checkcode"] == null)
            {
                Message.ShowWrong(this, "验证码失效");
                Image1.ImageUrl = "../share/ImgCreator.aspx?id=1&flag=" + DateTime.Now.ToShortTimeString();
                txtImg.Text = "";
                txtImg.Focus();
                return;

            }
            if (txtUserName.Text.Trim() == "")
            {
                Message.ShowWrong(this, "请输入用户名");
                txtImg.Text = "";
                txtImg.Focus();
                return;
            }
            if (txtPassword.Text.Trim() == "")
            {
                Message.ShowWrong(this, "请输入密码");
                txtImg.Text = "";
                txtImg.Focus();
                return;
            }
            if (txtImg.Text.Trim() == "")
            {
                Message.ShowWrong(this, "请输入验证码");
                txtImg.Focus();
                return;
            }
            if (Session["checkcode"].ToString().ToLower() != txtImg.Text.Trim().ToLower())
            {
                Message.ShowWrong(this, "验证码错误");
                Image1.ImageUrl = "../share/ImgCreator.aspx?id=1&flag=" + DateTime.Now.ToShortTimeString();
                txtImg.Text = "";
                txtImg.Focus();
                return;
            }
            

            SysUser su = bu.GetUserByUserLoginName(PubCom.CheckString(txtUserName.Text.ToString().ToLower()));
            if (su == null) su = bu.GetUserByTel(PubCom.CheckString(txtUserName.Text.ToString().ToLower()));

            if (su == null)
            {
                Message.ShowWrong(this, "不存在此用户");
                txtImg.Text = "";
                return;
            }

            if (su.UserPassword == Z.EncryptHelper.EncryptPassword(txtPassword.Text.Trim(), Constants.PassWordEncodeType))
            {
                if(su.UserType==UserType.访客.ToString())
                {
                    Message.ShowWrong(this, "您的账号为访客账号！");
                    txtImg.Text = "";
                }
                else if (su.UserStatus != UserStatus.审核通过.ToString())
                {

                    Message.ShowWrong(this, "您的账号不是审核通过状态！请与管理员联系！");
                    txtImg.Text = "";
                }
                else if (su.IsUse == false)
                {

                    Message.ShowWrong(this, "您的账号已经被禁用！请与管理员联系！");
                    txtImg.Text = "";
                }
                else
                {

                    //可以登陆
                    if (PubCom.login(su, PubCom.CheckString(txtUserName.Text.ToString().ToLower()), txtPassword.Text.Trim()))
                    {
                        Response.Redirect("~/Share/Index.aspx");
                    }
                    else
                    {
                        Message.ShowWrong(this, "用户名或密码错误");
                        txtImg.Text = "";
                    }
                }

            }
            else
            {
                Message.ShowWrong(this, "用户名或密码错误");
                txtImg.Text = "";
            }
        }
        
    }
}