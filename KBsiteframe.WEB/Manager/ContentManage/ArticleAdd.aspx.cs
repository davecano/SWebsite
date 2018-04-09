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
   
    public partial class ArticleAdd : PageBase
    {
        public ArticleAdd()
        {
            ModuleCode = "ArticleManage";
            PageOperate = PurOperate.添加;
        }

      
        BSysCode bsc = new BSysCode();
        BSysOperateLog bsol = new BSysOperateLog();
        BArticle ba=new BArticle();
        BExpert be=new BExpert();
        BProject bp=new BProject();
        BMember bm=new BMember();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDownList();
            }
        }

        void BindDropDownList()
        {
            // 绑定语言和类型
            dpArticleType.Items.Clear();
            dpArticleType.Items.Add(new ListItem("==请选择==", ""));

            Query q = Query.Build(new { SortFields = "SortNo" });
            q.Append("CodeName='ArticleType' or CodeName='Language'");
            IList<SysCode> sclisttype = bsc.GetSysCodeList(q).Where(t=>t.CodeName== "ArticleType").ToList();
            IList<SysCode> sclistlan = bsc.GetSysCodeList(q).Where(t => t.CodeName == "Language").ToList();
            if (sclisttype.Count > 0)
            {
                foreach (SysCode sc in sclisttype)
                {
                    dpArticleType.Items.Add(new ListItem(sc.CodeText, sc.CodeValue));
                }
            }
            dpLanguage.Items.Clear();
            dpLanguage.Items.Add(new ListItem("==请选择==", ""));
            if (sclistlan.Count > 0)
            {
                foreach (SysCode sc in sclistlan)
                {
                    dpLanguage.Items.Add(new ListItem(sc.CodeText, sc.CodeValue));
                }
            }
            //绑定 专家，项目，联盟成员，团队成员
            Query qe=Query.Build(new {SortFields="ExpertID"});
            Query qp = Query.Build(new { SortFields = "ProjectID" });
            Query qm = Query.Build(new { SortFields = "MemberID" });
            IList<Expert> elist= be.GetExpertsList(qe);
            dpExpert.Items.Clear();
            dpExpert.Items.Add(new ListItem("==请选择==", ""));
            if (elist.Count > 0)
            {
                foreach (Expert e in elist)
                {
                    dpExpert.Items.Add(new ListItem(e.EName,e.ExpertID.ToString()));
                }
            }
            IList<Project> plist =bp.GetProjectsList(qp);
            dpProject.Items.Clear();
            dpProject.Items.Add(new ListItem("==请选择==", ""));
            if (plist.Count > 0)
            {
                foreach (Project p in plist)
                {
                    dpProject.Items.Add(new ListItem(p.ProjectName, p.ProjectID.ToString()));
                }
            }
            IList<Member> lmlist = bm.GetMembersList(qm).Where(t=>t.MemberType== MemberType.联盟成员.ToString()).ToList();
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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Article a=new Article();

            a.ArticleID = ba.GetMaxID() + 1;
            a.ArticleTitle = PubCom.CheckString(txtArticleTitle.Text.Trim());
           
            a.SubmitTime = DateTime.Parse(StarTime.Text.Trim());
            a.Publication = PubCom.CheckString(txtPublication.Text.Trim());
            a.Keyword = PubCom.CheckString(txtKryword.Text.Trim());
            a.Summary = PubCom.CheckString(txtSummary.Text.Trim());
            a.LanguageType = dpLanguage.SelectedValue;
            a.ArticleType = dpArticleType.SelectedValue;
          
            if(dpExpert.SelectedValue!="")
            a.ExpertID = Utils.StrToInt(dpExpert.SelectedValue,0);

            if (dpProject.SelectedValue != "")
                a.ProjectID = Utils.StrToInt(dpProject.SelectedValue, 0);
            if (dpLm.SelectedValue != "")

                a.LmMemberID = Utils.StrToInt(dpLm.SelectedValue, 0);
            if (dpTd.SelectedValue != "")

                a.TdMemberID = Utils.StrToInt(dpTd.SelectedValue, 0);
            int rec= ba.Insert(a);
            int ret = 0;
            if (rec == 1)
            {

                HttpFileCollection htf = Request.Files;
           
             ret = ba.UploadFile(htf[0], PicFilePath, a.ArticleID);
               
            }
       
            
            if (ret == 1)
            {
                //// 插入日志
                SysOperateLog log = new SysOperateLog();
                log.LogID = StringHelper.getKey();
                log.LogType = LogType.文章信息.ToString();
                log.OperateUser = GetLogUserName();
                log.OperateDate = DateTime.Now;
                log.LogOperateType = "新增文章";

                log.LogAfterObject = JsonHelper.Obj2Json(a);//不包含附件
                log.LogRemark = "不包含附件内容";
                bsol.Insert(log);
                Message.ShowOKAndRedirect(this, "添加成功", "ArticleManage.aspx");
            }
            else
            {
                Message.ShowWrong(this, "添加失败");
            }
        }
    }
}