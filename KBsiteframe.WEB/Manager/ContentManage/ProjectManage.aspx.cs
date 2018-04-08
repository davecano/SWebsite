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

    public partial class ProjectManage : PageBase
    {
        public ProjectManage()
        {
            ModuleCode = "ProjectManage";
            PageOperate = PurOperate.查询;
        }




        BSysCode bc = new BSysCode();
        BSysOperateLog bsol = new BSysOperateLog();
     
        BExpert be = new BExpert();
        BProject bp = new BProject();
        BMember bm = new BMember();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDownList();
                BindingList();
            }
        }

        void BindDropDownList()
        {
            //绑定项目阶段
            Query q = Query.Build(new { SortFields = "CodeID" });
            q.Add("CodeName", "ProjectPeriod");
            dpProjectPeriod.Items.Clear();
            dpProjectPeriod.Items.Add(new ListItem("==请选择==", ""));
            IList<SysCode> slist = bc.GetSysCodeList(q);
            if (slist.Count > 0)
                foreach (SysCode sc in slist)
                {
                    dpProjectPeriod.Items.Add(new ListItem(sc.CodeText, sc.CodeValue));
                }
            //绑定 专家，项目，联盟成员，团队成员
            Query qe = Query.Build(new { SortFields = "ExpertID" });
            Query qp = Query.Build(new { SortFields = "ProjectID" });
            Query qm = Query.Build(new { SortFields = "MemberID" });
            IList<Expert> elist = be.GetExpertsList(qe);
            dpExpert.Items.Clear();
            dpExpert.Items.Add(new ListItem("==请选择==", ""));
            if (elist.Count > 0)
            {
                foreach (Expert e in elist)
                {
                    dpExpert.Items.Add(new ListItem(e.EName, e.ExpertID.ToString()));
                }
            }
       
            IList<Member> lmlist = bm.GetMembersList(qm).Where(t => t.MemberType == MemberType.联盟成员.ToString()).ToList();
            dpLm.Items.Clear();
            dpLm.Items.Add(new ListItem("==请选择==", ""));
            if (lmlist.Count > 0)
            {
                foreach (Member m in lmlist)
                {
                    dpLm.Items.Add(new ListItem(m.MenberName, m.MemberID.ToString()));
                }
            }
            IList<Member> tdlist = bm.GetMembersList(qm).Where(t => t.MemberType == MemberType.团队成员.ToString()).ToList();
            dpTd.Items.Clear();
            dpTd.Items.Add(new ListItem("==请选择==", ""));
            if (tdlist.Count > 0)
            {
                foreach (Member m in tdlist)
                {
                    dpTd.Items.Add(new ListItem(m.MenberName, m.MemberID.ToString()));
                }
            }
        }

        private void BindingList()
        {
            Query qm = Query.Build(new { SortFields = "StartTime Desc" });


            //6个dpdownlist
         
            if (dpExpert.SelectedValue != "")
                qm.Add("e.ExpertID", dpExpert.SelectedValue);
            if (dpLm.SelectedValue != "")
                qm.Add("m.LmMemberID", dpLm.SelectedValue);
            if (dpTd.SelectedValue != "")
                qm.Add("m.TdMemberID", dpTd.SelectedValue);
            if (dpProjectPeriod.SelectedValue != "")
                qm.Add("p.ProjectPeriod", dpProjectPeriod.SelectedValue);

            string Name = PubCom.CheckString(txtName.Text.Trim());
            if (Name != "")
                qm.Add("p.ProjectName", Name);
            string OrgName = PubCom.CheckString(txtOrgName.Text.Trim());
            if (OrgName != "")
                qm.Add("p.OrgName", OrgName);
            string starttime = PubCom.CheckString(StarTime.Text.Trim());

            if (starttime != "")
                qm.Gt("p.StartTime", DateTime.Parse(starttime));
            string endtime = PubCom.CheckString(EndTime.Text.Trim());
            if (endtime != "")
                qm.Lt("p.EndTime", DateTime.Parse(endtime));

           
            int ret = 0;
            rplist.DataSource = bp.GetProjectsList(qm, AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize, out ret);
            rplist.DataBind();
            AspNetPager1.RecordCount = ret;

            // 插入日志  query
            SysOperateLog log = new SysOperateLog();
            log.LogID = StringHelper.getKey();
            log.LogType = LogType.项目信息.ToString();
            log.OperateUser = GetLogUserName();
            log.OperateDate = DateTime.Now;
            log.LogOperateType = "项目查询";
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
            Response.Redirect("ProjectAdd.aspx");
        }

        protected void rplist_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "bj")
            {
                Response.Redirect("ProjectEdit.aspx?ID=" + e.CommandArgument);
            }
            if (e.CommandName == "sc")
            {

                int id = int.Parse(e.CommandArgument.ToString());
                var newsmodel = bp.GetProjectsByID(id);

                if (bp.Delete(newsmodel) == 1)
                {

                    //// 插入日志  delete
                    SysOperateLog log = new SysOperateLog();
                    log.LogID = StringHelper.getKey();
                    log.LogType = LogType.项目信息.ToString();
                    log.OperateUser = GetLogUserName();
                    log.OperateDate = DateTime.Now;
                    log.LogOperateType = "删除项目";
                    log.LogBeforeObject = JsonHelper.Obj2Json(newsmodel);
                    bsol.Insert(log);

                    Message.ShowOK(this, "删除项目成功!");
                }
          
                else
                    Message.ShowWrong(this, "删除项目失败");

            }
            BindingList();
        }
    }
}