using System;
using System.Web;
using System.Web.Extensions;
using System.Text;
namespace Z
{
    /// <summary>
    /// Msg 的摘要说明。
    /// </summary>
    public class Message
    {
        public Message()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 弹出提示，2秒后关闭
        /// </summary>
        /// <param name="objPage"></param>
        /// <param name="strHints"></param>
        public static void ShowOK(System.Web.UI.Page objPage, string strHints)
        {
            if (!objPage.IsStartupScriptRegistered(objPage.UniqueID + "MessageBox"))
            {
                StringBuilder str = new StringBuilder();
                str.Append("<script language=\"JavaScript\">");
                str.Append(" layer.msg('" + strHints + "',2,9);");
                str.Append("</script>");
                objPage.RegisterStartupScript(objPage.UniqueID + "MessageBox", str.ToString());
            }
        }

        public static void ShowIframe(System.Web.UI.Page objPage, string pageurl)
        {
            if (!objPage.IsStartupScriptRegistered(objPage.UniqueID + "MessageBox"))
            {
                StringBuilder str = new StringBuilder();
                str.Append("<script language=\"JavaScript\">");
                str.Append(" ShowIframeNotClose('" + pageurl + "')");
                str.Append("</script>");
                objPage.RegisterStartupScript(objPage.UniqueID + "MessageBox", str.ToString());
            }
        }

        public static void ShowOKAndClose(System.Web.UI.Page objPage, string strHints)
        {
            if (!objPage.IsStartupScriptRegistered(objPage.UniqueID + "MessageBox"))
            {
                StringBuilder str = new StringBuilder();
                str.Append("<script language=\"JavaScript\">");
                str.Append(" parent.layer.msg('" + strHints + "',2,9);");
                str.Append("parent.layer.close(parent.layer.getFrameIndex(window.name));");
                str.Append("</script>");
                objPage.RegisterStartupScript(objPage.UniqueID + "MessageBox", str.ToString());
            }
        }

        /// <summary>
        /// 弹出提示,2秒后关闭并刷新父页面
        /// </summary>
        /// <param name="objPage"></param>
        /// <param name="strHints"></param>
        /// <param name="ControlID">父页面事件控件ID</param>
        public static void ShowOKAndReflashParent(System.Web.UI.Page objPage, string strHints, string ControlID)
        {
            if (!objPage.IsStartupScriptRegistered(objPage.UniqueID + "MessageBox"))
            {
                StringBuilder str = new StringBuilder();
                str.Append("<script language=\"JavaScript\">");
                str.Append("setTimeout(function(){$('#" + ControlID + "', window.parent.document).click();},2000);");
                str.Append(" parent.layer.msg('" + strHints + "',2,9);");
                //str.Append("parent.layer.close(parent.layer.getFrameIndex(window.name));");
                str.Append("</script>");
                objPage.RegisterStartupScript(objPage.UniqueID + "MessageBox", str.ToString());
            }
        }

        public static void ShowOKAndReflashClose(System.Web.UI.Page objPage, string strHints, string ControlID)
        {
            if (!objPage.IsStartupScriptRegistered(objPage.UniqueID + "MessageBox"))
            {
                StringBuilder str = new StringBuilder();
                str.Append("<script language=\"JavaScript\">");
                str.Append("$('#" + ControlID + "', window.parent.document).click();");
                str.Append(" parent.layer.msg('" + strHints + "',2,9);");
                str.Append("var index = parent.layer.getFrameIndex(window.name);");
                str.Append("parent.layer.close(index);");
                //str.Append("parent.layer.close(parent.layer.getFrameIndex(window.name));");
                str.Append("</script>");
                objPage.RegisterStartupScript(objPage.UniqueID + "MessageBox", str.ToString());
            }
        }

