using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KBsiteframe.Model;
using KBsiteframe.WEB.Comm;
using Z;

namespace KBsiteframe.WEB.Manager.ContentManage
{
    public partial class ToolAttachUpload : PageBase
    {
        private string type;
        protected void Page_Load(object sender, EventArgs e)
        {
            type = PubCom.Q("ID");
            if (!IsPostBack)
            {
                lttype.Text = ((ToolType)Enum.Parse(typeof(ToolType), type)).ToString(); 
            }
        }
    }
}