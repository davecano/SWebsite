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

namespace KBsiteframe.WEB.Website.AcademicResource
{
    public partial class ShowAllTool : VistorPageBase
    {
        BTool bt=new BTool();
        private string type;
        protected void Page_Load(object sender, EventArgs e)
        {
            EventHandler += () =>
            {
                foreach (RepeaterItem item in rplist.Items)
                {
                   LinkButton lb= item.FindControl("zlxz") as LinkButton;
                    Literal lt=item.FindControl("ltmsg") as Literal;
                    lb.Enabled = false;
                    lt.Visible = true;

                }
            };
            type=PubCom.Q("type");
            if (!IsPostBack)
            {
                BindDetail();
            }
        }

        private void BindDetail()
        {
            Query q=new Query();
            q.OrderBy("UploadTime");
            q.Add("ToolType", ((ToolType)Enum.Parse(typeof(ToolType), type)).ToString());
            int rec = 0;
            rplist.DataSource= bt.GetToolsList(q,AspNetPager1.CurrentPageIndex,AspNetPager1.PageSize,out rec);
            rplist.DataBind();
            AspNetPager1.RecordCount = rec;
        }

    

        protected void AspNetPager1_OnPageChanged(object sender, EventArgs e)
        {
            BindDetail();
        }

        protected void rplist_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            var model = bt.GetToolsByID(id);
            string realpath;
        

          if (e.CommandName == "dj")
            {
                //做个判定
                if (model.PathType == PathType.服务器.ToString())
                {
                    realpath = PicFilePathV + "ToolAttach/" + model.ToolPath;
                }
                else /*if (model.PathType == PathType.链接.ToString())*/
                    realpath = model.ToolPath;

                if (model.ToolSuffix == "mp4" || model.ToolSuffix == "webm" || model.ToolSuffix == "ogg")
                {
                    Response.Write("<script>window.open('/Pub/ShowVideo.aspx?ID="+id+"','_blank')</script>");
                }
                else
                {
                    bt.DownloadFile(realpath);
                }
             
            }

            BindDetail();
        }
    }
}