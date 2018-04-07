using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Z;
using ECIS.BLL;
using ECIS.Model;
using SysBase;


namespace ECIS.Web.Pub
{
    public partial class ShowPicture : PageBase
    {
        BQualifications bq = new BQualifications();
        string QualificationsID = "";

        protected void Page_Load(object sender, EventArgs e)
        {
           QualificationsID = PubCom.Q("quali_id");
           if (QualificationsID != "") 
            {
                if (!IsPostBack) 
                {
                    BindListOfQAttach();
                }
            }
        }

        void BindListOfQAttach() 
        {
            Query q = new Query();
            string all_exten = ".png|.jpg|.jpeg|.gif|.bmp";
            IList<QualificationsAttach> qalst = bq.GetQAttachListByQID(QualificationsID);
            IList<QualificationsAttach> qalst_new = new List<QualificationsAttach>();
            for (int i = 0; i < qalst.Count; i++) 
            {
                QualificationsAttach qa = qalst[i];
                if (all_exten.IndexOf(qa.AttachSuffix) != -1)
                {
                    qa.AttachPath = PicFilePathV + qa.AttachPath;
                    qa.AttachThumbnailPath = PicFilePathV + qa.AttachThumbnailPath;
                    qa.AttachSuffix = qa.AttachSuffix.Substring(1);
                    qalst_new.Add(qa);
                }
            }
            rpfileupload.DataSource = qalst_new;
            rpfileupload.DataBind();
        }
    }
}