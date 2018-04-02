using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
namespace Z
{
    /// <summary>
    ///cedar 的摘要说明
    /// </summary>
    public class SqlForbidden : IHttpModule
    {
        public SqlForbidden()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        public void Dispose()
        {

        }

        public void Init(HttpApplication application)
        {
            application.AcquireRequestState += new EventHandler(application_AcquireRequestState);
        }
        private void application_AcquireRequestState(object sender, EventArgs e)
    {
        HttpContext content = ((HttpApplication)sender).Context;
        try
        {
            string sqlErrorPage = "/";//转到默认页面
            string keyValue = string.Empty;
            string requestUrl = content.Request.Path.ToString();
            if (content.Request.QueryString != null)
            {
                foreach (string val in content.Request.QueryString)
                {
                   keyValue= content.Server.UrlDecode(content.Request.QueryString[val]);
                   if (!processSqlStr(keyValue))
                   {
                       content.Response.Write("您访问的页面发生错误，此问题我们已经记录并尽快改善，请稍后再试。<br><a href=\""+sqlErrorPage+"\">转到首页</a>");
                       content.Response.End();
                       break;
                   }
                }
            }
            if (content.Request.Form != null)
            {
                foreach(string val in content.Request.Form)
                {
                    keyValue = content.Server.HtmlDecode(content.Request.Form[val]);
                    if (keyValue == "_ViEWSTATE") continue;
                    if (!processSqlStr(keyValue))
                    {
                        content.Response.Write("您访问的页面发生错误，此问题我们已经记录并尽快改善，请稍后再试。");
                        content.Response.End();
                        break;
                    }
                }
            }
        }
        catch (Exception ex)
        {
        }
    }
        private bool processSqlStr(string str)
        {
            bool returnValue = true;
            try
            {
                if (str.Trim() != "")
                {
                    //取得webconfig中过滤字符串
                    string sqlStr = ConfigurationManager.AppSettings["FilterSql"].Trim();
                    //string sqlStr = "declare |exec|varchar |cursor |begin |open |drop |creat |select |truncate";
                    string[] sqlStrs = sqlStr.Split('|');
                    foreach (string ss in sqlStrs)
                    {
                        if (str.ToLower().IndexOf(ss) >= 0)
                        {
                            sqlStr = ss;
                            returnValue = false;
                            break;
                        }
                    }
                }
            }
            catch
            {
                returnValue = false;
            }
            return returnValue;
        }
    }
}