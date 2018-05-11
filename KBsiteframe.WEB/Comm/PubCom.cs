using System;
using System.Collections;
using System.Data;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SysBase.BLL;
using SysBase.Model;

namespace KBsiteframe.WEB.Comm
{
    public class PubCom
    {
        /// <summary>
        ///     参数的集中处理
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string CheckString(string inputString)
        {
            //要替换的敏感字
            if (inputString.Trim() == "")
            {
                return "";
            }
            var SqlStr =
                @"<[^>]+?style=[\w]+?:expression\(|\b(alert|confirm|prompt)\b|^\+/v(8|9)|<[^>]*?=[^>]*?&#[^>]*?>|\b(and|or)\b.{1,6}?(=|>|<|\bin\b|\blike\b)|/\*.+?\*/|<\s*script\b|<\s*img\b|\bEXEC\b|UNION.+?SELECT|UPDATE.+?SET|INSERT\s+INTO.+?VALUES|(SELECT|DELETE).+?FROM|(CREATE|ALTER|DROP|TRUNCATE)\s+(TABLE|DATABASE)";
            try
            {
                if ((inputString != null) && (inputString != string.Empty))
                {
                    var str_Regex = @"\b(" + SqlStr + @")\b";

                    var Regex = new Regex(str_Regex, RegexOptions.IgnoreCase);
                    //string s = Regex.Match(inputString).Value; 
                    var matches = Regex.Matches(inputString);
                    for (var i = 0; i < matches.Count; i++)
                        inputString = inputString.Replace(matches[i].Value, "");
                }
            }
            catch
            {
                return "";
            }
            return inputString;
        }

        /// <summary>
        ///     获取repeater绑定的关键key
        /// </summary>
        /// <param name="RepeaterName"></param>
        /// <param name="CheckBoxName"></param>
        /// <returns></returns>
        public static string GetRepeaterKey(Repeater RepeaterName, string CheckBoxName)
        {
            var key = "";
            foreach (RepeaterItem ri in RepeaterName.Items)
            {
                var cb = ri.FindControl(CheckBoxName) as HtmlInputCheckBox;
                if (cb.Checked)
                    key = cb.Value;
            }
            return key;
        }

        /// <summary>
        ///     获取repeater绑定的关键key多选
        /// </summary>
        /// <param name="RepeaterName"></param>
        /// <param name="CheckBoxName"></param>
        /// <returns></returns>
        public static string[] GetRepeaterKeyList(Repeater RepeaterName, string CheckBoxName)
        {
            var key = new string[RepeaterName.Items.Count];
            for (var i = 0; i < RepeaterName.Items.Count; i++)
            {
                var cb = RepeaterName.Items[i].FindControl(CheckBoxName) as HtmlInputCheckBox;
                if (cb.Checked)
                {
                    key[i] = cb.Value;
                }
            }
            return key;
        }

        /// <summary>
        ///     设置repeater绑定的关键key状态
        /// </summary>
        /// <param name="RepeaterName"></param>
        /// <param name="CheckBoxName"></param>
        /// <param name="checked_value"></param>
        public static void SetRepeaterKey(Repeater RepeaterName, string CheckBoxName, string checked_value)
        {
            foreach (RepeaterItem ri in RepeaterName.Items)
            {
                var cb = ri.FindControl(CheckBoxName) as HtmlInputCheckBox;
                if (cb.Value == checked_value)
                    cb.Checked = true;
            }
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
            return CheckString(HttpContext.Current.Request.QueryString[name].Trim());
        }

        #region"通用登陆"

        /// <summary>
        ///     1-成功；2-密码错误；-1-用户不存在;3-未审核；4审核不通过
        /// </summary>
        /// <param name="UserLogiName"></param>
        /// <param name="userpassowrd"></param>
        /// <param name="isrember"></param>
        /// <returns></returns>
        public static bool login(SysUser su, string userloginname, string userpassowrd)
        {
            if (su != null)
            {
                var bu = new BUser();
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


                //默认Cookie，自动登陆使用
                //if (isrember)
                //{
                //    HttpCookie cookie = new HttpCookie("Zcqxxx");
                //    cookie.Values.Add("Name", userloginname);
                //    cookie.Values.Add("Pwd", userpassowrd);
                //    cookie.Expires = System.DateTime.Now.AddDays(7.0);
                //    HttpContext.Current.Response.Cookies.Add(cookie);
                //}
                //记录IP及时间
                bu.Update(new SysUser {UserID = su.UserID, LastTime = DateTime.Now, LastIP = ip,LoginTimes = (su.LoginTimes ?? 0)+1});
                //创建Account
                var ac = new Account();
                ac.User = su;
                //获取权限列表
                ac.OperateList = bu.GetOperateByUserID(su.UserID);
                //获取用户角色
                var bur = new BUserRole();

                DataTable dt = bur.GetUserRoleByUserID(su.UserID);
                ac.UserRoleNames = new ArrayList();
                ac.UserRoleIds = new ArrayList();

                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    ac.UserRoleNames.Add(dt.Rows[i]["RoleName"].ToString());
                    ac.UserRoleIds.Add(dt.Rows[i]["RoleID"].ToString());
                }
                ////获取用户区域
                //if (ac.User.LimitAreas == null) ac.User.LimitAreas = "";
                //if (ac.User.IsMain == false)
                //{
                //    if (ac.User.LimitAreas == "")
                //    {
                //        //获取主用户的限制区域
                //        Query qm = new Query();
                //        qm.Add("OrgID", ac.User.OrgID);
                //        qm.Add("IsMain", true);
                //        SysUser MainSu = bu.GetUserByQuery(qm);
                //        if (MainSu != null)
                //        {
                //            if (MainSu.LimitAreas == null) MainSu.LimitAreas = "";
                //            if (MainSu.LimitAreas.ToString() != "")
                //            {
                //                ac.User.LimitAreas = MainSu.LimitAreas;
                //            }
                //        }
                //    }
                //}
                //if (ac.User.LimitAreas != "") ac.User.LimitAreas += "|98";
                //if (ac.User.IsPayUser != true) ac.User.LimitAreas = "";
                ////获取用户所属机构信息
                //if (su.OrgID != null && su.OrgID != 0)
                //{
                //    BCompany bc = new BCompany();
                //    ac.CompanyInfo = bc.GetCompanyByCompanyID((int)su.OrgID);
                //}
                HttpContext.Current.Session["Account"] = ac;

                return true;
            }
            return false;
        }

        #endregion
    }
}