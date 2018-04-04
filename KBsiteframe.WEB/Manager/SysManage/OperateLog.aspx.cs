using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using KBsiteframe.Model;
using KBsiteframe.WEB.Comm;
using SysBase.BLL;
using SysBase.Model;
using Z;

namespace KBsiteframe.Web.Manager.SysManage
{
    public partial class OperateLog : PageBase
    {
        public OperateLog()
        {
            ModuleCode = "OperateLog";
            PageOperate = PurOperate.查询;
        }
        BSysOperateLog bsol = new BSysOperateLog();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDpList();
                BindList();
            }
        }

        private void BindList()
        {

            Query q = Query.Build(new { SortFields = "OperateDate desc" });
            string LogTypes = PubCom.CheckString(dpLogType.SelectedValue.Trim());
          
            string OperateUser = PubCom.CheckString(txtOperateUser.Text.Trim());
            if (LogTypes != "==请选择==")
                q.Add("LogType", LogTypes);
          
            //处理日期类
            if (StarTime.Text.Trim() != "") q.Gt("OperateDate", StarTime.Text.Trim());
            if (EndTime.Text.Trim() != "") q.Lt("OperateDate", EndTime.Text.Trim());
            if (OperateUser != "")
                q.Add("OperateUser", OperateUser);
            int rec = 0;
            rplist.DataSource = bsol.GetSysOperateLogList(q, AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize, out rec);

            rplist.DataBind();
            AspNetPager1.RecordCount = rec;
            //// 插入日志
            SysOperateLog log = new SysOperateLog();
            log.LogID = StringHelper.getKey();
            log.LogType = LogType.日志信息.ToString();
            log.OperateUser = GetLogUserName();
            log.OperateDate = DateTime.Now;
            log.LogOperateType = "日志信息查询";
            log.LogAfterObject = JsonHelper.Obj2Json<string>(q.GetCondition(true));
            bsol.Insert(log);

        }
        protected void zbquery_Click(object sender, EventArgs e)
        {
            AspNetPager1.CurrentPageIndex = 1;
            BindList();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindList();
        }

        private void BindDpList()
        {
            Utils.BindDropDownList(typeof(LogType), dpLogType, "");
     
        }

        protected void rplist_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string LogID = e.CommandArgument.ToString();

            if (e.CommandName == "ck")
            {
                Response.Redirect("OperateLogView.aspx?ID=" + EncryptHelper.Encode(LogID));
            }
        }
    }
}