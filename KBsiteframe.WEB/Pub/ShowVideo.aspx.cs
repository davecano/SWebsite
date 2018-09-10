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

namespace KBsiteframe.WEB.Pub
{
    public partial class ShowVideo :VistorPageBase
    {
        public string VideoSource;
        public string VideoType;
        private int toolID;
        private BTool bt = new BTool();
        protected void Page_Load(object sender, EventArgs e)
        {
            toolID = Utils.StrToInt(PubCom.Q("ID"),0);
         
            if (!IsPostBack)
            {

                Tool t=bt.GetToolsByID(toolID);
                //做个判定
                if (t.PathType == PathType.服务器.ToString())
                {
                    VideoSource = PicFilePathV + "ToolAttach/" + t.ToolPath;
                }
                else /*if (model.PathType == PathType.链接.ToString())*/
                    VideoSource = t.ToolPath;
             
                VideoType ="video/"+ t.ToolSuffix;
                //VideoSource = "/文档及其他/login & logout in asp net sql database with session - Web Development.mp4";
                //VideoType = "video/mp4";
            }
        }
    }
}