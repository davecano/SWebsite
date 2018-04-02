using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SysBase.BLL;
using SysBase.Model;
using Z;
using System.Data;
using MyCmsWEB;

namespace KBsiteframe.Web.Manager.SysManage
{
    public partial class UserOperateEdit : PageBase
    {
        public UserOperateEdit()
        {
            ModuleCode = "UserManage";
            PageOperate = PurOperate.分配权限;
        }

        BUser bu = new BUser();
        BUserRole bur = new BUserRole();
        BOperate bo = new BOperate();
        BMenu bm = new BMenu();

        string uid = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            Q("ID", out uid);
            if (!IsPostBack)
            {
                BindUserOperate();
            }
        }

        IList<SysOperate> lso;//所有操作列表
        SysUser su;
        IList<UserOperate> luo;//获取用户的操作权限
        List<SysMenu> lsm;

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

        void BindUserOperate()
        {
            su = bu.GetUserByUserID(uid);
            if (su != null)
            {
                litUserName.Text = "[" + su.UserLoginName + "]" + su.UserName;
                DataTable dtrolelist = bur.GetUserRoleByUserID(uid);
                for (int i = 0; i < dtrolelist.Rows.Count; i++)
                {
                    litRoleNames.Text += "," + dtrolelist.Rows[i]["RoleName"].ToString();
                }
                //获取所有操作
                lso = bo.GetOperateList(Query.Build(new { SortFields = "OperateID" }));
                //获取用户操作
                luo = bu.GetOperateByUserID(su.UserID);
                //获取菜单模块绑定

                var qm = Query.Build(new { SortFields = "ParentMenuID,MenuSort" });
                lsm = new List<SysMenu>();
                GetDG(bm.GetMenuList(qm), 0);

                rplist.DataSource = lsm;
                rplist.DataBind();


            }
            else
            {
                Message.Show(this.Page, "不存在此用户", "Usermanage.aspx");
            }


        }


        protected void rplist_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                CheckBoxList cbl = e.Item.FindControl("cbOperates") as CheckBoxList;
                SysMenu sm = (SysMenu)e.Item.DataItem;//找到分类Repeater关联的数据项 
                int MenuID = (int)sm.MenuID;
                cbl.Items.Clear();
                IList<SysOperate> lso_m = lso.Where<SysOperate>(p => p.MenuID == MenuID).ToList<SysOperate>();
                foreach (SysOperate so in lso_m)
                {
                    ListItem li = new ListItem();
                    li.Text = so.OperateName;
                    li.Value = so.OperateID.ToString();
                    if (luo.Where<UserOperate>(p => p.OperateID == so.OperateID).ToList().Count > 0)
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

        protected void ZButton1_Click(object sender, EventArgs e)
        {
            //首先清除特殊操作
            bu.DeleteOperateByUserID(uid);
            //获取用户角色的所有权限 
            IList<UserOperate> myluo = bu.GetUserRoleOperateByUserID(uid);
            //循环比对
            for (int i = 0; i < rplist.Items.Count; i++)
            {
                CheckBoxList cbl = rplist.Items[i].FindControl("cbOperates") as CheckBoxList;
                foreach (ListItem li in cbl.Items)
                {
                    if (li.Selected)
                    {
                        if (myluo.Where<UserOperate>(p => p.OperateID == int.Parse(li.Value)).ToList().Count == 0)
                        {
                            bu.InsertUserOperate(new SysUserOperate() { OperateID = int.Parse(li.Value), UserID = uid, SpecialType = true });
                        }
                    }
                    else
                    {
                        if (myluo.Where<UserOperate>(p => p.OperateID == int.Parse(li.Value)).ToList().Count > 0)
                        {
                            bu.InsertUserOperate(new SysUserOperate() { OperateID = int.Parse(li.Value), UserID = uid, SpecialType = false });
                        }
                    }
                }
            }
            SysUser su = bu.GetUserByUserID(uid);
            

            Message.Show(this.Page, "分配成功", "UserManage.aspx");
        }
    }
}