using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KBsiteframe.Bll;
using KBsiteframe.Model;
using KBsiteframe.WEB.Comm;
using Z;

namespace KBsiteframe.WEB.Website.AcademicAlliance
{
    public partial class ShowMember : VistorPageBase
    {
        private BMember bm = new BMember();
        BArticle ba=new BArticle();
        BTreatise bt=new BTreatise();
        private int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Utils.StrToInt(Q("ID"),0);
            if (!IsPostBack)
            {
                BindDetail();
            }
        }

        private void BindDetail()
        {
           //BindBasicMessage
            Member m = bm.GetMembersByID(id);
            ltorg.Text = m.Organization;
            ltphone.Text = m.Phone;
            ltemail.Text = m.Email;
            ltname.Text = m.MemberName;
            ltqua.Text = m.Qualification;
            lttype.Text = m.MemberType;
            hftypeint.Value= ((int)Enum.Parse(typeof(MemberType), m.MemberType)).ToString();
            htmlimg.Attributes["src"]=PicFilePathV+m.MemberPic;
           //Article
              Query qa=new Query();
            qa.OrderBy("Views desc");
            if(m.MemberType==MemberType.联盟成员.ToString())
            qa.Append("a.LmMemberID="+id);
            else if(m.MemberType==MemberType.团队成员.ToString())
               qa.Append("a.TdMemberID=" + id);
            int rec = 0;
            rplist.DataSource = ba.GetArticlesList(qa, 1, 10, out rec);
            rplist.DataBind();
            //Treatise
            Query qt=new Query();
            qt.OrderBy("FinishTime desc");
            if (m.MemberType == MemberType.联盟成员.ToString())
                qa.Append("t.LmMemberID=" + id);
            else if (m.MemberType == MemberType.团队成员.ToString())
                qa.Append("t.TdMemberID=" + id);
            int ret = 0;
            rplist2.DataSource = bt.GetTreatisesList(qt, 1, 10, out ret);
            rplist2.DataBind();


        }
    }
}