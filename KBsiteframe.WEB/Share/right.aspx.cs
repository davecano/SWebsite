using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using KBsiteframe.Model;
using KBsiteframe.WEB.Comm;
using Z;

namespace KBsiteframe.Web.Share
{
    public partial class right : PageBase
    {

       
        protected void Page_Load(object sender, EventArgs e)
        {
            string str = CurrentAccount.User.UserName;
            // 获取当前时间
            DateTime time = DateTime.Now;
            if (time.Hour >= 0 && time.Hour < 6)
            {
                str += "凌晨好";
            }
            else if (time.Hour > 5 && time.Hour < 11)
            {
                str += "上午好";
            }
            else if (time.Hour > 10 && time.Hour < 13)
            {
                str += "中午好";
            }
            else if (time.Hour > 12 && time.Hour < 18)
            {
                str += "下午好";
            }
            else if (time.Hour > 17 && time.Hour < 24)
            {
                str += "晚上好";
            }

            lblLoginUser.Text = str.ToString();

            
        }


    }
}