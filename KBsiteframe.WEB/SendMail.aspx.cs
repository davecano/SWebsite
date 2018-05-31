using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Z;

namespace KBsiteframe.WEB
{
    public partial class SendMail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
  
        protected void btnsend_OnClick(object sender, EventArgs e)
        {
            ArrayList al = new ArrayList();
                al.Add("1023942419@qq.com");
            MailHelper.sendMail("smtp.qq.com",1, "3078495022@qq.com", "itevkocbjbjadcff", "davecano", "3078495022@qq.com", "yinchanghong12@163.com",
                "subject", "body");
        }
    }
}