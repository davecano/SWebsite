using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SysBase.BLL;
using SysBase.Model;
using Z;


namespace KBsiteframe.WEB.Comm
{
    /// <summary>
    ///     所有页面的基类
    /// </summary>
    public class VistorPageBase : System.Web.UI.Page
    {
        public string CompanyCode = ConfigurationManager.AppSettings["CompanyCode"];

        public int PageSize = Constants.GRIDVIEW_PAGE_SIZE;

        public string PicFilePath =
            HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["FileBasicPath"]) + "\\";

        /// <summary>
        ///     上传文件路径
        /// </summary>
        public string PicFilePathV = ConfigurationManager.AppSettings["FileBasicPath"] + "/";


        public string ProjectFilePath = ConfigurationManager.AppSettings["ProjectFilePath"];

        /// <summary>
        ///     资质提醒天数
        /// </summary>
        public string QualificationReminderDate = ConfigurationManager.AppSettings["QualificationReminderDate"];

        /// <summary>
        /// SmtpServer 服务
        /// </summary>
        public string SmtpServer = ConfigurationManager.AppSettings["SmtpServer"];
        /// <summary>
        /// 发送方邮件账号
        /// </summary>
        public string MailServer = ConfigurationManager.AppSettings["MailServer"];
        /// <summary>
        /// 授权码
        /// </summary>
        public string MailPassword = ConfigurationManager.AppSettings["MailPassword"];
        /// <summary>
        /// 发送方用户名
        /// </summary>
        public string MailUserName = ConfigurationManager.AppSettings["MailUserName"];
        BPageVisit bv=new BPageVisit();

        public void Q(string name, out string param)
        {
            param = "";
            if (Request.QueryString[name] == null)
            {
                Message.ShowAndBack("参数错误");
                return;
            }
            if (string.IsNullOrEmpty(Request.QueryString[name].Trim()))
            {
                Message.ShowAndBack("参数错误");
                return;
            }
            //解密
            param = EncryptHelper.Decode(Request.QueryString[name].Trim());
        }


        public static string Q(string name)
        {
            if (HttpContext.Current.Request.QueryString[name] == null)
            {
                return "";
            }
            if (string.IsNullOrEmpty(HttpContext.Current.Request.QueryString[name].Trim()))
            {
                return "";
            }
            return PubCom.CheckString(HttpContext.Current.Request.QueryString[name].Trim());
        }

      

        #region 属性

        /// <summary>
        ///     设置模块代码，必须在子类中设置
        /// </summary>
        protected string ModuleCode { set; get; } = string.Empty;

        /// <summary>
        ///     设置 进入页面需要的操作类型
        /// </summary>
        protected PurOperate PageOperate { set; get; } = PurOperate.查询;

        protected string NoPermissionUrl { set; get; } = "~/NoPermission.aspx";

        /// <summary>
        ///     返回页面
        /// </summary>
        protected string ReturnUrl { get; set; } = string.Empty;

        /// <summary>
        ///     设置QueryCondition 加密串
        /// </summary>
        protected string QueryCondition { get; set; } = "";

        #endregion

        #region"内部事件"

        /// <summary>
        ///     构造函数
        /// </summary>
        public VistorPageBase()
        {
            Load += PageBase_Load;
            LoadComplete += PageBase_LoadComplete;
        }

