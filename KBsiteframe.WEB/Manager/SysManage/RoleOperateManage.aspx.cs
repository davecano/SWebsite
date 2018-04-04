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
    public partial class RoleOperateManage : PageBase
    {
        public RoleOperateManage()
        {
            ModuleCode = "RoleManage";
            PageOperate = PurOperate.分配权限;
        }

        int roleid = 0;
        BMenu bm = new BMenu();
        BOperate bo = new BOperate();
        BRoleOperate bro = new BRoleOperate();
        BRole br = new BRole();
        BSysOperateLog bsol=new BSysOperateLog();
        protected void Page_Load(object sender, EventArgs e)
        {
            string temproleid = "";
            Q("ID", out temproleid);
            roleid = int.Parse(temproleid);
            if (!IsPostBack)
            {
                BindRoleOperate();
            }
        }

        IList<SysOperate> lso_menu; //菜单的所有操作
        IList<SysOperate> lso_role;//角色拥有的操作
        void BindRoleOperate()
        {
            SysRole sr = new SysRole();
            sr = br.GetRoleByID(roleid);
            if (sr == null)
            {
                Message.ShowAndBack("无此数据");
                return;
            }
            else
            {
                litRoleName.Text = sr.RoleName;
                litIsUse.Text = sr.IsUse == true ? "是" : "否";
            }
            lso_menu = bo.GetMenuOperate();
            lso_role = bro.GetOperateByRoleID(roleid);
            Query qm = Query.Build(new { SortFields = "ParentMenuID,MenuSort" });

            qm.Append("IsLeaf = 1");
            var lsm = bm.GetMenuList(qm);
            rproleoperate.DataSource = lsm;
            rproleoperate.DataBind();

        }

        protected void ZButton1_Click(object sender, EventArgs e)
        {
            bro.DeleteByRoleID(roleid);
            for (int i = 0; i < rproleoperate.Items.Count; i++)
            {
                CheckBoxList cbl = rproleoperate.Items[i].FindControl("cboperate") as CheckBoxList;
                foreach (ListItem li in cbl.Items)
                {
                    if (li.Selected)
                    {
                        SysRoleOperate sro = new SysRoleOperate();
                        sro.OperateID = int.Parse(li.Value);
                        sro.RoleID = roleid;
                        bro.Insert(sro);
                        // 插入日志
                        SysOperateLog log = new SysOperateLog();
                        log.LogID = StringHelper.getKey();
                        log.LogType = LogType.角色信息.ToString();
                        log.LogObjectID = sro.RoleID.ToString();
                        log.LogObjectName =br.GetRoleByID(sro.RoleID).RoleName ;
                        log.OperateUser = GetLogUserName();
                        log.OperateDate = DateTime.Now;
                        log.LogOperateType = "角色设置操作添加";
                       log.LogAfterObject=JsonHelper.Obj2Json(sro);

                        bsol.Insert(log);

                    }
                }
            }
            BUser bu = new BUser();
            bu.ReSetUserRoleOperate(roleid);//没有方法
            Message.ShowOKAndRedirect(this, "修改成功", "RoleManage.aspx");
        }

        protected void rproleoperate_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                CheckBoxList cbl = e.Item.FindControl("cboperate") as CheckBoxList;
                SysMenu sm = (SysMenu)e.Item.DataItem;//找到分类Repeater关联的数据项 
                int menuid = sm.MenuID;
                cbl.Items.Clear();
                BindCb(cbl, lso_menu.Where<SysOperate>(p => p.MenuID == menuid).ToList<SysOperate>(), lso_role.Where<SysOperate>(p => p.MenuID == menuid).ToList<SysOperate>());
            }
        }

        void BindCb(CheckBoxList cbl, IList<SysOperate> lsom, IList<SysOperate> lsor)
        {
            foreach (SysOperate som in lsom)
            {
                ListItem li = new ListItem();
                li.Text = som.OperateName;
                li.Value = som.OperateID.ToString();
                if (lsor.Where<SysOperate>(p => p.OperateName == som.OperateName).ToList<SysOperate>().Count > 0)
                {
                    li.Selected = true;
                }
                else
                {
                    li.Selected = false;
                }
                cbl.Items.Add(li);
            }
        }
    }
}