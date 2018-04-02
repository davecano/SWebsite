using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SysBase.BLL;
using SysBase.Model;
using KBsiteframe.Model;
using Z;
using System.Collections;
using MyCmsWEB;

namespace KBsiteframe.Web.Manager.SysManage
{
    public partial class UserUpdate : PageBase
    {
        public UserUpdate()
        {
            ModuleCode = "UserManage";
            PageOperate = PurOperate.修改;
        }

        string UserID = "";
        BUser bu = new BUser();
        BRole br = new BRole();
        BUserRole bur = new BUserRole();

        BSysOperateLog bsol = new BSysOperateLog();

        protected void Page_Load(object sender, EventArgs e)
        {
            Q("ID", out UserID);
            if (UserID == "")
            {
                Message.ShowWrongAndBack(this, "参数错误");
            }
            if (!IsPostBack)
            {
                BindDetail();
            }
        }

        void BindRoleList()
        {
            lbseleted.Items.Clear();
            lbunseleted.Items.Clear();
            foreach (SysRole sr in bur.GetRoleByUserID(UserID))
            {
                lbseleted.Items.Add(new ListItem(sr.RoleName, sr.RoleID.ToString()));
            }
            foreach (SysRole sr in br.GetSysRoleOutByUserID(UserID))
            {
                lbunseleted.Items.Add(new ListItem(sr.RoleName, sr.RoleID.ToString()));
            }

        }


        void BindDetail()
        {
            SysUser su = bu.GetUserByUserID(UserID);
            if (su != null)
            {
                if (su.UserLoginName == Constants.AdminName)
                {
                    Message.ShowWrongAndClose(this, "超级管理员不能修改");
                    return;
                }
                else
                {
                    hfID.Value = su.UserID;
                    txtUserName.Text = su.UserName;
                    txtUserLoginName.Text = su.UserLoginName;
                    txtTel.Text = su.Tel;
                    txtPhone.Text = su.Phone;
                    txtMail.Text = su.Email;
                    rbsex.SelectedIndex = rbsex.Items.IndexOf(rbsex.Items.FindByValue(su.Sex));
                    BindRoleList();
                }

            }
            else
            {
                Message.ShowWrongAndBack(this, "不存在此用户");
            }

        }

        protected void ZButton1_Click(object sender, EventArgs e)
        {
            ArrayList al = new ArrayList();
            foreach (ListItem li in lbunseleted.Items)
            {
                if (li.Selected)
                {
                    lbseleted.Items.Add(new ListItem(li.Text, li.Value));

                    al.Add(li);

                }
            }
            for (int i = 0; i < al.Count; i++)
            {
                lbunseleted.Items.Remove((ListItem)al[i]);
            }
        }

        protected void ZButton2_Click(object sender, EventArgs e)
        {
            ArrayList al = new ArrayList();
            foreach (ListItem li in lbseleted.Items)
            {
                if (li.Selected)
                {
                    lbunseleted.Items.Add(new ListItem(li.Text, li.Value));
                    al.Add(li);

                }
            }
            for (int i = 0; i < al.Count; i++)
            {
                lbseleted.Items.Remove((ListItem)al[i]);
            }

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            SysUser oldsu = bu.GetUserByUserID(hfID.Value);

            SysUser su = new SysUser();
            su.UserID = hfID.Value;
            su.UserLoginName = txtUserLoginName.Text.Trim();
            su.UserName = txtUserName.Text.Trim();
            su.Phone = txtPhone.Text.Trim();
            su.Tel = txtTel.Text.Trim();
            su.Sex = rbsex.SelectedValue;
            su.Email = txtMail.Text.Trim();
            su.IsUse = true;

            if (bu.GetUserByUserLoginName(su.UserLoginName) != null && su.UserLoginName != oldsu.UserLoginName) 
            {
                Message.ShowWrong(this, "用户登录名已经存在");
                txtUserLoginName.Focus();
                return;
            }
            int rec = bu.Update(su);
            if (rec == 1)
            {
                bur.DeleteByUserID(UserID);
                foreach (ListItem li in lbseleted.Items)
                {
                    bur.Insert(new SysUserRole() { RoleID = int.Parse(li.Value.Trim()), UserID = su.UserID });
                }


                // 插入日志
                SysOperateLog log = new SysOperateLog();
                log.LogID = StringHelper.getKey();
                log.LogType = LogType.帐户信息.ToString();
                log.LogObjectID = su.UserID;
                log.LogObjectName = "[" + su.UserLoginName + "]" + su.UserName;
                log.OperateUser = GetLogUserName();
                log.OperateDate = DateTime.Now;
                log.LogOperateType = "用户修改";
                log.LogBeforeObject = JsonHelper.Obj2Json<SysUser>(oldsu);
                log.LogAfterObject = JsonHelper.Obj2Json<SysUser>(su);

                bsol.Insert(log);

                Message.ShowOKAndRedirect(this, "修改成功", "UserManage.aspx");
            }
            else
            {
                Message.ShowWrong(this, "修改失败");
            }
        }
    }
}