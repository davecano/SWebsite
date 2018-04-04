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

using Z;

namespace MyCmsWEB.Content
{
    public partial class TreatiseAdd : PageBase
    {
        public TreatiseAdd()
        {
            ModuleCode = "TreatiseManage";
            PageOperate = PurOperate.添加;
        }
       BTreatise bt=new BTreatise();
        BExpert be = new BExpert();
        BProject bp = new BProject();
        BMember bm = new BMember();
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


        protected void btnAdd_OnClick(object sender, EventArgs e)
        {
            string picurl = "";
            string  savepath= DateTime.Now.Year + "_" + DateTime.Now.Month + "/" + DateTime.Now.Day;
            if (bt.UploadValidate(pic_upload, lbl_pic, PicFilePath, savepath, out picurl))
            {
                Treatise t = new Treatise();

                t.TreatiseID = bt.GetMaxID() + 1;
                t.TreatiseName = PubCom.CheckString(txtBookName.Text.Trim());
                t.FinishTime = DateTime.Parse(StarTime.Text.Trim());
                t.Author = PubCom.CheckString(txtauthor.Text.Trim());
                t.Publishing = PubCom.CheckString(txtPublishing.Text.Trim());
                t.Summary = PubCom.CheckString(txtsummary.Text.Trim());
                t.Catalog = PubCom.CheckString(txtCatalog.Text.Trim());
                t.Picpath = picurl;
                if(bt.Insert(t)==1)
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