        public static void ShowOKAndReflash(System.Web.UI.Page objPage, string strHints, string ControlID)
        {
            if (!objPage.IsStartupScriptRegistered(objPage.UniqueID + "MessageBox"))
            {
                StringBuilder str = new StringBuilder();
                str.Append("<script language=\"JavaScript\">");
                str.Append("setTimeout(function(){$('#" + ControlID + "', window.document).click();},2000);");
                str.Append("layer.msg('" + strHints + "',2,9);");
                //str.Append("parent.layer.close(parent.layer.getFrameIndex(window.name));");
                str.Append("</script>");
                objPage.RegisterStartupScript(objPage.UniqueID + "MessageBox", str.ToString());
            }
        }
        public static void ShowRedirect(System.Web.UI.Page objPage, string PageUrl)
        {
            if (!objPage.IsStartupScriptRegistered(objPage.UniqueID + "MessageBox"))
            {
                StringBuilder str = new StringBuilder();
                str.Append("<script language=\"JavaScript\">");
                str.Append("window.location.href='" + PageUrl + "'");
                //str.Append(" layer.msg('" + strHints + "',2,9);");
                //str.Append("parent.layer.close(parent.layer.getFrameIndex(window.name));");
                str.Append("</script>");
                objPage.RegisterStartupScript(objPage.UniqueID + "MessageBox", str.ToString());
            }
        }
        public static void ShowOKAndRedirectParent(System.Web.UI.Page objPage, string strHints, string PageUrl)
        {
            if (!objPage.IsStartupScriptRegistered(objPage.UniqueID + "MessageBox"))
            {
                StringBuilder str = new StringBuilder();
                str.Append("<script language=\"JavaScript\">");
                str.Append("setTimeout(function(){ window.location.href='" + PageUrl + "'},2000);");
                str.Append(" parent.layer.msg('" + strHints + "',2,9);");
                //str.Append("parent.layer.close(parent.layer.getFrameIndex(window.name));");
                str.Append("</script>");
                objPage.RegisterStartupScript(objPage.UniqueID + "MessageBox", str.ToString());
            }
        }
        public static void ShowOKAndRedirect(System.Web.UI.Page objPage, string strHints, string PageUrl)
        {
            if (!objPage.IsStartupScriptRegistered(objPage.UniqueID + "MessageBox"))
            {
                StringBuilder str = new StringBuilder();
                str.Append("<script language=\"JavaScript\">");
                str.Append("setTimeout(function(){ window.location.href='" + PageUrl + "'},2000);");
                str.Append(" layer.msg('" + strHints + "',2,9);");
                //str.Append("parent.layer.close(parent.layer.getFrameIndex(window.name));");
                str.Append("</script>");
                objPage.RegisterStartupScript(objPage.UniqueID + "MessageBox", str.ToString());
            }
        }
        public static void ShowOKAndBackParent(System.Web.UI.Page objPage, string strHints)
        {
            if (!objPage.IsStartupScriptRegistered(objPage.UniqueID + "MessageBox"))
            {
                StringBuilder str = new StringBuilder();
                str.Append("<script language=\"JavaScript\">");
                str.Append("setTimeout(function(){ history.back(-1)},2000);");
                str.Append(" parent.layer.msg('" + strHints + "',2,9);");
                //str.Append("parent.layer.close(parent.layer.getFrameIndex(window.name));");
                str.Append("</script>");
                objPage.RegisterStartupScript(objPage.UniqueID + "MessageBox", str.ToString());
            }
        }

        public static void ShowOKAndBack(System.Web.UI.Page objPage, string strHints)
        {
            if (!objPage.IsStartupScriptRegistered(objPage.UniqueID + "MessageBox"))
            {
                StringBuilder str = new StringBuilder();
                str.Append("<script language=\"JavaScript\">");
                str.Append("setTimeout(function(){ history.back(-1)},2000);");
                str.Append("layer.msg('" + strHints + "',2,9);");
                //str.Append("parent.layer.close(parent.layer.getFrameIndex(window.name));");
                str.Append("</script>");
                objPage.RegisterStartupScript(objPage.UniqueID + "MessageBox", str.ToString());
            }
        }


        public static void ShowOKAndReflashOfDelete(System.Web.UI.Page objPage, string strHints, string ControlID)
        {
            if (!objPage.IsStartupScriptRegistered(objPage.UniqueID + "MessageBox"))
            {
                StringBuilder str = new StringBuilder();
                str.Append("<script language=\"JavaScript\">");
                str.Append("setTimeout(function(){$('#" + ControlID + "', window.document).click();},2000);");
                str.Append(" layer.msg('" + strHints + "',2,9);");
                //str.Append("parent.layer.close(parent.layer.getFrameIndex(window.name));");
                str.Append("</script>");
                objPage.RegisterStartupScript(objPage.UniqueID + "MessageBox", str.ToString());
                //objPage.ClientScript.RegisterStartupScript(objPage.GetType(), "", str.ToString());
            }
        }

