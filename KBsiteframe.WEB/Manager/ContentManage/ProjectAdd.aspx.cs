using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Security;
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
    public partial class ProjectAdd : PageBase
    {
        public ProjectAdd()
        {
            ModuleCode = "ProjectManage";
            PageOperate = PurOperate.添加;
        }
          BSysCode bc=new BSysCode();
        BExpert be = new BExpert();
        BProject bp = new BProject();
        BMember bm = new BMember();
        BSysOperateLog bsol = new BSysOperateLog();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDownList();
            }
        }

        void BindDropDownList()
        {
            //绑定项目阶段
            Query q=Query.Build(new {SortFields="CodeID"});
            q.Add("CodeName", "ProjectPeriod");
            DpProjectPeriod.Items.Clear();
            DpProjectPeriod.Items.Add(new ListItem("==请选择==",""));
           IList<SysCode>  slist=bc.GetSysCodeList(q);
            if(slist.Count>0)
            foreach (SysCode sc in slist)
            {
                    DpProjectPeriod.Items.Add(new ListItem(sc.CodeText,sc.CodeValue));
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


        protected void btnAdd_OnClick(object sender, EventArgs e)
        {

     

            Project p = new Project();

            p.ProjectID = bp.GetMaxID() + 1;
            p.ProjectName = PubCom.CheckString(txtName.Text.Trim());
            p.ProjectContent = PubCom.CheckString(txtContent.Text.Trim());
            p.ProjectPeriod = DpProjectPeriod.SelectedValue;
            p.OrgName = PubCom.CheckString(txtOrgName.Text.Trim());
            p.StartTime = DateTime.Parse(StarTime.Text.Trim());
            p.EndTime = DateTime.Parse(EndTime.Text.Trim());
            if (dpExpert.SelectedValue != "")
                p.ExpertID = Utils.StrToInt(dpExpert.SelectedValue, 0);
            if (dpLm.SelectedValue != "")
                p.LmMemberID = Utils.StrToInt(dpLm.SelectedValue, 0);
            if (dpTd.SelectedValue != "")
                p.TdMemberID = Utils.StrToInt(dpTd.SelectedValue, 0);
           

            if (bp.Insert(p) == 1)
            {
              
                //// 插入日志 add
                SysOperateLog log = new SysOperateLog();
                log.LogID = StringHelper.getKey();
                log.LogType = LogType.项目信息.ToString();
                log.OperateUser = GetLogUserName();
                log.OperateDate = DateTime.Now;
                log.LogOperateType = "项目新增";

                log.LogAfterObject = JsonHelper.Obj2Json(p);
                bsol.Insert(log);
                Message.ShowOKAndRedirect(this, "添加项目成功", "ProjectManage.aspx");
            }

            else
            {
                Message.ShowWrong(this, "添加项目失败！");
                return;
            }


        }



    }

}