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

namespace KBsiteframe.Web.Manager.ContentManage
{
    public partial class LMDynamicAdd : PageBase
    {
        public LMDynamicAdd()
        {
            ModuleCode = "LMDynamicManage";
            PageOperate = PurOperate.添加;
        }
    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
           
                //Lbtime.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        BDynamic bd = new BDynamic();

        BSysOperateLog bsol=new BSysOperateLog();
        protected void btnAdd_OnClick(object sender, EventArgs e)
        {
            Dynamic d=new Dynamic();
    
         
            d.DynamicID = bd.GetMaxID() + 1;
            d.DynamicType = DynamicType.联盟动态.ToString();
            d.IsTop = CbIstop.Checked;

            d.Content = container.Text;
            d.SubTime=DateTime.Now;
            d.Uploader = GetLogUserName();
            d.Title = PubCom.CheckString(txtTitle.Text.Trim());
          
            
            if (bd.Insert(d) != 1)
            {
                Message.ShowWrong(this,"添加联盟动态失败！");
            }
            else
            {

                //// 插入日志 add
                SysOperateLog log = new SysOperateLog();
                log.LogID = StringHelper.getKey();
                log.LogType = LogType.联盟动态信息.ToString();
                log.OperateUser = GetLogUserName();
                log.OperateDate = DateTime.Now;
                log.LogOperateType = "联盟动态信息新增";

                log.LogAfterObject = JsonHelper.Obj2Json(d);
                bsol.Insert(log);

                Message.ShowOKAndRedirect(this,"添加联盟动态成功","LMDynamicManage.aspx");
            }
        }

   


    }

}