        /// <summary>
        ///     重载OnLoad 给带权限控件的Validate事件绑定验证方法
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            //将页面中所有继承IRbacControl的控件注册验证事件
            BindrbacValidateEvent(Page);
            base.OnLoad(e);
        }

        /// <summary>
        ///     重载OnPreRender 给带权限控件的 PreRender事件绑定验证方法
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreRender(EventArgs e)
        {
            ////将页面中所有继承IRbacControl的控件注册呈现事件
            BindrbacPreRenderEvent(Page);
            base.OnPreRender(e);
        }

        /// <summary>
        ///     重写ProcessRequest
        /// </summary>
        /// <param name="context"></param>
        public override void ProcessRequest(HttpContext context)
        {
            ////从浏览器重输入的URl 不做返回处理
            //if (context.Request.UrlReferrer != null && context.Request[Constants.QUERYSTRING_RETURN_URL] == null)
            //{
            //    //从菜单页面来 无需记录returnUrl
            //    if (context.Request.UrlReferrer.AbsolutePath.IndexOf("Default") != -1 || context.Request.UrlReferrer.AbsolutePath.EndsWith("/"))
            //    {
            //        base.ProcessRequest(context);
            //    }
            //    //两次停留在同一页面 则不做返回处理
            //    else if (context.Request.UrlReferrer.AbsolutePath != context.Request.Url.AbsolutePath)
            //    {
            //        //去掉多余的returnUrl参数
            //        int index = context.Request.UrlReferrer.PathAndQuery.IndexOf(Constants.QUERYSTRING_RETURN_URL);
            //        string returnUrl = "";
            //        if (index != -1)
            //        {
            //            //去掉多余的returnUrl参数
            //            returnUrl = Constants.QUERYSTRING_RETURN_URL + "=" + HttpUtility.UrlEncode(context.Request.UrlReferrer.PathAndQuery.Substring(0, index - 1));
            //        }
            //        else
            //        {
            //            returnUrl = Constants.QUERYSTRING_RETURN_URL + "=" + HttpUtility.UrlEncode(context.Request.UrlReferrer.PathAndQuery);
            //        }
            //        //当前页面无参数的要使用 "?" 追加 returnRrl
            //        if (context.Request.Url.Query != "")
            //        {
            //            context.Response.Redirect(context.Request.Url.PathAndQuery + "&" + returnUrl);
            //        }
            //        else
            //        {
            //            context.Response.Redirect(context.Request.Url.PathAndQuery + "?" + returnUrl);
            //        }
            //    }
            //    else
            //    {
            //        base.ProcessRequest(context);
            //    }
            //}
            //else
            //{
            //    base.ProcessRequest(context);
            //}
            base.ProcessRequest(context);
        }

        /// <summary>
        ///     重写render 将页面中脚本替换成 defer 使得js懒加载
        /// </summary>
        /// <param name="writer"></param>
        protected override void Render(HtmlTextWriter writer)
        {
            //string oldContent;
            //string newContent;
            //StringWriter stringWriter = new StringWriter();
            //HtmlTextWriter oldwriter = new HtmlTextWriter(stringWriter);
            //base.Render(oldwriter);

            //oldContent = stringWriter.ToString();
            //newContent = oldContent.Replace("type=\"text/javascript\">", "type=\"text/javascript\" defer>");
            //writer.Write(newContent);
            base.Render(writer);
        }

        #endregion

        #region 事件

        /// <summary>
        ///     load事件处理，先于aspx页面Page_Load执行
        /// </summary>
        private void PageBase_Load(object sender, EventArgs e)
        {
            //检查页面执行权限
            CheckAuthority();
            //设置returnurl
            GetReturnUrl();
            //获取查询条件
            GetQueryCondition();
        }

        /// <summary>
        ///     loadComplete事件处理
        /// </summary>
        private void PageBase_LoadComplete(object sender, EventArgs e)
        {
            //记录访问日志
            string filename = Path.GetFileName(HttpContext.Current.Request.Path);
            var ip = "";
            if (HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null) // 服务器， using proxy
            {
                //得到真实的客户端地址
                if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
                {
                    ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                }
            }
            else //如果没有使用代理服务器或者得不到客户端的ip  not using proxy or can't get the Client IP
            {
                if (HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"] != null)
                {
                    //得到服务端的地址
                    ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                }
            }
            PageVisitDetail pd=new PageVisitDetail();
            pd.IP = ip;
            pd.PageName = filename;
            bv.insert(pd);

            if (!ValidateSession())
            {
                //显示未登录
                EventHandler?.Invoke();

            }
        }

        /// <summary>
        ///     控件的PreRender事件处理 决定控件的呈现
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void control_PreRender(object sender, EventArgs e)
        {
            var rbacCtrl = (IPurControl) sender;
            var control = (WebControl) sender;

            //根据控件所进行的操作 动态设定其呈现状态
            if (rbacCtrl.AttributeToControl == "Enabled")
            {
                control.Enabled = control.Enabled && ValidateRight(rbacCtrl);
            }
            else
            {
                control.Visible = control.Visible && ValidateRight(rbacCtrl);
            }
        }

        /// <summary>
        ///     控件的Validate事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbacCtrl_Validate(object sender, EventArgs e)
        {
            var rbacCtrl = (IPurControl) sender;

            if (!ValidateRight(rbacCtrl))
            {
                //取消控件动作
                rbacCtrl.ActionCancel = true;
                //跳转到无权访问页面
                NoPermission();
            }
        }

        #endregion

        #region 私有方法

        public event Action EventHandler;
        /// <summary>
        ///     检查页面执行权限
        /// </summary>
        private void CheckAuthority()
        {
            if (!ValidateSession())
            {
                //显示未注册
           
              
            }
           
        }

        /// <summary>
        ///     递归寻找控件 并注册验证事件 （验证事件在 click事件之前发生）
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="strCommandName"></param>
        private void BindrbacValidateEvent(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control.HasControls())
                {
                    BindrbacValidateEvent(control);
                }
                else if (control is IPurControl)
                {
                    //将页面中继承IRbacControl的控件且启用权限控制的控件 注入验证事件
                    var rbacCtrl = (IPurControl) control;
                    if (rbacCtrl.EnablePur)
                    {
                        rbacCtrl.Validate += rbacCtrl_Validate;
                    }
                }
            }
        }

        /// <summary>
        ///     递归寻找控件 并注册控件呈现事件
        /// </summary>
        /// <param name="parent"></param>
        private void BindrbacPreRenderEvent(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control.HasControls())
                {
                    BindrbacPreRenderEvent(control);
                }
                else if (control is IPurControl)
                {
                    //将页面中继承IRbacControl的控件且启用权限控制的控件 注入验证事件
                    var rbacCtrl = (IPurControl) control;
                    if (rbacCtrl.EnablePur)
                    {
                        control.PreRender += control_PreRender;
                    }
                }
            }
        }

        /// <summary>
        ///     验证控件操作权限
        /// </summary>
        /// <returns></returns>
        private bool ValidateRight(IPurControl rbacCtrl)
        {
            var control = (Control) rbacCtrl;
            //如果控件的模块号为空 则集成页面的模块号
            if (rbacCtrl.ModuleCode == string.Empty)
            {
                rbacCtrl.ModuleCode = ((VistorPageBase) control.Page).ModuleCode;
            }

            var isHaveRight = true;
            if (rbacCtrl.EnablePur)
            {
                if (rbacCtrl.ModuleCode != "" && rbacCtrl.Operate != null)
                {
                    isHaveRight = ValidateModuleRight(rbacCtrl.ModuleCode, rbacCtrl.Operate);
                }
            }
            return isHaveRight;
        }

        /// <summary>
        ///     设置returnUrl
        /// </summary>
        private void GetReturnUrl()
        {
            if (HttpContext.Current.Request.QueryString[Constants.QUERYSTRING_RETURN_URL] != null)
            {
                var index = HttpContext.Current.Request.QueryString[Constants.QUERYSTRING_RETURN_URL].IndexOf(",");
                if (index == -1)
                {
                    ReturnUrl = HttpContext.Current.Request.QueryString[Constants.QUERYSTRING_RETURN_URL];
                }
                else
                {
                    ReturnUrl = HttpContext.Current.Request.QueryString[Constants.QUERYSTRING_RETURN_URL].Substring(0,
                        index);
                }
            }
        }

        /// <summary>
        /// </summary>
        public string SetQueryCondition<T>(T obj)
        {
            QueryCondition = StringHelper.ConvertObjectToString(obj);
            return HttpUtility.UrlEncode(QueryCondition);
        }

        private void GetQueryCondition()
        {
            if (HttpContext.Current.Request.QueryString[Constants.QUERYSTRING_QUERY_CONDITION] != null)
            {
                var hashkey = HttpContext.Current.Request.QueryString[Constants.QUERYSTRING_QUERY_CONDITION];
                QueryCondition = hashkey;
            }
        }

        #endregion

        #region 业务逻辑接口 可修改部分

        /// <summary>
        ///     页面级权限判断
        /// </summary>
        /// <param name="strModuleName"></param>
        /// <returns></returns>
        private bool ValidatePageRight(string strModuleNo)
        {
            var isHaveRight = true;
            if (strModuleNo != "")
            {
                isHaveRight = ValidateModuleRight(strModuleNo, PageOperate);
            }
            return isHaveRight;
        }

        /// <summary>
        ///     操作级权限判断
        /// </summary>
        /// <param name="strModuleNo"></param>
        /// <param name="strOperateType"></param>
        /// <returns></returns>
        protected bool ValidateModuleRight(string strModuleNo, PurOperate strOperateType)
        {
            var ac = (Account) Session["Account"];
            if (ac.User.UserID == Constants.AdminName)
            {
                return true;
            }
            if (
                ac.OperateList.Where(p => p.ModuleCode == strModuleNo && p.OperateName == strOperateType.ToString())
                    .ToList()
                    .Count > 0)
            {
                return true;
            }
            return false;
        }

        public Account CurrentAccount;

        /// <summary>
        ///     检查用户Session是否正常
        /// </summary>
        /// <returns></returns>
        private bool ValidateSession()
        {
            if (Session["Account"] == null)
            {
                return false;  //when i solve the 'session' problem,i will edit it back.
            }
            CurrentAccount = (Account) Session["Account"];
            return true;
        }

        /// <summary>
        ///     操作无权
        /// </summary>
        protected void NoPermission()
        {
            Response.Redirect(NoPermissionUrl);
        }

        /// <summary>
        ///     未登陆
        /// </summary>
        private void NoLogin()
        {
            Response.Write("<script>window.top.location.href = '/Login.aspx';alert('登陆超时,请重新登陆');</script>");
            Response.End();
            //Response.Redirect("~/NoLogin.aspx");
        }

        protected bool IsAdmin()
        {
            if (((Account) Session["Account"]).User.UserID == Constants.AdminName)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 获取日志中的操作人信息
        /// </summary>
        /// <returns></returns>
        public string GetLogUserName()
        {
            string UserName = "[" + CurrentAccount.User.UserLoginName + "]" + CurrentAccount.User.UserName;
            return UserName;
        }
        #endregion
    }
}