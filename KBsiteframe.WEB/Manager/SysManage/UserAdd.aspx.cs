using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KBsiteframe.Model;
using SysBase.BLL;
using SysBase.Model;
using Z;
using System.Collections;
using KBsiteframe.WEB.Comm;


namespace KBsiteframe.Web.Manager.SysManage
{
    public partial class UserAdd : PageBase
    {
        public UserAdd()
        {
            ModuleCode = "UserManage";
            PageOperate = PurOperate.添加;

        }

        BUser bu = new BUser();
        BRole br = new BRole();
        BUserRole bur = new BUserRole();
        BSysOperateLog bsol = new BSysOperateLog();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRoleList();
            }
        }
        void BindRoleList()
        {
            lbunseleted.Items.Clear();
            foreach (SysRole sr in br.GetRoleList(Query.Build(new { SortFields = "RoleID" })))
            {
                lbunseleted.Items.Add(new ListItem(sr.RoleName, sr.RoleID.ToString()));
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
            SysUser su = new SysUser();
            su.UserID = System.Guid.NewGuid().ToString("N");//ID生成策略
            su.UserLoginName = txtUserLoginName.Text.Trim();
            su.UserName = txtUserName.Text.Trim();
            su.UserPassword = EncryptHelper.EncryptPassword(Constants.DefaultPassword, Constants.PassWordEncodeType);//默认密码
            su.Tel = txtTel.Text.Trim();
            su.Sex = rbsex.SelectedValue;
            su.RegDate = DateTime.Now;
            su.Phone = txtPhone.Text.Trim();
            su.IsMain = true;
            su.Email = txtMail.Text.Trim();
            su.IsUse = true;
            su.UserType = UserType.普通管理员.ToString();
            su.UserStatus = UserStatus.审核通过.ToString();
            
            if (bu.GetUserByUserLoginName(su.UserLoginName) != null)
            {
                Message.ShowWrong(this, "用户登录名已经存在");
                txtUserLoginName.Focus();
                return;
            }
            int rec = bu.Insert(su);
            if (rec == 1)
            {
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
                log.LogOperateType = "用户添加";
                log.LogAfterObject = JsonHelper.Obj2Json<SysUser>(su);

                bsol.Insert(log);

                Message.ShowOKAndRedirect(this, "添加成功，初始密码为：" + Constants.DefaultPassword, "UserManage.aspx");
            }
            else
            {
                Message.ShowWrong(this, "添加失败");
            }
        }
    }
}