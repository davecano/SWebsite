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
    public partial class TDDynamicEdit : PageBase
    {
        BDynamic bd = new BDynamic();
        BSysOperateLog bsol=new BSysOperateLog();
        public TDDynamicEdit()
        {
            ModuleCode = "TDDynamicManage";
            PageOperate = PurOperate.修改;
        }

        private string dynamicid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            dynamicid = PubCom.Q("ID");
            if (!IsPostBack)
            {
                hfdynamicID.Value = dynamicid;
                BindDetail();
                //Lbtime.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        private void BindDetail()
        {
          Dynamic d=  bd.GetDynamicsByID(Utils.StrToInt(hfdynamicID.Value, 0));
            txtTitle.Text = d.Title;
            if (d.IsTop != null) CbIstop.Checked = (bool) d.IsTop;
            container.Text = d.Content;

        }


        protected void btnAdd_OnClick(object sender, EventArgs e)
        {
            Dynamic d=new Dynamic();

            Dynamic dold = bd.GetDynamicsByID(Utils.StrToInt(hfdynamicID.Value, 0));
            d.DynamicID = Utils.StrToInt(hfdynamicID.Value, 0);
         
            d.IsTop = CbIstop.Checked;

            d.Content = container.Text;
            d.SubTime=DateTime.Now;
            d.Uploader = GetLogUserName();
            d.Title = PubCom.CheckString(txtTitle.Text.Trim());
          
            
            if (bd.Update(d) != 1)
            {
                Message.ShowWrong(this,"修改团队动态失败！");
            }
            else
            {


                // 插入日志  update

                Dynamic dnew = bd.GetDynamicsByID(Utils.StrToInt(hfdynamicID.Value, 0));
                SysOperateLog log = new SysOperateLog();
                log.LogID = StringHelper.getKey();
                log.LogType = LogType.团队动态信息.ToString();
                log.OperateUser = GetLogUserName();
                log.OperateDate = DateTime.Now;
                log.LogOperateType = "团队动态信息修改";
                log.LogBeforeObject = JsonHelper.Obj2Json(dold);
                log.LogAfterObject = JsonHelper.Obj2Json(dnew);
                bsol.Insert(log);
                Message.ShowOKAndRedirect(this,"修改团队动态成功","TDDynamicManage.aspx");
            }
        }

   


    }

}