using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KBsiteframe.Bll;
using KBsiteframe.Model;
using KBsiteframe.WEB.Comm;
using SysBase.BLL;
using SysBase.Model;
using Z;

namespace KBsiteframe.WEB.Manager.ContentManage
{

    public partial class LMMemberManage : PageBase
    {
        public LMMemberManage()
        {
            ModuleCode = "LMMemberManage";
            PageOperate = PurOperate.查询;
        }





        BSysOperateLog bsol = new BSysOperateLog();
     
   
        BMember bm = new BMember();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              
                BindingList();
            }
        }

    

        private void BindingList()
        {
            Query qm = Query.Build(new { SortFields = "MemberID" });

            qm.Add("MemberType", MemberType.联盟成员.ToString());
            string Name = PubCom.CheckString(txtName.Text.Trim());
            if (Name != "")
                qm.Add("MemberName", Name);
            string Phone = PubCom.CheckString(txtPhone.Text.Trim());
            if (Phone != "")
                qm.Add("Phone", Phone);
            string Email = PubCom.CheckString(txtEmail.Text.Trim());
            if (Email != "")
                qm.Add("Email", Email);
            string Qualification = PubCom.CheckString(txtQualification.Text.Trim());
            if (Qualification != "")
                qm.Add("Qualification", Qualification);
            string Organization = PubCom.CheckString(txtOrganization.Text.Trim());
            if (Organization != "")
                qm.Add("Organization", Organization);
             
            int ret = 0;
            rplist.DataSource = bm.GetMembersList(qm, AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize, out ret);
            rplist.DataBind();
            AspNetPager1.RecordCount = ret;

            // 插入日志  query
            SysOperateLog log = new SysOperateLog();
            log.LogID = StringHelper.getKey();
            log.LogType = LogType.联盟成员信息.ToString();
            log.OperateUser = GetLogUserName();
            log.OperateDate = DateTime.Now;
            log.LogOperateType = "联盟成员信息查询";
            log.LogAfterObject = JsonHelper.Obj2Json<string>(qm.GetCondition(true));
            bsol.Insert(log);
        }

        protected void zbquery_OnClick(object sender, EventArgs e)
        {
            AspNetPager1.CurrentPageIndex = 1;
            BindingList();
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindingList();
        }

        protected void ZButton2_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("LMMemberAdd.aspx");
        }

        protected void rplist_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "bj")
            {
                Response.Redirect("LMMemberEdit.aspx?ID=" + e.CommandArgument);
            }
            if (e.CommandName == "sc")
            {

                int id = int.Parse(e.CommandArgument.ToString());
                var newsmodel = bm.GetMembersByID(id);

                if (bm.Delete(newsmodel) == 1)
                {

                    //// 插入日志  delete
                    SysOperateLog log = new SysOperateLog();
                    log.LogID = StringHelper.getKey();
                    log.LogType = LogType.联盟成员信息.ToString();
                    log.OperateUser = GetLogUserName();
                    log.OperateDate = DateTime.Now;
                    log.LogOperateType = "删除联盟成员信息";
                    log.LogBeforeObject = JsonHelper.Obj2Json(newsmodel);
                    bsol.Insert(log);

                    Message.ShowOK(this, "删除联盟成员信息成功!");
                }
          
                else
                    Message.ShowWrong(this, "删除联盟成员信息失败");

            }
            BindingList();
        }
    }
}