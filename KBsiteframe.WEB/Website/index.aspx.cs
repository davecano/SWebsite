using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KBsiteframe.Bll;
using KBsiteframe.Model;
using KBsiteframe.WEB.Comm;
using SysBase.BLL;
using SysBase.Model;
using Z;

namespace KBsiteframe.WEB.Website
{
    public partial class index : VistorPageBase
    {
        BNew bn = new BNew();
        public IList<New> piclist = new List<New>();

        BNotice bo = new BNotice();
        BDynamic bd = new BDynamic();
        BUser bu=new BUser();
        protected void Page_Load(object sender, EventArgs e)
        {
            EventHandler += () => plLogin.Visible = true;
            if (!IsPostBack)
            {

                BindDetail();
                BindDropdownList();

            }
        }

        private void BindDropdownList()
        {

        }

        private void BindDetail()
        {
            //绑定新闻,先将新闻信息列表展示
            IList<New> NewsTitleList = bn.GetNewsTitleList();

            rpNewList.DataSource = NewsTitleList;
            rpNewList.DataBind();
            var tlist = NewsTitleList.Take(3).ToList();
            foreach (var pic in tlist)
            {
                pic.NewsPicPath = ConfigurationManager.AppSettings["FileBasicPath"] + "/"
                  + pic.NewsPicPath;
                piclist.Add(pic);
            }
            if (tlist.Count < 3)
                for (int i = 0; i < 3 - tlist.Count; i++)
                {
                    piclist.Add(new New());
                }

            //绑定通知公告
            rpNoticeList.DataSource = bo.GetNoticesTitleList();
            rpNoticeList.DataBind();
            //绑定联盟动态
            rpLMlist.DataSource = bd.GetDynamicsTitleList(DynamicType.联盟动态);
            rpLMlist.DataBind();
            //绑定团队动态
            rpTDlist.DataSource = bd.GetDynamicsTitleList(DynamicType.团队动态);
            rpTDlist.DataBind();
        }


        protected void btnlogin_OnClick(object sender, EventArgs e)
        {
            //加这句话是为了避免页面刷新的时候会执行上一次的按钮操作事件
            //Response.Write("<script>document.location=document.location</script>");
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
                if (su.UserType == UserType.普通管理员.ToString())
                {
                    Message.ShowWrong(this, "不存在此用户！");
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
                    if (PubCom.login(su, PubCom.CheckString(txtUserName.Text.ToString().ToLower()), txtPassword.Text.Trim(), ckisrember.Checked))
                    {
                        //Message.ShowOKAndRedirect(this,"登录成功", "Index.aspx");
                        Server.Transfer("Index.aspx");
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