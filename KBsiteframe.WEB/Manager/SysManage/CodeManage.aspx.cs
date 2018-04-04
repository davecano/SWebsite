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
    public partial class CodeManage : PageBase
    {
        public CodeManage()
        {
            ModuleCode = "CodeManage";
            PageOperate = PurOperate.查询;
        }

        BSysCode bsc = new BSysCode();
        BSysOperateLog bsol = new BSysOperateLog();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindList();
            }
        }

        void BindList()
        {
            var qm = Query.Build(new {SortFields = "CodeName desc,SortNo"});

            string name = PubCom.CheckString(txtCodeName.Text.Trim());
            if (name != "")
            {
                qm.Add("CodeName", name);
            }

            string text = PubCom.CheckString(txtCodeText.Text.Trim());
            if (text != "")
            {
                qm.Add("CodeText", text);
            }

            string value = PubCom.CheckString(txtCodeValue.Text.Trim());
            if (value != "")
            {
                qm.Add("CodeValue", value);
            }

            int rec = 0;
            rplist.DataSource = bsc.GetSysCodeList(qm, AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize, out rec);
            rplist.DataBind();
            AspNetPager1.RecordCount = rec;
            //// 插入日志
            SysOperateLog log = new SysOperateLog();
            log.LogID = StringHelper.getKey();
            log.LogType = LogType.数据字典.ToString();
            log.OperateUser = GetLogUserName();
            log.OperateDate = DateTime.Now;
            log.LogOperateType = "数据查询";
            log.LogAfterObject = JsonHelper.Obj2Json<string>(qm.GetCondition(true));
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

        protected void ZButton4_Click(object sender, EventArgs e)
        {
            string key = PubCom.GetRepeaterKey(rplist, "cbselect");
            SysCode sc = bsc.GetCodeByID(int.Parse(key));
            if (bsc.Delete(sc) == 1)
            {
                //// 插入日志
                SysOperateLog log = new SysOperateLog();
                log.LogID = StringHelper.getKey();
                log.LogType = LogType.数据字典.ToString();
                log.OperateUser = GetLogUserName();
                log.OperateDate = DateTime.Now;
                log.LogOperateType = "数据删除";
                log.LogBeforeObject = JsonHelper.Obj2Json(sc);
                bsol.Insert(log);
                Message.ShowOKAndReflashOfDelete(this, "删除成功", "zbquery");
            }
            else
            {
                Message.ShowWrong(this, "删除失败");
            }
        }
    }
}