using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KBsiteframe.Model;
using KBsiteframe.WEB.Comm;
using SysBase.BLL;
using SysBase.Model;
using Z;

namespace KBsiteframe.Web.Manager.SysManage
{
    public partial class MenuManage : PageBase
    {
        public MenuManage()
        {
            ModuleCode = "MenuManage";
            PageOperate = PurOperate.查询;
        }

        BMenu bm = new BMenu();
        BSysOperateLog bsol = new BSysOperateLog();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMenu();
            }
        }

        List<SysMenu> lsm;

        void BindMenu()
        {
            var qm = Query.Build(new {SortFields = "ParentMenuID,MenuSort"});
            lsm = new List<SysMenu>();
            GetDG(bm.GetMenuList(qm), 0);

            rpmenu.DataSource = lsm;
            rpmenu.DataBind();
        }

        #region"递归操作"

        public void GetDG(IList<SysMenu> ls, int parentid)
        {
            foreach (SysMenu sm in ls)
            {
                if (sm.ParentMenuID == parentid)
                {
                    lsm.Add(sm);
                    GetDG(ls, sm.MenuID);
                }
            }
        }

        #endregion


        protected void ZButton1_Click(object sender, EventArgs e)
        {
            SysMenu sm = new SysMenu();
            sm.MenuID = bm.GetMaxID() + 1;
            sm.MenuName = PubCom.CheckString(txtMenuName.Text.Trim());
            sm.MenuSort = int.Parse(PubCom.CheckString(txtMenuSort.Text.Trim()));
            sm.ParentMenuID = int.Parse(PubCom.CheckString(txtParentMenuID.Text.Trim()));
            sm.MenuType = "";
            sm.ModuleCode = PubCom.CheckString(txtModuleCode.Text.Trim());
            sm.PageUrl = txtPageUrl.Text.Trim();
            sm.IsLeaf = cbIsLeaf.Checked;
            sm.IsVisiable = cbIsVisiable.Checked;

            if (bm.Insert(sm) != 1)
            {
                Message.ShowWrong(this, "添加失败");
                return;

            }
            else
            {
                // 插入日志
                SysOperateLog log = new SysOperateLog();
                log.LogID = StringHelper.getKey();
                log.LogType = LogType.菜单信息.ToString();
                log.LogObjectID = sm.MenuID.ToString();
                log.LogObjectName = sm.MenuName;
                log.OperateUser = GetLogUserName();
                log.OperateDate = DateTime.Now;
                log.LogOperateType = "菜单添加";
                log.LogAfterObject = JsonHelper.Obj2Json<SysMenu>(sm);

                bsol.Insert(log);

                Message.ShowOK(this, "添加成功");
                BindMenu();
            }
        }

        protected void ZButton2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < rpmenu.Items.Count; i++)
            {
                SysMenu sm = new SysMenu();

                sm.MenuID = int.Parse((rpmenu.Items[i].FindControl("zlsc") as ZLinkButton).CommandArgument);
                sm.MenuName = PubCom.CheckString((rpmenu.Items[i].FindControl("tMenuName") as TextBox).Text.Trim());
                sm.ModuleCode = PubCom.CheckString((rpmenu.Items[i].FindControl("tModuleCode") as TextBox).Text.Trim());
                sm.PageUrl = (rpmenu.Items[i].FindControl("tPageUrl") as TextBox).Text.Trim();
                sm.IsLeaf = (rpmenu.Items[i].FindControl("cIsLeaf") as CheckBox).Checked;
                sm.IsVisiable = (rpmenu.Items[i].FindControl("cIsVisiable") as CheckBox).Checked;
                sm.ParentMenuID = int.Parse((rpmenu.Items[i].FindControl("tParentMenuID") as TextBox).Text.Trim());
                sm.MenuSort = int.Parse((rpmenu.Items[i].FindControl("tMenuSort") as TextBox).Text.Trim());
                sm.MenuIco = (rpmenu.Items[i].FindControl("tMenuIco") as TextBox).Text.Trim();
                var oldmenu = JsonHelper.Obj2Json(sm);
                bm.Update(sm);
                var newmenu = JsonHelper.Obj2Json(bm.GetSysMenuByID(sm.MenuID));
                if (oldmenu == newmenu)
                {
                    SysOperateLog log = new SysOperateLog();
                    log.LogID = StringHelper.getKey();
                    log.LogType = LogType.菜单信息.ToString();
                    log.LogObjectID = sm.MenuID.ToString();
                    log.LogObjectName = sm.MenuName;
                    log.OperateUser = GetLogUserName();
                    log.OperateDate = DateTime.Now;
                    log.LogOperateType = "菜单修改";
                    log.LogBeforeObject = oldmenu;
                    log.LogAfterObject = newmenu;

                    bsol.Insert(log);
                }
            }


            BindMenu();
            Message.ShowOK(this, "修改完成");
        }

        protected void rpmenu_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int mid = int.Parse(e.CommandArgument.ToString());
            if (e.CommandName == "sc")
            {
                Query qm = Query.Build(new {IsVisiable = 1, SortFields = "ParentMenuID,MenuSort"});

                qm.Append("ParentMenuID=" + mid);
                if (bm.GetMenuList(qm).Count != 0)
                {
                    Message.ShowWrong(this.Page, "请先删除子项");
                    return;
                }
                if (bm.Delete(new SysMenu() {MenuID = mid}) != 1)
                {

                    Message.ShowWrong(this, "删除失败");
                    return;

                }
                else
                {
                    try
                    {
                 SysOperateLog log = new SysOperateLog();
                    log.LogID = StringHelper.getKey();
                    log.LogType = LogType.菜单信息.ToString();
                    log.LogObjectID = mid.ToString();
                    log.LogObjectName = bm.GetSysMenuByID(mid).MenuName;
                    log.OperateUser = GetLogUserName();
                    log.OperateDate = DateTime.Now;
                    log.LogOperateType = "菜单删除";
                    log.LogBeforeObject = JsonHelper.Obj2Json(bm.GetSysMenuByID(mid));

                    bsol.Insert(log);
                    Message.ShowOK(this.Page, "删除成功");
                    }
                    catch (Exception ex)
                    {
                        Message.ShowWrong(this,"日志错误:"+ex);
                   
                    }
               
                    BindMenu();
                }

            }
            if (e.CommandName == "setoperate")
            {
                Response.Redirect("OperateManage.aspx?ID=" + EncryptHelper.Encode(mid.ToString()));
            }
        }
    }
}