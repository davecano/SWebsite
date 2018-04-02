using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KBsiteframe.Model;
using MyCmsWEB;
using SysBase.BLL;
using SysBase.Model;
using Z;

namespace KBsiteframe.Web.Manager.SysManage
{
    public partial class RoleManage : PageBase
    {
        public RoleManage()
        {
            ModuleCode = "RoleManage";
            PageOperate = PurOperate.查询;
        }

        BRole br = new BRole();
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
            var qm = Query.Build(new { SortFields = "RoleID desc" });

            rprole.DataSource = br.GetRoleList(qm);
            rprole.DataBind();

        }

        protected void ZButton1_Click(object sender, EventArgs e)
        {
            SysRole sr = new SysRole();
            sr.RoleID = br.GetMaxID() + 1;
            sr.RoleName = PubCom.CheckString(txtRoleName.Text.Trim());
            sr.IsUse = cbIsUse.Checked;

            if (br.Insert(sr) != 1)
            {
                Message.ShowWrong(this, "添加失败");
                return;

            }
            else
            {
                // 插入日志
                SysOperateLog log = new SysOperateLog();
                log.LogID = StringHelper.getKey();
                log.LogType = LogType.角色信息.ToString();
                log.LogObjectID = sr.RoleID.ToString();
                log.LogObjectName = sr.RoleName;
                log.OperateUser = GetLogUserName();
                log.OperateDate = DateTime.Now;
                log.LogOperateType = "角色添加";
                log.LogAfterObject = JsonHelper.Obj2Json<SysRole>(sr);

                bsol.Insert(log);

                Message.ShowOK(this, "添加成功");
                BindRoleList();
            }
        }

        protected void ZButton2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < rprole.Items.Count; i++)
            {
                SysRole sr = new SysRole();

                sr.RoleID = int.Parse((rprole.Items[i].FindControl("zlsc") as ZLinkButton).CommandArgument);
                sr.RoleName = PubCom.CheckString((rprole.Items[i].FindControl("tRoleName") as TextBox).Text.Trim());
                sr.IsUse = (rprole.Items[i].FindControl("cIsUse") as CheckBox).Checked;
                var oldrole = JsonHelper.Obj2Json(br.GetRoleByID(sr.RoleID));
                br.Update(sr);
                if (oldrole == JsonHelper.Obj2Json(sr))
                {
                    // 插入日志
                    SysOperateLog log = new SysOperateLog();
                    log.LogID = StringHelper.getKey();
                    log.LogType = LogType.角色信息.ToString();
                    log.OperateUser = GetLogUserName();
                    log.OperateDate = DateTime.Now;
                    log.LogOperateType = "角色修改";
                    log.LogBeforeObject = oldrole;
                    log.LogAfterObject = JsonHelper.Obj2Json(sr);
                    bsol.Insert(log);
                }
            }
            BindRoleList();

            

            Message.ShowOK(this, "修改完成");
        }

        protected void rprole_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int rid = int.Parse(e.CommandArgument.ToString());

            if (e.CommandName == "sc")
            {
                if (br.Delete(new SysRole() { RoleID = rid }) != 1)
                {

                    Message.ShowWrong(this, "删除失败");
                    return;

                }
                else
                {
                    SysRole sr = br.GetRoleByID(rid);

                    // 插入日志
                    SysOperateLog log = new SysOperateLog();
                    log.LogID = StringHelper.getKey();
                    log.LogType = LogType.角色信息.ToString();
                    log.LogObjectID = sr.RoleID.ToString();
                    log.LogObjectName = sr.RoleName;
                    log.OperateUser = GetLogUserName();
                    log.OperateDate = DateTime.Now;
                    log.LogOperateType = "角色删除";
                    log.LogBeforeObject = JsonHelper.Obj2Json<SysRole>(sr);

                    bsol.Insert(log);

                    Message.ShowOK(this.Page, "删除成功");
                    BindRoleList();
                }

            }
            if (e.CommandName == "setoperate")
            {
                Response.Redirect("RoleOperateManage.aspx?ID=" + EncryptHelper.Encode(rid.ToString()));
            }
        }
    }
}