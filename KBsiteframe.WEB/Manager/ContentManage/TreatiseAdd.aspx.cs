using System;
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
    public partial class TreatiseAdd : PageBase
    {
        public TreatiseAdd()
        {
            ModuleCode = "TreatiseManage";
            PageOperate = PurOperate.添加;
        }
        BTreatise bt = new BTreatise();
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
            //新添加的博士啊，硕士啊
            IList<Member> stulist = bm.GetMembersList(qm).Where(t => t.MemberType == MemberType.普通学生.ToString()).ToList();
            dpstu.Items.Clear();
            dpstu.Items.Add(new ListItem("==请选择==", ""));
            if (stulist.Count > 0)
            {
                foreach (Member m in stulist)
                {
                    dpstu.Items.Add(new ListItem(m.MemberName, m.MemberID.ToString()));
                }
            }
        }


        protected void btnAdd_OnClick(object sender, EventArgs e)
        {

            string savepath = DateTime.Now.Year + "_" + DateTime.Now.Month + "/" + DateTime.Now.Day;

            Treatise t = new Treatise();

            t.TreatiseID = bt.GetMaxID() + 1;
            t.TreatiseName = PubCom.CheckString(txtBookName.Text.Trim());
            t.FinishTime = DateTime.Parse(StarTime.Text.Trim());
            t.Author = PubCom.CheckString(txtauthor.Text.Trim());
            t.Publishing = PubCom.CheckString(txtPublishing.Text.Trim());
            t.Summary = PubCom.CheckString(txtsummary.Text.Trim());
            string str = txtCatalog.Text.Trim();
            str = str.Replace("<", "&lt;");
            str = str.Replace(">", "&gt;");
            str = str.Replace(" ", "&nbsp;");
            str = str.Replace("\r\n", "<br>");
            t.Catalog = str;
            if (dpExpert.SelectedValue != "")
                t.ExpertID = Utils.StrToInt(dpExpert.SelectedValue, 0);
            if (dpLm.SelectedValue != "")
                t.LmMemberID = Utils.StrToInt(dpLm.SelectedValue, 0);
            if (dpTd.SelectedValue != "")
                t.TdMemberID = Utils.StrToInt(dpTd.SelectedValue, 0);
            if (dpProject.SelectedValue != "")
                t.ProjectID = Utils.StrToInt(dpProject.SelectedValue, 0);
            if (dpstu.SelectedValue != "")

                t.StuMemberID = Utils.StrToInt(dpstu.SelectedValue, 0);
            if (bt.Insert(t) == 1)
            {
                bt.UploadValidate(pic_upload, lbl_pic, PicFilePath, savepath, t.TreatiseID);


                //// 插入日志 add
                SysOperateLog log = new SysOperateLog();
                log.LogID = StringHelper.getKey();
                log.LogType = LogType.专著信息.ToString();
                log.OperateUser = GetLogUserName();
                log.OperateDate = DateTime.Now;
                log.LogOperateType = "专著新增";

                log.LogAfterObject = JsonHelper.Obj2Json(t);
                bsol.Insert(log);
                Message.ShowOKAndRedirect(this, "添加专著成功", "TreatiseManage.aspx");
            }

            else
            {
                Message.ShowWrong(this, "添加专著失败！");
                return;
            }


        }



    }

}