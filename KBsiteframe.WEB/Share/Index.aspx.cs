using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SysBase.BLL;
using SysBase.Model;

using Z;
using System.Web.Services;
using MyCmsWEB;

namespace KBsiteframe.Web.Share
{
    public partial class Index : PageBase
    {
        BMenu bm = new BMenu();
        BUser bu = new BUser();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblUser.Text = CurrentAccount.User.UserName.ToString();
                BindUrl();
                BindMenu();
            }
        }

        private void BindUrl()
        {
            HpUserMsg.NavigateUrl = "/Share/UserInfo.aspx?ID=" + EncryptHelper.Encode(CurrentAccount.User.UserID);
            HfPsw.Value = EncryptHelper.Encode(CurrentAccount.User.UserID);
            //HpUserPsw.NavigateUrl="/Share/UpdatePassword.aspx?ID="+ EncryptHelper.Encode(CurrentAccount.User.UserID);
        }

        string firstmenu = " class=\"active\" ";

        /// <summary>
        /// 绑定菜单
        /// </summary>
        void BindMenu()
        {
            Account ac = (Account)Session["Account"];
            string str = "";
            Query qm = Query.Build(new { IsVisiable = 1, SortFields = "MenuSort" });
            

            IList<SysMenu> lsmAll = bm.GetMenuList(qm);

            foreach (SysMenu sm in lsmAll.Where<SysMenu>(p => p.ParentMenuID == 0).ToList<SysMenu>())
            {

                IList<SysMenu> luom = lsmAll.Where<SysMenu>(p => p.ParentMenuID == sm.MenuID).ToList<SysMenu>();
                if (luom.Count > 0)
                {
                    if (sm.IsLeaf == false)
                    {
                        str += "<li>";
                        str += "<a href=\"#\" class=\"dropdown-toggle\"><i class=\"" + sm.MenuIco + "\"></i><span class=\"menu-text\">" + sm.MenuName + "</span><b class=\"arrow icon-angle-down\"></b></a>";
                        str += " <ul class=\"submenu\">";
                        foreach (SysMenu ssm in luom)
                        {
                            string type = "";
                            str += "<li><a href='" + ssm.PageUrl;
                            if (ssm.PageUrl.IndexOf('?') >= 0)
                            {
                                str += "&";
                                string nt = ssm.PageUrl.Substring(ssm.PageUrl.IndexOf('=') + 1);
                                type = EncryptHelper.Decode(nt);
                            }
                            else
                            {
                                str += "?";
                            }
                            str += "menu=" + ssm.MenuID + "' target='frmright' onClick=\"changeBarName('" + ssm.MenuName + "');\"><i class=\"icon-double-angle-right\"></i><span class=\"menu-text\">" + ssm.MenuName + "</span></a></li>";


                        }
                        str += "</ul></li>";
                    }
                }
                if (firstmenu != "") firstmenu = "";
            }
            if (str != "")
            {
                str = "<ul class=\"nav nav-list\">" + str + "</ul>";
            }
            litmenu.Text = str;
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void zlbquit_Click(object sender, EventArgs e)
        {
            // 清除Session
            Session["Account"] = null;

            Response.Redirect("~/Login.aspx");
        }

        
        //[WebMethod]
        //public static string GetMessage()
        //{
        //    string html = "";

        //    if (HttpContext.Current.Session["Account"] != null)
        //    {
        //        string userid = ((Account)HttpContext.Current.Session["Account"]).User.UserID;

        //        BSendLog bsl = new BSendLog();

        //        Query q = new Query();
        //        q.OrderBy("AddTime desc");
        //        q.Add("SendStatus", SendStatus.未推送.ToString());
        //        q.Add("SendType", SendType.站内.ToString());
        //        q.Add("UserID", userid);

        //        IList<SendLog> sllist = bsl.GetSendLogList(q);
                
        //        if (null != sllist && sllist.Count > 0)
        //        {
        //            sllist = sllist.Take(6).ToList();
        //            html = "<div class='tab-content'>";
        //            html += "<table style='min-height:275px;' class='table table-striped table-bordered table-hover table-condensed'>";
        //            html += "<tbody>";

        //            string slids = "'" + string.Join("','", sllist.Select(x => x.SendID).ToArray()) + "'";

        //            // 修改推送状态
        //            bsl.UpdateSendLogByIds(slids);


        //            foreach (SendLog sl in sllist)
        //            {
        //                html += "<tr>";
        //                html += "<td>";
        //                if (null != sl.WebUrl && sl.WebUrl != "")
        //                {
        //                    html += "<p><a href='" + sl.WebUrl + "' target='frmright'>" + sl.SendCoontent + "</a></p>";
        //                }
        //                else
        //                {
        //                    html += "<p>" + sl.SendCoontent + "</p>";
        //                }

        //                html += "</td>";
        //                html += "</tr>";
        //            }
        //            html += "</tbody>";
        //            html += "</table>";
        //            //html += "<a href='/Member/RssList.aspx'  target='frmright' class='btn btn-xs btn-success center' style='width:100%;'><b>查看更多 &gt;&gt;</b></a>";
        //            html += "</div>";

        //        }

        //    }

        //    string result = "[{\"html\":\"" + html + "\"}]";
            
        //    return result;
        //}

    }
}