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
    public partial class NoticeAdd : PageBase
    {
        public NoticeAdd()
        {
            ModuleCode = "NoticeManage";
            PageOperate = PurOperate.添加;
        }
    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              Utils.BindDropDownList(typeof(NoticeType),dpStatus,"");
               
            }
        }

         BNotice bn=new BNotice();

        BSysOperateLog bsol=new BSysOperateLog();
        protected void btnAdd_OnClick(object sender, EventArgs e)
        {
           Notice n=new Notice();

            n.NoticeID = bn.GetMaxID() + 1;
            n.NoticeTitle = PubCom.CheckString(txtTitle.Text.Trim());
            n.NoticeStatus = dpStatus.SelectedValue;
            n.NoticeContent = PubCom.CheckString(txtContent.Text.Trim());
            n.CreateUser = GetLogUserName();
            n.CreateDate=DateTime.Now;
            n.LastUpdateDate=DateTime.Now;
            
            if (bn.Insert(n) != 1)
            {
                Message.ShowWrong(this,"添加公告失败！");
            }
            else
            {

                //// 插入日志 add
                SysOperateLog log = new SysOperateLog();
                log.LogID = StringHelper.getKey();
                log.LogType = LogType.公告信息.ToString();
                log.OperateUser = GetLogUserName();
                log.OperateDate = DateTime.Now;
                log.LogOperateType = "公告信息新增";

                log.LogAfterObject = JsonHelper.Obj2Json(n);
                bsol.Insert(log);

                Message.ShowOKAndRedirect(this, "添加公告信息成功", "NoticeManage.aspx");
            }
        }

   


    }

}