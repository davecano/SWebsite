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

    public partial class TreatiseManage : PageBase
    {
        public TreatiseManage()
        {
            ModuleCode = "TreatiseManage";
            PageOperate = PurOperate.查询;
        }




        BSysCode bsc = new BSysCode();
        BSysOperateLog bsol = new BSysOperateLog();
        BTreatise bt=new BTreatise();
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
            IList<Project> plist = bp.GetProjectsList(qp);
            dpProject.Items.Clear();
            dpProject.Items.Add(new ListItem("==请选择==", ""));
            if (plist.Count > 0)
            {
                foreach (Project p in plist)
                {
                    dpProject.Items.Add(new ListItem(p.ProjectName, p.ProjectID.ToString()));
                }
            }
            IList<Member> lmlist = bm.GetMembersList(qm).Where(t => t.MemberType == MemberType.联盟成员.ToString()).ToList();
            dpLm.Items.Clear();
            dpLm.Items.Add(new ListItem("==请选择==", ""));
            if (lmlist.Count > 0)
            {
                foreach (Member m in lmlist)
                {
                    dpLm.Items.Add(new ListItem(m.MemberName, m.MemberID.ToString()));
                }
            }
            IList<Member> tdlist = bm.GetMembersList(qm).Where(t => t.MemberType == MemberType.团队成员.ToString()).ToList();
            dpTd.Items.Clear();
            dpTd.Items.Add(new ListItem("==请选择==", ""));
            if (tdlist.Count > 0)
            {
                foreach (Member m in tdlist)
                {
                    dpTd.Items.Add(new ListItem(m.MemberName, m.MemberID.ToString()));
                }
            }
        }

        private void BindingList()
        {
            Query qm = Query.Build(new { SortFields = "FinishTime Desc" });


            //6个dpdownlist
         
            if (dpExpert.SelectedValue != "")
                qm.Add("e.ExpertID", dpExpert.SelectedValue);
            if (dpLm.SelectedValue != "")
                qm.Add("m.LmMemberID", dpLm.SelectedValue);
            if (dpTd.SelectedValue != "")
                qm.Add("m.TdMemberID", dpTd.SelectedValue);
            if (dpProject.SelectedValue != "")
                qm.Add("p.ProjectID", dpProject.SelectedValue);

            string Name = PubCom.CheckString(txtBookName.Text.Trim());
            if (Name != "")
                qm.Add("t.TreatiseName", Name);
            string author = PubCom.CheckString(txtAuthor.Text.Trim());
            if (author != "")
                qm.Add("t.Author", author);
            string Subtime = PubCom.CheckString(StarTime.Text.Trim());

            if (Subtime != "")
                qm.Add("t.FinishTime", DateTime.Parse(Subtime));
            string publication = PubCom.CheckString(txtPublish.Text.Trim());
            if (publication != "")
                qm.Add("t.Publishing", publication);

            int ret = 0;
            rplist.DataSource = bt.GetTreatisesList(qm, AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize, out ret);
            rplist.DataBind();
            AspNetPager1.RecordCount = ret;

            // 插入日志  query
            SysOperateLog log = new SysOperateLog();
            log.LogID = StringHelper.getKey();
            log.LogType = LogType.专著信息.ToString();
            log.OperateUser = GetLogUserName();
            log.OperateDate = DateTime.Now;
            log.LogOperateType = "专著查询";
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
            Response.Redirect("TreatiseAdd.aspx");
        }

        protected void rplist_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "bj")
            {
                Response.Redirect("TreatiseEdit.aspx?ID=" + e.CommandArgument);
            }
            if (e.CommandName == "sc")
            {

                int id = int.Parse(e.CommandArgument.ToString());
                var newsmodel = bt.GetTreatisesByID(id);

                if (bt.Delete(newsmodel) == 1)
                {

                    //// 插入日志  delete
                    SysOperateLog log = new SysOperateLog();
                    log.LogID = StringHelper.getKey();
                    log.LogType = LogType.专著信息.ToString();
                    log.OperateUser = GetLogUserName();
                    log.OperateDate = DateTime.Now;
                    log.LogOperateType = "删除专著";
                    log.LogBeforeObject = JsonHelper.Obj2Json(newsmodel);
                    bsol.Insert(log);

                    Message.ShowOK(this, "删除专著成功!");
                }
          

                else
                    Message.ShowWrong(this, "删除专著失败");

            }
            BindingList();
        }
    }
}