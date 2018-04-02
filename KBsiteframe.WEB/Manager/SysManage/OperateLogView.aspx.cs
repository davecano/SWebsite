using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyCmsWEB;
using SysBase.BLL;
using SysBase.Model;
using Z;

namespace KBsiteframe.Web.Manager.SysManage
{
    public partial class OperateLogView : PageBase
    {
        public OperateLogView()
        {
            ModuleCode = "OperateLog";
            PageOperate = PurOperate.查看;
        }
        BSysOperateLog bsol=new BSysOperateLog();
        string LogID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Q("ID", out LogID);
            BindList();
        }

        private void BindList()
        {
            
            hfID.Value = LogID;
            SysOperateLog log = bsol.GetSysOperateLogByID(LogID);
            ltLogType.Text = log.LogType;
            ltOperateUser.Text = log.OperateUser;
            ltLogOperateType.Text = log.LogOperateType;
            ltLogBeforeObject.Text = log.LogBeforeObject;
            ltLogAfterObject.Text = log.LogAfterObject;
            ltLogRemark.Text = log.LogRemark;
        }
    }
}