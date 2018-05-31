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
    public partial class TreatiseEdit : PageBase
    {
        public TreatiseEdit()
        {
            ModuleCode = "TreatiseManage";
            PageOperate = PurOperate.修改;
        }
        BTreatise bt = new BTreatise();
      
        BExpert be = new BExpert();
        BProject bp = new BProject();
        BMember bm = new BMember();
        BSysOperateLog bsol = new BSysOperateLog();
        private string treatiseID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            treatiseID = PubCom.Q("ID");
            if (!IsPostBack)
            {
                BindDropdownList();
                BindDetail();
            }
        }

        private void BindDropdownList()
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

        private void BindDetail()
        {
            hftreatiseID.Value = treatiseID;
            Treatise t = bt.GetTreatisesByID(Utils.StrToInt(hftreatiseID.Value, 0));
            txtBookName.Text = t.TreatiseName;
            txtauthor.Text = t.Author;
            txtPublishing.Text = t.Publishing;
            txtCatalog.Text = t.Catalog;
            txtsummary.Text = t.Summary;
            StarTime.Text = t.FinishTime.ToString();
            ImgNews.ImageUrl = PicFilePathV + t.Picpath;

            if (t.ExpertID != null || t.ExpertID != 0)
                dpExpert.SelectedValue = t.ExpertID.ToString();

            if (t.ProjectID != null || t.ProjectID != 0)
                dpProject.SelectedValue = t.ProjectID.ToString();

            if (t.LmMemberID != null || t.LmMemberID != 0)
                dpLm.SelectedValue = t.LmMemberID.ToString();

            if (t.TdMemberID != null || t.TdMemberID != 0)
                dpTd.SelectedValue = t.TdMemberID.ToString();
        }


        protected void btnAdd_OnClick(object sender, EventArgs e)
        {

            string savepath = DateTime.Now.Year + "_" + DateTime.Now.Month + "/" + DateTime.Now.Day;
            Treatise oldt = bt.GetTreatisesByID(Utils.StrToInt(hftreatiseID.Value, 0));
            Treatise t = new Treatise();
            t.TreatiseID = Utils.StrToInt(hftreatiseID.Value, 0);
            t.TreatiseName = PubCom.CheckString(txtBookName.Text.Trim());
            t.FinishTime = DateTime.Parse(StarTime.Text.Trim());
            t.Author = PubCom.CheckString(txtauthor.Text.Trim());
            t.Publishing = PubCom.CheckString(txtPublishing.Text.Trim());
            t.Summary = PubCom.CheckString(txtsummary.Text.Trim());
            t.Catalog = PubCom.CheckString(txtCatalog.Text.Trim());
            if (dpExpert.SelectedValue != "")
                t.ExpertID = Utils.StrToInt(dpExpert.SelectedValue, 0);
            if (dpLm.SelectedValue != "")
                t.LmMemberID = Utils.StrToInt(dpLm.SelectedValue, 0);
            if (dpTd.SelectedValue != "")
                t.TdMemberID = Utils.StrToInt(dpTd.SelectedValue, 0);
            if (dpProject.SelectedValue != "")
                t.ProjectID = Utils.StrToInt(dpProject.SelectedValue, 0);
            if (bt.Update(t) == 1)
            {
                bt.UploadValidate(pic_upload, lbl_pic, PicFilePath, savepath, Utils.StrToInt(hftreatiseID.Value, 0));
                // 插入日志  update


                SysOperateLog log = new SysOperateLog
                {
                    LogID = StringHelper.getKey(),
                    LogType = LogType.专著信息.ToString(),
                    OperateUser = GetLogUserName(),
                    OperateDate = DateTime.Now,
                    LogOperateType = "专著修改",
                    LogBeforeObject = JsonHelper.Obj2Json(oldt),
                    LogAfterObject = JsonHelper.Obj2Json(t)
                };
                bsol.Insert(log);
                Message.ShowOKAndRedirect(this, "修改专著成功", "TreatiseManage.aspx");
            }

            else
            {
                Message.ShowWrong(this, "修改专著失败！");
                return;
            }


        }



    }

}