        public static void ShowWrong(System.Web.UI.Page objPage, string strHints)
        {
            if (!objPage.IsStartupScriptRegistered(objPage.UniqueID + "MessageBox"))
            {
                StringBuilder str = new StringBuilder();
                str.Append("<script language=\"JavaScript\">");
                str.Append(" layer.msg('" + strHints + "',2,8);");
                str.Append("</script>");
                objPage.RegisterStartupScript(objPage.UniqueID + "MessageBox", str.ToString());
            }
        }
        public static void ShowWrongAndClose(System.Web.UI.Page objPage, string strHints)
        {
            if (!objPage.IsStartupScriptRegistered(objPage.UniqueID + "MessageBox"))
            {
                StringBuilder str = new StringBuilder();
                str.Append("<script language=\"JavaScript\">");
                str.Append(" parent.layer.msg('" + strHints + "',2,8);");
                str.Append("parent.layer.close(parent.layer.getFrameIndex(window.name));");
                str.Append("</script>");
                objPage.RegisterStartupScript(objPage.UniqueID + "MessageBox", str.ToString());
            }
        }
        public static void ShowWrongAndBackParent(System.Web.UI.Page objPage, string strHints)
        {
            if (!objPage.IsStartupScriptRegistered(objPage.UniqueID + "MessageBox"))
            {
                StringBuilder str = new StringBuilder();
                str.Append("<script language=\"JavaScript\">");
                str.Append("setTimeout(function(){ history.back(-1)},2000);");
                str.Append(" parent.layer.msg('" + strHints + "',2,9);");
                //str.Append("parent.layer.close(parent.layer.getFrameIndex(window.name));");
                str.Append("</script>");
                objPage.RegisterStartupScript(objPage.UniqueID + "MessageBox", str.ToString());
            }
        }

        public static void ShowWrongAndBack(System.Web.UI.Page objPage, string strHints)
        {
            if (!objPage.IsStartupScriptRegistered(objPage.UniqueID + "MessageBox"))
            {
                StringBuilder str = new StringBuilder();
                str.Append("<script language=\"JavaScript\">");
                str.Append("setTimeout(function(){ history.back(-1)},2000);");
                str.Append("layer.msg('" + strHints + "',2,9);");
                //str.Append("parent.layer.close(parent.layer.getFrameIndex(window.name));");
                str.Append("</script>");
                objPage.RegisterStartupScript(objPage.UniqueID + "MessageBox", str.ToString());
            }
        }




        /// <summary>
        /// 弹出一个提醒
        /// </summary>
        /// <param name="strMsg"></param>
        public static void Show(string strMsg)
        {
            System.Web.HttpContext.Current.Response.Write("<Script Language='JavaScript'>window.alert('" + strMsg + "');</script>");
        }
        /// <summary>
        /// 弹出一个提醒
        /// </summary>
        /// <param name="page"></param>
        /// <param name="strMsg"></param>
        public static void Show(System.Web.UI.Page page, string strMsg)
        {
            page.Response.Write("<Script Language='JavaScript'>window.alert('" + strMsg + "');</script>");
        }
        /// <summary>
        /// 弹出提醒后转向目标地址
        /// </summary>
        /// <param name="strMsg"></param>
        /// <param name="Url"></param>
        public static void Show(string strMsg, string Url)
        {
            System.Web.HttpContext.Current.Response.Write("<Script Language='JavaScript'>window.alert('" + strMsg + "');window.location.href ='" + Url + "'</script>");
        }
        /// <summary>
        /// 弹出提醒后转向目标地址
        /// </summary>
        /// <param name="page"></param>
        /// <param name="strMsg"></param>
        /// <param name="Url"></param>
        public static void Show(System.Web.UI.Page page, string strMsg, string Url)
        {
            page.Response.Write("<Script Language='JavaScript'>window.alert('" + strMsg + "');window.location.href ='" + Url + "'</script>");
        }
        /// <summary>
        /// 弹出提醒后根据选择转向目标地址
        /// </summary>
        /// <param name="strMsg"></param>
        /// <param name="strUrl_Yes"></param>
        /// <param name="strUrl_No"></param>
        public static void Confirm(string strMsg, string strUrl_Yes, string strUrl_No)
        {
            System.Web.HttpContext.Current.Response.Write("<Script Language='JavaScript'>if ( window.confirm('" + strMsg + "')) {  window.location.href='" + strUrl_Yes +
                              "' } else {window.location.href='" + strUrl_No + "' };</script>");
        }

        public static void ShowAndBack(string strMsg)
        {
            System.Web.HttpContext.Current.Response.Write("<Script Language='JavaScript'>window.alert('" + strMsg + "');history.back(-1);</script>");
        }
        public static void ShowAndClose(string strMsg)
        {
            System.Web.HttpContext.Current.Response.Write("<Script Language='JavaScript'>window.alert('" + strMsg + "');window.close();</script>");
        }
    }
}