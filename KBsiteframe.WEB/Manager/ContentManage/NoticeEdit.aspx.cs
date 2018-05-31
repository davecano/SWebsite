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
    public partial class NoticeEdit : PageBase
    {
        public NoticeEdit()
        {
            ModuleCode = "NoticeManage";
            PageOperate = PurOperate.修改;
        }
    
        protected void Page_Load(object sender, EventArgs e)
        {
            hfNoticeID.Value = PubCom.Q("ID");
            if (!IsPostBack)
            {
              Utils.BindDropDownList(typeof(NoticeType),dpStatus,"");
                BindDetail();
            }
        }

        private void BindDetail()
        {
            Notice n = bn.GetNoticesByID(Utils.StrToInt(hfNoticeID.Value, 0));
            txtTitle.Text = n.NoticeTitle;
            dpStatus.SelectedValue = n.NoticeStatus;
            container.Text = n.NoticeContent;
        }

        BNotice bn=new BNotice();

        BSysOperateLog bsol=new BSysOperateLog();
        protected void btnAdd_OnClick(object sender, EventArgs e)
        {
           Notice n=new Notice();
            Notice nold = bn.GetNoticesByID(Utils.StrToInt(hfNoticeID.Value, 0));
            n.NoticeID = Utils.StrToInt(hfNoticeID.Value,0);
            n.NoticeTitle = PubCom.CheckString(txtTitle.Text.Trim());
            n.NoticeStatus = dpStatus.SelectedValue;
            n.NoticeContent = container.Text;
            n.LastUpdateDate=DateTime.Now;
            
            if (bn.Update(n) != 1)
            {
                Message.ShowWrong(this,"修改公告失败！");
            }
            else
            {

                //// 插入日志 add
                SysOperateLog log = new SysOperateLog();
                log.LogID = StringHelper.getKey();
                log.LogType = LogType.公告信息.ToString();
                log.OperateUser = GetLogUserName();
                log.OperateDate = DateTime.Now;
                log.LogOperateType = "公告信息修改";
                log.LogBeforeObject = JsonHelper.Obj2Json(nold);
                log.LogAfterObject = JsonHelper.Obj2Json(n);
                bsol.Insert(log);

                Message.ShowOKAndRedirect(this, "修改公告信息成功", "NoticeManage.aspx");
            }
        }

   


    }

}