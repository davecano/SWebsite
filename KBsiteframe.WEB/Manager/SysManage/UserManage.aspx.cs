using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KBsiteframe.Model;
using SysBase.BLL;
using SysBase.Model;

using MyCmsWEB;
using Z;

namespace KBsiteframe.Web.Manager.SysManage
{
    public partial class UserManage : PageBase
    {
        public UserManage()
        {
            ModuleCode = "UserManage";
            PageOperate = PurOperate.查询;
        }

        BUser bu = new BUser();
        BRole br = new BRole();
        BSysOperateLog bsol = new BSysOperateLog();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRole();
                BindList();
            }
        }

        void BindRole()
        {
            IList<SysRole> lso = br.GetRoleList(Query.Build(new { SortFields = "RoleID" }));
            dpUserRole.Items.Clear();
            dpUserRole.Items.Add(new ListItem("全部", "全部"));
            foreach (SysRole sr in lso)
            {
                dpUserRole.Items.Add(new ListItem(sr.RoleName, sr.RoleID.ToString()));
            }
        }

        void BindList()
        {
            Query q = Query.Build(new { SortFields = "Regdate desc" });
            q.Add("UserStatus", UserStatus.审核通过.ToString());
            string username = PubCom.CheckString(txtUserName.Text.Trim());
            if (username != "")
            {
                q.Add("UserName", username);
            }
            string userloginname = PubCom.CheckString(txtUserLoginName.Text.Trim());
            if (userloginname != "")
            {
                q.Add("UserLoginName", userloginname);
            }
            string orgname = PubCom.CheckString(txtOrgName.Text.Trim());
            if (orgname != "")
            {
                q.Add("OrgName", orgname);
            }
            if (dpUserRole.SelectedValue != "全部")
            {
                q.Append("UserID in(select UserID from SysUserRole where RoleID='" + dpUserRole.SelectedValue + "')");
            }
            if (dpUserStatus.SelectedValue != "全部")
            {
                if (dpUserStatus.SelectedValue == "启用")
                    q.Add("IsUse", true);
                else
                    q.Add("IsUse", false);
            }

            int rec = 0;
            rplist.DataSource = bu.GetUserList(q, AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize, out rec);
            rplist.DataBind();
            AspNetPager1.RecordCount = rec;

            //// 插入日志
            //SysOperateLog log = new SysOperateLog();
            //log.LogID = StringHelper.getKey();
            //log.LogType = LogType.帐户信息.ToString();
            //log.OperateUser = GetLogUserName();
            //log.OperateDate = DateTime.Now;
            //log.LogOperateType = "用户查询";
            //log.LogAfterObject = JsonHelper.Obj2Json<string>(q.GetCondition(true));
            //bsol.Insert(log);
        }
        
        protected void zbquery_Click(object sender, EventArgs e)
        {
            AspNetPager1.CurrentPageIndex = 1;
            BindList();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindList();
        }

        protected void ZButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserAdd.aspx");
        }

        protected void ZButton3_Click(object sender, EventArgs e)
        {
            string key = PubCom.GetRepeaterKey(rplist, "cbselect");
            Response.Redirect("UserUpdate.aspx?ID=" + EncryptHelper.Encode(key));
        }

        protected void ZButton4_Click(object sender, EventArgs e)
        {
            string key = PubCom.GetRepeaterKey(rplist, "cbselect");
            SysUser su = bu.GetUserByUserID(key);
            if (su != null && su.UserLoginName == Constants.AdminName)
            {
                Message.ShowWrong(this, "超级管理员不能删除");
            }
            else
            {
                  
                if (bu.Delete(key) == 1)
                {
                    // 插入日志
                    SysOperateLog log = new SysOperateLog();
                    log.LogID = StringHelper.getKey();
                    log.LogType = LogType.帐户信息.ToString();
                    log.LogObjectID = su.UserID;
                    log.LogObjectName = "[" + su.UserLoginName + "]" + su.UserName;
                    log.OperateUser = GetLogUserName();
                    log.OperateDate = DateTime.Now;
                    log.LogOperateType = "用户删除";
                    log.LogBeforeObject = JsonHelper.Obj2Json<SysUser>(su);

                    bsol.Insert(log);


                    Message.ShowOKAndReflashOfDelete(this, "删除成功", "zbquery");
                }
                else
                {
                    Message.ShowWrong(this, "删除失败");
                }
            }
        }

        protected void ZButton5_Click(object sender, EventArgs e)
        {
            string key = PubCom.GetRepeaterKey(rplist, "cbselect");
            SysUser su = bu.GetUserByUserID(key);
            string newpsw = EncryptHelper.EncryptPassword(Constants.DefaultPassword, Constants.PassWordEncodeType);//默认密码
            if (bu.Update(new SysUser() { UserID = key, UserPassword = newpsw }) == 1) 
            {
                // 插入日志
                SysOperateLog log = new SysOperateLog();
                log.LogID = StringHelper.getKey();
                log.LogType = LogType.帐户信息.ToString();
                log.LogObjectID = su.UserID;
                log.LogObjectName = "[" + su.UserLoginName + "]" + su.UserName;
                log.OperateUser = GetLogUserName();
                log.OperateDate = DateTime.Now;
                log.LogOperateType = "密码重置";
                log.LogBeforeObject = JsonHelper.Obj2Json<string>("[原密码：]"+su.UserPassword);
                log.LogAfterObject = JsonHelper.Obj2Json<string>("[新密码：]" + newpsw);
               var a= bsol.Insert(log);
                Message.ShowOKAndReflash(this, "重置成功，重置密码为：" + Constants.DefaultPassword, "zbquery");
            }
            else
            {
                Message.ShowWrong(this, "重置失败");
            }
        }

        protected void ZButton6_Click(object sender, EventArgs e)
        {
            string key = PubCom.GetRepeaterKey(rplist, "cbselect");

            int ret = 0;
            string use = "";
            string nouse = "";

            if (key == "")
                Message.Show(this.Page, "请先选择一个用户");
            else
            {
                SysUser su = bu.GetUserByUserID(key);
                if (su != null)
                {
                    
                    ret = bu.Update(new SysUser() { UserID = su.UserID, IsUse = !su.IsUse });

                }

                if ((bool)su.IsUse == true)
                {
                    use = "禁用";
                    nouse = "启用";
                }
                else
                {
                    use = "启用";
                    nouse = "禁用";
                }

                if (ret == 1)
                {
                    SysOperateLog log = new SysOperateLog();
                    log.LogID = StringHelper.getKey();
                    log.LogType = LogType.帐户信息.ToString();
                    log.LogObjectID = su.UserID;
                    log.LogObjectName = "[" + su.UserLoginName + "]" + su.UserName;
                    log.OperateUser = GetLogUserName();
                    log.OperateDate = DateTime.Now;
                    log.LogOperateType = "启用禁用";
                    log.LogBeforeObject = JsonHelper.Obj2Json<string>("[原状态：]" + su.IsUse);
                    log.LogAfterObject = JsonHelper.Obj2Json<string>("[新密码：]" + !su.IsUse);
                    log.LogRemark = "1代表启用，0代表禁用";
                    bsol.Insert(log);
                    Message.ShowOKAndReflash(this, use + "成功", "zbquery");
                }
                else
                {
                    Message.ShowWrong(this, nouse + "失败");
                }

            }
        }

        protected void ZButton7_Click(object sender, EventArgs e)
        {
            string key = PubCom.GetRepeaterKey(rplist, "cbselect");

            Response.Redirect("UserOperateEdit.aspx?ID=" + EncryptHelper.Encode(key));
        }

        public string BindIsUse(object isuse)
        {
            if ((bool)isuse == true)
                return "<font color=blue>启用</font>";
            else
                return "<font color=red>禁用</font>";

        }
    }
}