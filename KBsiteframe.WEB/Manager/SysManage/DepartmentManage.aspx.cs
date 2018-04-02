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
    public partial class DepartmentManage : PageBase
    {
        public DepartmentManage()
        {
            ModuleCode = "DepartmentManage";
            PageOperate = PurOperate.查询;
        }

        BDepartment bd = new BDepartment();
        BSysOperateLog bsol=new BSysOperateLog();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindList();
            }
        }

        void BindList()
        {
            var qm = Query.Build(new { SortFields = "DepartmentID desc" });

            rplist.DataSource = bd.GetDepartmentList(qm);
            rplist.DataBind();
        }

        protected void ZButton1_Click(object sender, EventArgs e)
        {
            SysDepartment sd = new SysDepartment();
            sd.DepartmentID = bd.GetMaxID() + 1;
            sd.DepartmentName = PubCom.CheckString(txtDepartmentName.Text.Trim());
            sd.IsUse = cbIsUse.Checked;

            if (bd.Insert(sd) != 1)
            {
                Message.ShowWrong(this, "添加失败");
                return;

            }
            else
            {
                // 插入日志
                SysOperateLog log = new SysOperateLog();
                log.LogID = StringHelper.getKey();
                log.LogType = LogType.部门信息.ToString();
                log.LogObjectID = sd.DepartmentID.ToString();
                log.LogObjectName = sd.DepartmentName;
                log.OperateUser = GetLogUserName();
                log.OperateDate = DateTime.Now;
                log.LogOperateType = "部门添加";
                log.LogAfterObject = JsonHelper.Obj2Json(sd);

                bsol.Insert(log);
                Message.ShowOK(this, "添加成功");
                BindList();
            }
        }

        protected void ZButton2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < rplist.Items.Count; i++)
            {
                SysDepartment sd = new SysDepartment();

                sd.DepartmentID = int.Parse((rplist.Items[i].FindControl("zlsc") as ZLinkButton).CommandArgument);
                sd.DepartmentName = PubCom.CheckString((rplist.Items[i].FindControl("tDepartmentName") as TextBox).Text.Trim());
                sd.IsUse  = (rplist.Items[i].FindControl("cIsUse") as CheckBox).Checked;

              
                var olddepartment = JsonHelper.Obj2Json(bd.GetDepartmentByID(sd.DepartmentID));
                bd.Update(sd);
                if (olddepartment == JsonHelper.Obj2Json(sd))
                {
                    // 插入日志
                    SysOperateLog log = new SysOperateLog();
                    log.LogID = StringHelper.getKey();
                    log.LogType = LogType.部门信息.ToString();
                    log.OperateUser = GetLogUserName();
                    log.OperateDate = DateTime.Now;
                    log.LogOperateType = "部门修改";
                    log.LogBeforeObject = olddepartment;
                    log.LogAfterObject = JsonHelper.Obj2Json(sd);
                    bsol.Insert(log);
                }
            }
            BindList();
            Message.ShowOK(this, "修改完成");
        }


        protected void rplist_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int did = int.Parse(e.CommandArgument.ToString());

            if (e.CommandName == "sc")
            {
                if (bd.Delete(new SysDepartment() { DepartmentID = did }) != 1)
                {

                    Message.ShowWrong(this, "删除失败");
                    return;

                }
                else
                {
                    // 插入日志
                    SysOperateLog log = new SysOperateLog();
                    log.LogID = StringHelper.getKey();
                    log.LogType = LogType.部门信息.ToString();
                    log.OperateUser = GetLogUserName();
                    log.OperateDate = DateTime.Now;
                    log.LogOperateType = "部门删除";
                    log.LogBeforeObject =JsonHelper.Obj2Json(bd.GetDepartmentByID(did)) ;
                   
                    bsol.Insert(log);
                    Message.ShowOK(this.Page, "删除成功");
                    BindList();
                }

            }
        }
    }
}